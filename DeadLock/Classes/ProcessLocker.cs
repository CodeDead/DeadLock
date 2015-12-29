using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;

namespace DeadLock.Classes
{
    public class ProcessLocker
    {
        private readonly Process _locker;

        private string _fileName;
        private string _filePath;
        private readonly Language _language;

        public ProcessLocker(Process l, Language language)
        {
            _locker = l;
            _language = language;
            SetFilePath(GetMainModuleFilepath(l.Id));
            SetFileName(Path.GetFileName(_filePath));
        }

        private void SetFileName(string fileName)
        {
            _fileName = fileName;
        }

        private void SetFilePath(string filePath)
        {
            _filePath = string.IsNullOrEmpty(filePath) ? _language.MsgAccessDenied : filePath;
        }

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

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetFilePath()
        {
            return _filePath;
        }

        public int GetProcessId()
        {
            return _locker.Id;
        }

        public Process GetProcess()
        {
            return _locker;
        }
    }
}
