using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace DeadLock.Classes
{
    internal class ListViewLocker
    {
        private readonly string _path;
        private List<Process> _lockers;
        private CancellationTokenSource _cts;

        private bool _hasCancelled;
        private bool _isRunning;

        internal ListViewLocker(string path)
        {
            _path = path;
            _lockers = new List<Process>();
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

        internal IEnumerable<Process> GetLockers()
        {
            return _lockers;
        }

        internal void SetLocker(List<Process> lockers)
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
            if (IsRunning())
            {
                if (!GetCancellationToken().IsCancellationRequested)
                {
                    _cts.Cancel();
                    SetCancelled(true);
                    ResetCancellationToken();
                }
            }
        }

        internal void SetOwnership(bool owned)
        {
            if (owned)
            {
                if (File.GetAttributes(GetPath()).HasFlag(FileAttributes.Directory))
                {
                    WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                    if (windowsIdentity != null)
                    {
                        SecurityIdentifier cu = windowsIdentity.User;
                        DirectorySecurity fileS = Directory.GetAccessControl(GetPath());
                        if (cu != null)
                        {
                            fileS.SetOwner(cu);
                            fileS.SetAccessRule(new FileSystemAccessRule(cu, FileSystemRights.FullControl, AccessControlType.Allow));
                            Directory.SetAccessControl(GetPath(), fileS);
                            File.SetAttributes(GetPath(), FileAttributes.Normal);
                        }
                    }
                }
                else
                {
                    WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                    if (windowsIdentity != null)
                    {
                        SecurityIdentifier cu = windowsIdentity.User;
                        FileSecurity fileS = File.GetAccessControl(GetPath());
                        if (cu != null)
                        {
                            fileS.SetOwner(cu);
                            fileS.SetAccessRule(new FileSystemAccessRule(cu, FileSystemRights.FullControl, AccessControlType.Allow));
                            File.SetAccessControl(GetPath(), fileS);
                            File.SetAttributes(GetPath(), FileAttributes.Normal);
                        }
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
                    
                }
            }
        }

        internal bool HasOwnership()
        {
            bool isWriteAccess = false;
            try
            {
                AuthorizationRuleCollection collection = Directory.GetAccessControl(GetPath()).GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
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
            if (!isWriteAccess)
            {
                //handle notifications                  
            }

            return isWriteAccess;
        }
    }
}
