using System;
using System.IO;
using Microsoft.Win32;

namespace RegManager
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0) return;

            bool addAutoStartup = false;
            bool changeAutoStartup = false;

            bool addExplorerIntegration = false;
            bool changeExplorerIntegration = false;

            string path = "";
            foreach (string s in args)
            {
                switch (s)
                {
                    case "0":
                        addAutoStartup = true;
                        changeAutoStartup = true;
                        break;
                    case "1":
                        addAutoStartup = false;
                        changeAutoStartup = true;
                        break;
                    case "2":
                        addExplorerIntegration = true;
                        changeExplorerIntegration = true;
                        break;
                    case "3":
                        addExplorerIntegration = false;
                        changeExplorerIntegration = true;
                        break;
                    default:
                        if (File.Exists(s))
                        {
                            path = s;
                        }
                        else
                        {
                            Console.WriteLine("Warning: Argument not supported !");
                            return;
                        }
                        break;
                }
            }
            if (changeAutoStartup)
            {
                ChangeAutoStartUp(addAutoStartup, path);
            }
            if (changeExplorerIntegration)
            {
                ChangeExplorerIntegration(addExplorerIntegration, path);
            }
            Console.WriteLine("Done.");
        }

        private static void EnableExplorerIntegration(string path)
        {
            if (File.Exists(path))
            {
                Registry.ClassesRoot.CreateSubKey(@"*\shell\DeadLock", true);
                Registry.ClassesRoot.CreateSubKey(@"*\shell\DeadLock\command", true);
                Registry.SetValue(@"HKEY_CLASSES_ROOT\*\shell\DeadLock\command", "", path + " %1");

                Registry.ClassesRoot.CreateSubKey(@"Directory\shell\DeadLock", true);
                Registry.ClassesRoot.CreateSubKey(@"Directory\shell\DeadLock\command", true);
                Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\DeadLock\command", "", path + " %1");
            }
            else
            {
                Console.Write("Warning: path does not exist !");
            }
        }

        private static void DisableExplorerIntegration()
        {
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"*\shell\DeadLock\command"))
            {
                if (key != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(@"*\shell\DeadLock");
                }
            }

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\DeadLock\command"))
            {
                if (key != null)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree(@"Directory\shell\DeadLock");
                }
            }
        }

        private static void ChangeExplorerIntegration(bool value, string path)
        {
            if (value)
            {
                Console.WriteLine("Enabling Windows Explorer integration...");
                EnableExplorerIntegration(path);
            }
            else
            {
                Console.WriteLine("Disabling Windows Explorer integration...");
                DisableExplorerIntegration();
            }
        }

        private static void EnableAutoStartup(string path)
        {
            if (File.Exists(path))
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "DeadLock", path);
            }
            else
            {
                Console.WriteLine("Warning: path does not exist !");
            }
        }

        private static void DisableAutoStartup()
        {
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "DeadLock", "").ToString() == "") return;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                key?.DeleteValue("DeadLock");
            }
        }

        private static void ChangeAutoStartUp(bool value, string path)
        {
            if (value)
            {
                Console.WriteLine("Enabling Auto Startup...");
                EnableAutoStartup(path);
            }
            else
            {
                Console.WriteLine("Disabling Auto Startup...");
                DisableAutoStartup();
            }
        }
    }
}