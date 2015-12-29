using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace DeadLock.Classes
{
    internal class ListViewLocker
    {
        private readonly string _path;
        private List<ProcessLocker> _lockers;
        private CancellationTokenSource _cts;

        private bool _hasCancelled;
        private bool _isRunning;

        internal ListViewLocker(string path)
        {
            _path = path;
            _lockers = new List<ProcessLocker>();
            _cts = new CancellationTokenSource();
            _hasCancelled = true;
            _isRunning = false;
        }

        internal bool IsRunning()
        {
            return _isRunning;
        }

        internal void SetRunning(bool running)
        {
            _isRunning = running;
            _hasCancelled = !running;
        }

        internal string GetPath()
        {
            return _path;
        }

        internal IEnumerable<ProcessLocker> GetLockers()
        {
            return _lockers;
        }

        internal void SetLocker(List<ProcessLocker> lockers)
        {
            _lockers = lockers;
        }

        internal CancellationToken GetCancellationToken()
        {
            return _cts.Token;
        }

        private void SetCancelled(bool c)
        {
            _hasCancelled = c;
        }

        internal bool HasCancelled()
        {
            return _hasCancelled;
        }

        private void ResetCancellationToken()
        {
            _cts = new CancellationTokenSource();
        }

        internal void CancelTask()
        {
            if (!IsRunning()) return;
            if (GetCancellationToken().IsCancellationRequested) return;
            _cts.Cancel();
            SetCancelled(true);
            ResetCancellationToken();
        }

        internal void SetOwnership(bool owned)
        {
            try
            {
                if (owned)
                {
                    if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
                    {
                        DirectoryInfo info = new DirectoryInfo(GetPath());
                        WindowsIdentity self = WindowsIdentity.GetCurrent();
                        DirectorySecurity ds = info.GetAccessControl();
                        if (self?.User != null)
                        {
                            if (ds.GetOwner(typeof (NTAccount)).ToString() != self.Name)
                            {
                                ds.SetOwner(self.User);
                            }
                            ds.AddAccessRule(new FileSystemAccessRule(self.User, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                            info.SetAccessControl(ds);
                        }
                    }
                    else
                    {
                        WindowsIdentity self = WindowsIdentity.GetCurrent();
                        FileSecurity fs = File.GetAccessControl(GetPath());
                        if (self?.User != null)
                        {
                            if (fs.GetOwner(typeof(NTAccount)).ToString() != self.Name)
                            {
                                fs.SetOwner(self.User);
                            }
                            fs.AddAccessRule(new FileSystemAccessRule(self.User, FileSystemRights.FullControl, AccessControlType.Allow));
                            File.SetAccessControl(GetPath(), fs);
                            File.SetAttributes(GetPath(), FileAttributes.Normal);
                        }
                    }
                }
                else
                {
                    if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(GetPath());
                        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                        AuthorizationRuleCollection rules = directorySecurity.GetAccessRules(true, false, typeof(NTAccount));
                        foreach (FileSystemAccessRule rule in rules)
                        {
                            directorySecurity.RemoveAccessRule(rule);
                        }
                        Directory.SetAccessControl(GetPath(), directorySecurity);
                    }
                    else
                    {
                        FileSecurity fs = File.GetAccessControl(GetPath());
                        AuthorizationRuleCollection rules = fs.GetAccessRules(true, false, typeof (NTAccount));
                        foreach (FileSystemAccessRule rule in rules)
                        {
                            fs.RemoveAccessRule(rule);
                        }
                        File.SetAccessControl(GetPath(), fs);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal bool HasOwnership()
        {
            bool isWriteAccess = false;
            try
            {
                AuthorizationRuleCollection collection = Directory.GetAccessControl(GetPath()).GetAccessRules(true, true, typeof(NTAccount));
                foreach (FileSystemAccessRule rule in collection)
                {
                    if (rule.AccessControlType == AccessControlType.Allow)
                    {
                        isWriteAccess = true;
                        break;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                isWriteAccess = false;
            }
            catch (Exception)
            {
                isWriteAccess = false;
            }

            return isWriteAccess;
        }


        internal async Task<List<ProcessLocker>> GetLockerDetails()
        {
            List<ProcessLocker> lockers = new List<ProcessLocker>();

            if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
            {
                await Task.Run(() =>
                {
                    try
                    {
                        foreach (string path in GetDirectoryFiles(GetPath(), "*.*", SearchOption.AllDirectories))
                        {
                            foreach (Process p in NativeMethods.FindLockingProcesses(path))
                            {
                                bool add = true;
                                foreach (ProcessLocker l in lockers)
                                {
                                    GetCancellationToken().ThrowIfCancellationRequested();
                                    try
                                    {
                                        if (l.GetProcessId() == p.Id)
                                        {
                                            add = false;
                                        }
                                    }
                                    catch (Win32Exception)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    lockers.Add(new ProcessLocker(p));
                                }
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    try
                    {
                        GetCancellationToken().ThrowIfCancellationRequested();
                        foreach (Process p in NativeMethods.FindLockingProcesses(GetPath()))
                        {
                            lockers.Add(new ProcessLocker(p));
                        }
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                });
            }
            return lockers;
        }

        private static IEnumerable<string> GetDirectoryFiles(string rootPath, string patternMatch, SearchOption searchOption)
        {
            IEnumerable<string> foundFiles = Enumerable.Empty<string>();

            if (searchOption == SearchOption.AllDirectories)
            {
                try
                {
                    IEnumerable<string> subDirs = Directory.EnumerateDirectories(rootPath);
                    foreach (string dir in subDirs)
                    {
                        foundFiles = foundFiles.Concat(GetDirectoryFiles(dir, patternMatch, searchOption)); // Add files in subdirectories recursively to the list
                    }
                }
                catch (UnauthorizedAccessException) { }
                catch (PathTooLongException) { }
            }

            try
            {
                foundFiles = foundFiles.Concat(Directory.EnumerateFiles(rootPath, patternMatch)); // Add files from the current directory
            }
            catch (UnauthorizedAccessException) { }

            return foundFiles;
        }

        internal async Task<bool> Unlock()
        {
            if (!File.Exists(GetPath()) && !Directory.Exists(GetPath())) return false;

            try
            {
                List<ProcessLocker> lockers = await GetLockerDetails();
                await Task.Run(() =>
                {
                    try
                    {
                        foreach (ProcessLocker p in lockers)
                        {
                            GetCancellationToken().ThrowIfCancellationRequested();
                            if (p.GetProcess().HasExited) continue;
                            p.GetProcess().Kill();
                            p.GetProcess().WaitForExit();
                        }
                    }
                    catch (OperationCanceledException) { }
                    catch (Win32Exception) { }

                });
                return true;
            }
            catch (Win32Exception win32Exception)
            {
                //TODO: Implement LanguageManager
                if (MessageBoxAdv.Show(win32Exception.Message + Environment.NewLine + "Would you like to restart DeadLock with administrator rights ?", "DeadLock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProcessStartInfo proc = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };
                    Process.Start(proc);
                }
            }
            return false;
        }

        internal async void Remove()
        {
            await Unlock();
            if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
            {
                Directory.Delete(GetPath(), true);
            }
            else
            {
                File.Delete(GetPath());
            }
        }

        internal async Task<bool> Move()
        {
            if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    await Unlock();
                    await Task.Run(() =>
                    {

                        try
                        {
                            string sourcePath = GetPath().TrimEnd('\\', ' ');
                            string targetPath = fbd.SelectedPath.TrimEnd('\\', ' ');
                            IEnumerable<IGrouping<string, string>> files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories).GroupBy(Path.GetDirectoryName);
                            foreach (IGrouping<string, string> folder in files)
                            {
                                GetCancellationToken().ThrowIfCancellationRequested();
                                string targetFolder = folder.Key.Replace(sourcePath, targetPath);
                                Directory.CreateDirectory(targetFolder);
                                foreach (string file in folder)
                                {
                                    GetCancellationToken().ThrowIfCancellationRequested();
                                    string fileName = Path.GetFileName(file);
                                    if (fileName == null) continue;
                                    string targetFile = Path.Combine(targetFolder, fileName);
                                    if (File.Exists(targetFile))
                                    {
                                        File.Delete(targetFile);
                                    }
                                    File.Move(file, targetFile);
                                }
                            }
                            Directory.Delete(GetPath(), true);
                        }
                        catch (OperationCanceledException) { }

                    });
                }
                else return false;
            }
            else
            {
                if (File.Exists(GetPath()))
                {
                    SaveFileDialog sfd = new SaveFileDialog { Filter = @"|*" + Path.GetExtension(GetPath()) };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        await Unlock();
                        await Task.Run(() =>
                        {
                            File.Move(GetPath(), sfd.FileName);
                        });
                    }
                    else return false;
                }
                else return false;
            }
            return true;
        }

        internal async Task<bool> Copy()
        {
            if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    await Unlock();
                    await Task.Run(() =>
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(GetPath(), fbd.SelectedPath);
                    });
                }
                else return false;
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = @"|*" + Path.GetExtension(GetPath()) };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    await Unlock();
                    await Task.Run(() =>
                    {
                        File.Copy(GetPath(), sfd.FileName);
                    });
                }
                else return false;
            }
            return true;
        }
    }
}
