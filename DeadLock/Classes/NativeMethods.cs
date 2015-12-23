using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DeadLock.Classes
{
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RmUniqueProcess
        {
            internal readonly int dwProcessId;
            private readonly System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
        }

        private const int RmRebootReasonNone = 0;
        private const int CchRmMaxAppName = 255;
        private const int CchRmMaxSvcName = 63;

        private enum RmAppType
        {
            // ReSharper disable once UnusedMember.Local
            RmUnknownApp = 0,
            // ReSharper disable once UnusedMember.Local
            RmMainWindow = 1,
            // ReSharper disable once UnusedMember.Local
            RmOtherWindow = 2,
            // ReSharper disable once UnusedMember.Local
            RmService = 3,
            // ReSharper disable once UnusedMember.Local
            RmExplorer = 4,
            // ReSharper disable once UnusedMember.Local
            RmConsole = 5,
            // ReSharper disable once UnusedMember.Local
            RmCritical = 1000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct RmProcessInfo
        {
            internal RmUniqueProcess Process;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CchRmMaxAppName + 1)]
            private readonly string strAppName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CchRmMaxSvcName + 1)]
            private readonly string strServiceShortName;
            private readonly RmAppType ApplicationType;

            private readonly uint AppStatus;
            private readonly uint TSSessionId;
            [MarshalAs(UnmanagedType.Bool)]
            private readonly bool bRestartable;
        }

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
        private static extern int RmRegisterResources(uint pSessionHandle, uint nFiles, string[] rgsFilenames, uint nApplications, [In] RmUniqueProcess[] rgApplications, uint nServices, string[] rgsServiceNames);

        [DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode)]
        private static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

        [DllImport("rstrtmgr.dll")]
        private static extern int RmEndSession(uint pSessionHandle);

        [DllImport("rstrtmgr.dll")]
        private static extern int RmGetList(uint dwSessionHandle, out uint pnProcInfoNeeded, ref uint pnProcInfo, [In, Out] RmProcessInfo[] rgAffectedApps, ref uint lpdwRebootReasons);


        //TODO: Implement LanguageManager
        internal static List<Process> FindLockingProcesses(string path)
        {
            uint handle;
            string key = Guid.NewGuid().ToString();
            List<Process> processes = new List<Process>();

            int res = RmStartSession(out handle, 0, key);
            if (res != 0) throw new Exception("Could not begin restart session. Unable to determine resource locker.");

            try
            {
                const int errorMoreData = 234;
                uint pnProcInfoNeeded;
                uint pnProcInfo = 0;
                uint lpdwRebootReasons = RmRebootReasonNone;

                string[] resources = { path };
                res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);

                if (res != 0) throw new Exception("Could not register resource.");
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);

                if (res == errorMoreData)
                {
                    RmProcessInfo[] processInfo = new RmProcessInfo[pnProcInfoNeeded];
                    pnProcInfo = pnProcInfoNeeded;

                    res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
                    if (res == 0)
                    {
                        processes = new List<Process>((int)pnProcInfo);

                        for (int i = 0; i < pnProcInfo; i++)
                        {
                            try
                            {
                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));
                            }
                            catch (ArgumentException) { }
                        }
                    }
                    else throw new Exception("Could not list the processes that are locking the resource !");
                }
                else if (res != 0) throw new UnauthorizedAccessException("Could not list the processes that are locking the resource. Failed to get size of result !");
            }
            finally
            {
                RmEndSession(handle);
            }
            return processes;
        }
    }
}
