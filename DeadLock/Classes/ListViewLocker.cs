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
// ReSharper disable PossibleMultipleEnumeration

namespace DeadLock.Classes
{
    /// <summary>
    /// Represents the collection of a path, the ProcessLockers of that path and a CancellationTokenSource to cancel a task into a single class.
    /// </summary>
    internal class ListViewLocker
    {
        private readonly string _path;
        private List<ProcessLocker> _lockers;
        private CancellationTokenSource _cts;

        private bool _hasCancelled;
        private bool _isRunning;

        private readonly Language _language;

        /// <summary>
        /// Generates a new ListViewLocker. 
        /// </summary>
        /// <param name="path">The path to a file.</param>
        /// <param name="language">The current GUI language.</param>
        internal ListViewLocker(string path, Language language)
        {
            _path = path;
            _lockers = new List<ProcessLocker>();
            _cts = new CancellationTokenSource();
            _hasCancelled = true;
            _isRunning = false;

            _language = language;
        }

        /// <summary>
        /// Checks if the ListViewLocker is currently executing a task.
        /// </summary>
        /// <returns>A boolean to represent whether or not the ListViewLocker is running a task.</returns>
        internal bool IsRunning()
        {
            return _isRunning;
        }

        /// <summary>
        /// Sets whether or not the ListViewLocker is running a task.
        /// </summary>
        /// <param name="running">True if the ListViewLocker is running a task and false if the ListViewLocker is not running a task.</param>
        internal void SetRunning(bool running)
        {
            _isRunning = running;
            _hasCancelled = !running;
        }

        /// <summary>
        /// Get the path that is associated with the ListViewLocker.
        /// </summary>
        /// <returns>The path to a file that is associated with the ListViewLocker.</returns>
        internal string GetPath()
        {
            return _path;
        }

        /// <summary>
        /// Gets the ProcessLockers that are associated with the ListViewLocker.
        /// </summary>
        /// <returns>A list of ProcessLockers that are associated with the ListViewLocker.</returns>
        internal IEnumerable<ProcessLocker> GetLockers()
        {
            return _lockers;
        }

        /// <summary>
        /// Update the list of ProcessLockers that are associated with the ListViewLocker.
        /// </summary>
        /// <param name="lockers">The new list of ProcessLockers that are associated with the ListViewLocker.</param>
        internal void SetLocker(List<ProcessLocker> lockers)
        {
            _lockers = lockers;
        }

        /// <summary>
        /// Gets the CancellationToken that is associated with the ListViewLocker.
        /// </summary>
        /// <returns>The CancellationToken that is associated with the ListViewLocker.</returns>
        private CancellationToken GetCancellationToken()
        {
            return _cts.Token;
        }

        /// <summary>
        /// Sets whether or not the task that is associated with the ListViewLocker has cancelled.
        /// </summary>
        /// <param name="c">A boolean to represent if the task has cancelled or not.</param>
        private void SetCancelled(bool c)
        {
            _hasCancelled = c;
        }

        /// <summary>
        /// Checks whether or not the task that is associated with the ListViewLocker has cancelled or not.
        /// </summary>
        /// <returns>A boolean to represent if the task has cancelled or not.</returns>
        internal bool HasCancelled()
        {
            return _hasCancelled;
        }

        /// <summary>
        /// Generate a new CancellationTokenSource if the old one has been cancelled.
        /// </summary>
        private void ResetCancellationToken()
        {
            _cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Cancel a task that is associated with the ListViewLocker.
        /// </summary>
        internal void CancelTask()
        {
            if (!IsRunning()) return;
            if (GetCancellationToken().IsCancellationRequested) return;
            _cts.Cancel();
            SetCancelled(true);
            ResetCancellationToken();
        }

        /// <summary>
        /// Change the ownership of the file or folder that is associated with the ListViewLocker.
        /// </summary>
        /// <param name="owned">A boolean to represent wether the operator owns the file or folder that is associated with the ListViewLocker.</param>
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
                        ds.SetAccessRuleProtection(false, true);
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
                        fs.SetAccessRuleProtection(false, true);
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
                        directorySecurity.SetAccessRuleProtection(true, false);
                        AuthorizationRuleCollection rules = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));
                        foreach (FileSystemAccessRule rule in rules)
                        {
                            directorySecurity.RemoveAccessRule(rule);
                        }
                        Directory.SetAccessControl(GetPath(), directorySecurity);
                    }
                    else
                    {
                        FileSecurity fs = File.GetAccessControl(GetPath());
                        fs.SetAccessRuleProtection(true, false);
                        AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof (NTAccount));
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

        /// <summary>
        /// Checks whether or not the operator has ownership rights to the file or folder that is associated with the ListViewLocker.
        /// </summary>
        /// <returns>A boolean to represent whether or not the operator has ownership rights to the file or folder that is associated with the ListViewLocker.</returns>
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

        /// <summary>
        /// A task that returns the list of ProcessLockers that are currently locking the file or folder that is associated with the path of the ListViewLocker.
        /// </summary>
        /// <returns>A list of ProcessLockers that are locking the file or folder that is associated with the path of the ListViewLocker.</returns>
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
                            foreach (Process p in NativeMethods.FindLockingProcesses(path, _language))
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
                                    lockers.Add(new ProcessLocker(p, _language));
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
                        foreach (Process p in NativeMethods.FindLockingProcesses(GetPath(), _language))
                        {
                            lockers.Add(new ProcessLocker(p, _language));
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

        /// <summary>
        /// Get a list of files inside a folder that are accessible to the operator.
        /// </summary>
        /// <param name="rootPath">The root path of the folder</param>
        /// <param name="patternMatch">The pattern that should be used to find the files.</param>
        /// <param name="searchOption">The SearchOption that should be used to find the files.</param>
        /// <returns>A list of files inside a folder that are accessible to the operator.</returns>
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
                        foundFiles = foundFiles.Concat(GetDirectoryFiles(dir, patternMatch, searchOption));
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

        /// <summary>
        /// A task to unlock the file or folder that is associated with the path of the ListViewLocker.
        /// </summary>
        /// <returns>A boolean to represent whether the task completed successfully or not.</returns>
        internal async Task<bool> Unlock()
        {
            if (!File.Exists(GetPath()) && !Directory.Exists(GetPath())) return false;

            try
            {
                if (Properties.Settings.Default.TakeOwnership)
                {
                    if (!HasOwnership())
                    {
                        SetOwnership(true);
                    }
                }
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
                MessageBoxAdv.Show(win32Exception.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        /// <summary>
        /// A task to remove the file or folder that is associated with the path of the ListViewLocker.
        /// </summary>
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

        /// <summary>
        /// A task to move the file or folder that is associated with the path of the ListViewLocker.
        /// </summary>
        /// <returns>A boolean to represent whether the task completed successfully or not.</returns>
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

        /// <summary>
        /// A task that copies the file or folder that is associated with the path of the ListViewLocker.
        /// </summary>
        /// <returns>A boolean to represent whether the task completed successfully or not.</returns>
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
