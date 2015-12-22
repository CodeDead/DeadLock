using System;
using System.Windows.Forms;
using DeadLock.Forms;
using Syncfusion.Windows.Forms;

namespace DeadLock
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            Application.Run(new FrmMain(args));
        }
    }
}
