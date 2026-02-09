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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JGaF1cXmhLYVJzWmFZfVhgdV9EYVZVQmY/P1ZhSXxVdkdjUX5dcnVRQGFYV0V9XEA=");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                MetroStyleColorTable metroColorTable = new MetroStyleColorTable
                {
                    BorderColor = Properties.Settings.Default.MetroColor,
                    NoButtonBackColor = Properties.Settings.Default.MetroColor,
                    YesButtonBackColor = Properties.Settings.Default.MetroColor,
                    OKButtonBackColor = Properties.Settings.Default.MetroColor
                };
                MessageBoxAdv.MetroColorTable = metroColorTable;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            Application.Run(new FrmMain(args));
        }
    }
}
