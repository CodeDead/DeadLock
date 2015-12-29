using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
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
    }
}
