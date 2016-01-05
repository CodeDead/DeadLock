using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;

namespace DeadLock.Classes
{
    /// <summary>
    /// A collection of a Process, the filename of that process, the path of that process and the current Language.
    /// </summary>
    internal class ProcessLocker
    {
        #region Variables
        private readonly Process _locker;

        private string _fileName;
        private string _filePath;
        private readonly Language _language;
        #endregion

        /// <summary>
        /// Generate a new ProcessLocker.
        /// </summary>
        /// <param name="l">The Process that should be associated to the ProcessLocker.</param>
        /// <param name="language">The Language that should be associated to the ProcessLocker.</param>
        internal ProcessLocker(Process l, Language language)
        {
            _locker = l;
            _language = language;
            SetFilePath(GetMainModuleFilepath(l.Id));
            SetFileName(Path.GetFileName(_filePath));
        }

        /// <summary>
        /// Set the file name of the ProcessLocker.
        /// </summary>
        /// <param name="fileName">The file name of the process that is associated with the ProcessLocker.</param>
        private void SetFileName(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Set the file path that should be associated with the ProcessLocker.
        /// </summary>
        /// <param name="filePath">The file path that should be associated with the ProcessLocker.</param>
        private void SetFilePath(string filePath)
        {
            _filePath = string.IsNullOrEmpty(filePath) ? _language.MsgAccessDenied : filePath;
        }

        /// <summary>
        /// Get the file path of the Process that is associated with the ProcessLocker. Warning: Requires a lot of system resources.
        /// </summary>
        /// <param name="processId">The process ID of the Process that is associated with the ProcessLocker.</param>
        /// <returns>The file path that is associated with the Process of the ProcessLocker.</returns>
        private static string GetMainModuleFilepath(int processId)
        {
            string filepath = "";
            try
            {
                string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQueryString))
                {
                    using (ManagementObjectCollection results = searcher.Get())
                    {
                        ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                        if (mo != null)
                        {
                            filepath = (string)mo["ExecutablePath"];
                        }
                    }
                }
            }
            catch (Win32Exception) { }
            return filepath;
        }

        /// <summary>
        /// Get the file name that is associated with the ProcessLocker.
        /// </summary>
        /// <returns>The file name that is associated with the ProcessLocker.</returns>
        internal string GetFileName()
        {
            return _fileName;
        }

        /// <summary>
        /// Get the file path that is associated with the ProcessLocker.
        /// </summary>
        /// <returns>The file path that is associated with the ProcessLocker.</returns>
        internal string GetFilePath()
        {
            return _filePath;
        }

        /// <summary>
        /// Get the process ID that is associated with the Process of the ProcessLocker.
        /// </summary>
        /// <returns>The process ID that is associated with the Process of the ProcessLocker.</returns>
        internal int GetProcessId()
        {
            return _locker.Id;
        }

        /// <summary>
        /// Get the Process that is associated with the ProcessLocker.
        /// </summary>
        /// <returns>The Process that is associated with the ProcessLocker.</returns>
        internal Process GetProcess()
        {
            return _locker;
        }
    }
}