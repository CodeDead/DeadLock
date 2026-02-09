using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;

namespace DeadLock.Forms
{
    public partial class FrmSettings : SfForm
    {
        #region Variables
        private readonly FrmMain _main;
        private bool _originalIntegration;
        private bool _originalStartup;
        #endregion

        /// <summary>
        /// Generate a new FrmSettings form.
        /// </summary>
        /// <param name="main">The main form.</param>
        public FrmSettings(FrmMain main)
        {
            InitializeComponent();
            _main = main;
            LoadLanguage();
        }

        /// <summary>
        /// Change the GUI to match the current Language.
        /// </summary>
        private void LoadLanguage()
        {
            Text = @"DeadLock - " + _main.LanguageManager.GetLanguage().BarItemSettings;

            tpaGeneral.Text = _main.LanguageManager.GetLanguage().LblGeneral;
            tpaAppearance.Text = _main.LanguageManager.GetLanguage().LblAppearance;
            tpaAdvanced.Text = _main.LanguageManager.GetLanguage().LblAdvanced;

            //General
            lblAutoUpdate.Text = _main.LanguageManager.GetLanguage().ChbAutoUpdate;
            lblNotifyIcon.Text = _main.LanguageManager.GetLanguage().ChbShowNotifyIcon;
            lblMinimized.Text = _main.LanguageManager.GetLanguage().ChbStartMinimized;
            lblAdminWarning.Text = _main.LanguageManager.GetLanguage().ChbShowAdminWarning;

            tbtnAutoUpdate.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnAutoUpdate.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            tbtnNotifyIcon.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnNotifyIcon.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            tbtnStartMinimized.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnStartMinimized.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            tbtnAdminWarning.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnAdminWarning.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            //Appearance
            lblThemeStyle.Text = _main.LanguageManager.GetLanguage().LblThemeStyle;
            lblFormSize.Text = _main.LanguageManager.GetLanguage().LblRememberFormSize;
            lblDetails.Text = _main.LanguageManager.GetLanguage().LblShowDetails;
            lblLanguage.Text = _main.LanguageManager.GetLanguage().LblLanguage;

            tbtnFormSize.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnFormSize.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            tbtnDetails.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnDetails.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            //Advanced
            lblAutorun.Text = _main.LanguageManager.GetLanguage().LblAutoRunDeadLock;
            lblWindowsExplorerIntegration.Text = _main.LanguageManager.GetLanguage().LblWindowsExplorerIntegration;
            lblOwnership.Text = _main.LanguageManager.GetLanguage().LblOwnership;

            tbtnAutoRun.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnAutoRun.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            tbtnWindowsExplorerIntegration.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnWindowsExplorerIntegration.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            tbtnOwnership.ActiveState.Text = _main.LanguageManager.GetLanguage().TbtnOn;
            tbtnOwnership.InactiveState.Text = _main.LanguageManager.GetLanguage().TbtnOff;

            btnClose.Text = _main.LanguageManager.GetLanguage().BtnClose;
            btnReset.Text = _main.LanguageManager.GetLanguage().BtnReset;
            btnSave.Text = _main.LanguageManager.GetLanguage().BtnSave;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load the current settings.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                //General
                tbtnAutoUpdate.ToggleState = Properties.Settings.Default.AutoUpdate ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnNotifyIcon.ToggleState = Properties.Settings.Default.ShowNotifyIcon ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnStartMinimized.ToggleState = Properties.Settings.Default.StartMinimized ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnAdminWarning.ToggleState = Properties.Settings.Default.ShowAdminWarning ? ToggleButtonState.Active : ToggleButtonState.Inactive;

                //Appearance
                cpbThemeStyle.SelectedColor = Properties.Settings.Default.MetroColor;
                tbtnFormSize.ToggleState = Properties.Settings.Default.RememberFormSize ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnDetails.ToggleState = Properties.Settings.Default.ViewDetails ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                cboLanguage.SelectedIndex = Properties.Settings.Default.Language;
                txtLanguagePath.Text = Properties.Settings.Default.LanguagePath;

                //Advanced
                tbtnAutoRun.ToggleState = AutoStartUp() ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                _originalStartup = tbtnAutoRun.ToggleState == ToggleButtonState.Active;
                tbtnOwnership.ToggleState = Properties.Settings.Default.TakeOwnership ? ToggleButtonState.Active : ToggleButtonState.Inactive;

                tbtnWindowsExplorerIntegration.ToggleState = WindowsExplorerIntegration() ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                _originalIntegration = tbtnWindowsExplorerIntegration.ToggleState == ToggleButtonState.Active;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Check if the program starts automatically.
        /// </summary>
        /// <returns>A boolean to represent whether the program starts automatically or not.</returns>
        private static bool AutoStartUp()
        {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "DeadLock", "").ToString() == Application.ExecutablePath;
        }

        /// <summary>
        /// Check if Windows Explorer integration is enabled for the program.
        /// </summary>
        /// <returns>A boolean to represent whether Windows Explorer integration is enabled for the program.</returns>
        private static bool WindowsExplorerIntegration()
        {
            bool fileExplorerIntegration = false;
            bool folderExplorerIntegration = false;
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"*\shell\DeadLock\command"))
            {
                if (key != null && key.GetValue("", "").ToString() == Application.ExecutablePath + " %1")
                {
                    fileExplorerIntegration = true;
                }
            }

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\DeadLock\command"))
            {
                if (key != null && key.GetValue("", "").ToString() == Application.ExecutablePath + " %1")
                {
                    folderExplorerIntegration = true;
                }
            }

            return folderExplorerIntegration && fileExplorerIntegration;
        }

        /// <summary>
        /// Save the new settings.
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                if (tbtnNotifyIcon.ToggleState == ToggleButtonState.Inactive && tbtnStartMinimized.ToggleState == ToggleButtonState.Active)
                {
                    tbtnNotifyIcon.ToggleState = ToggleButtonState.Active;
                }


                Properties.Settings.Default.AutoUpdate = tbtnAutoUpdate.ToggleState == ToggleButtonState.Active;
                if (tbtnNotifyIcon.ToggleState == ToggleButtonState.Active)
                {
                    Properties.Settings.Default.ShowNotifyIcon = true;
                    _main.nfiTray.Visible = true;
                }
                else
                {
                    Properties.Settings.Default.ShowNotifyIcon = false;
                    _main.nfiTray.Visible = false;
                }
                Properties.Settings.Default.StartMinimized = tbtnStartMinimized.ToggleState == ToggleButtonState.Active;
                Properties.Settings.Default.ShowAdminWarning = tbtnAdminWarning.ToggleState == ToggleButtonState.Active;

                Properties.Settings.Default.MetroColor = cpbThemeStyle.SelectedColor;
                Properties.Settings.Default.RememberFormSize = tbtnFormSize.ToggleState == ToggleButtonState.Active;
                Properties.Settings.Default.ViewDetails = tbtnDetails.ToggleState == ToggleButtonState.Active;

                _main.LoadTheme();
                LoadTheme();

                Properties.Settings.Default.Language = cboLanguage.SelectedIndex;
                Properties.Settings.Default.LanguagePath = txtLanguagePath.Text;

                _main.LanguageSwitch();
                LoadLanguage();

                List<string> args = new List<string>();

                if (_originalStartup != (tbtnAutoRun.ToggleState == ToggleButtonState.Active))
                {
                    _originalStartup = tbtnAutoRun.ToggleState == ToggleButtonState.Active;
                    args.Add(_originalStartup ? "0" : "1");
                }

                if (_originalIntegration != (tbtnWindowsExplorerIntegration.ToggleState == ToggleButtonState.Active))
                {
                    _originalIntegration = tbtnWindowsExplorerIntegration.ToggleState == ToggleButtonState.Active;
                    args.Add(_originalIntegration ? "2" : "3");
                }
                if (args.Count != 0)
                {
                    args.Add("\"" + Application.ExecutablePath + "\"");
                    StartRegManager(args);
                }
                Properties.Settings.Default.TakeOwnership = tbtnOwnership.ToggleState == ToggleButtonState.Active;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Start the RegManager with a list of arguments.
        /// </summary>
        /// <param name="args">A list of arguments.</param>
        private static void StartRegManager(IEnumerable<string> args)
        {
            string a = string.Join(" ", args);
            Process process = new Process
            {
                StartInfo =
                        {
                            FileName = Application.StartupPath + "\\RegManager.exe",
                            Arguments = a,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
            };
            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// Change the GUI to match the theme.
        /// </summary>
        private void LoadTheme()
        {
            try
            {
                btnClose.MetroColor = Properties.Settings.Default.MetroColor;
                btnReset.MetroColor = Properties.Settings.Default.MetroColor;
                btnSave.MetroColor = Properties.Settings.Default.MetroColor;

                tbcPanels.FixedSingleBorderColor = Properties.Settings.Default.MetroColor;
                tbcPanels.ActiveTabColor = Properties.Settings.Default.MetroColor;
                
                cboLanguage.MetroColor = Properties.Settings.Default.MetroColor;
                btnSelectPath.MetroColor = Properties.Settings.Default.MetroColor;
                txtLanguagePath.Metrocolor = Properties.Settings.Default.MetroColor;

                tbtnAutoUpdate.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnAutoUpdate.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnNotifyIcon.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnNotifyIcon.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnStartMinimized.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnStartMinimized.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnAdminWarning.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnAdminWarning.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnFormSize.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnFormSize.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnDetails.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnDetails.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnAutoRun.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnAutoRun.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnWindowsExplorerIntegration.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnWindowsExplorerIntegration.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;

                tbtnOwnership.ActiveState.BackColor = Properties.Settings.Default.MetroColor;
                tbtnOwnership.ActiveState.HoverColor = Properties.Settings.Default.MetroColor;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadTheme();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> args = new List<string>();
                if (WindowsExplorerIntegration())
                {
                    args.Add("3");
                }
                if (AutoStartUp())
                {
                    args.Add("1");
                }
                if (args.Count != 0)
                {
                    StartRegManager(args);
                }

                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                _main.LoadTheme();
                LoadTheme();
                _main.LanguageSwitch();
                LoadLanguage();
                LoadSettings();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            cboLanguage.SelectedIndex = cboLanguage.Items.Count - 1;
            OpenFileDialog ofd = new OpenFileDialog { Filter = @"XML (*.xml)|*.xml" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtLanguagePath.Text = ofd.FileName;
            }
        }
    }
}
