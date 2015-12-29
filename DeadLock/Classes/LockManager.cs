using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
// ReSharper disable PossibleMultipleEnumeration

namespace DeadLock.Classes
{
    internal static class LockManager
    {
        internal static async Task<List<ProcessLocker>> GetLockerDetails(string itemPath, CancellationToken ct)
        {
            List<ProcessLocker> lockers = new List<ProcessLocker>();

            if (File.GetAttributes(itemPath).HasFlag(FileAttributes.Directory))
            {
                await Task.Run(() =>
                {
                    try
                    {
                        foreach (string path in GetDirectoryFiles(itemPath, "*.*", SearchOption.AllDirectories))
                        {
                            foreach (Process p in NativeMethods.FindLockingProcesses(path))
                            {
                                bool add = true;
                                foreach (ProcessLocker l in lockers)
                                {
                                    ct.ThrowIfCancellationRequested();
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
                }, ct);
            }
            else
            {
                await Task.Run(() =>
                {
                    try
                    {
                        ct.ThrowIfCancellationRequested();
                        foreach (Process p in NativeMethods.FindLockingProcesses(itemPath))
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
                }, ct);
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

        internal static async Task<bool> Unlock(string path, CancellationToken ct)
        {
            if (!File.Exists(path) && !Directory.Exists(path)) return false;

            try
            {
                List<ProcessLocker> lockers = await GetLockerDetails(path, ct);
                await Task.Run(() =>
                {
                    try
                    {
                        foreach (ProcessLocker p in lockers)
                        {
                            ct.ThrowIfCancellationRequested();
                            if (p.GetProcess().HasExited) continue;
                            p.GetProcess().Kill();
                            p.GetProcess().WaitForExit();
                        }
                    }
                    catch (OperationCanceledException) { }
                    catch (Win32Exception) { }

                }, ct);
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

        internal static async void Remove(string path, CancellationToken ct)
        {
            await Unlock(path, ct);
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                Directory.Delete(path, true);
            }
            else
            {
                File.Delete(path);
            }
        }

        internal static async Task<bool> Move(string path, CancellationToken ct)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    await Unlock(path, ct);
                    await Task.Run(() =>
                    {

                        try
                        {
                            string sourcePath = path.TrimEnd('\\', ' ');
                            string targetPath = fbd.SelectedPath.TrimEnd('\\', ' ');
                            IEnumerable<IGrouping<string, string>> files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories).GroupBy(Path.GetDirectoryName);
                            foreach (IGrouping<string, string> folder in files)
                            {
                                ct.ThrowIfCancellationRequested();
                                string targetFolder = folder.Key.Replace(sourcePath, targetPath);
                                Directory.CreateDirectory(targetFolder);
                                foreach (string file in folder)
                                {
                                    ct.ThrowIfCancellationRequested();
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
                            Directory.Delete(path, true);
                        }
                        catch (OperationCanceledException) { }

                    }, ct);
                }
                else return false;
            }
            else
            {
                if (File.Exists(path))
                {
                    SaveFileDialog sfd = new SaveFileDialog { Filter = @"|*" + Path.GetExtension(path) };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        await Unlock(path, ct);
                        await Task.Run(() =>
                        {
                            File.Move(path, sfd.FileName);
                        }, ct);
                    }
                    else return false;
                }
                else return false;
            }
            return true;
        }

        internal static async Task<bool> Copy(string path, CancellationToken ct)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    await Unlock(path, ct);
                    await Task.Run(() =>
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(path, fbd.SelectedPath);
                    }, ct);
                }
                else return false;
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = @"|*" + Path.GetExtension(path) };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    await Unlock(path, ct);
                    await Task.Run(() =>
                    {
                        File.Copy(path, sfd.FileName);
                    }, ct);
                }
                else return false;
            }
            return true;
        }
    }
}
