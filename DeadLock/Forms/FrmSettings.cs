using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DeadLock.Classes;
using Microsoft.Win32;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace DeadLock.Forms
{
    public partial class FrmSettings : MetroForm
    {
        #region Variables
        private readonly NotifyIcon _nfi;
        private bool _originalIntegration;
        private bool _originalStartup;
        private readonly Language _language;
        #endregion

        /// <summary>
        /// Generate a new FrmSettings form.
        /// </summary>
        /// <param name="nfi">The NotifyIcon that is associated with the Main form.</param>
        /// <param name="l">The current Language.</param>
        public FrmSettings(NotifyIcon nfi, Language l)
        {
            InitializeComponent();
            _nfi = nfi;
            _language = l;

            LoadLanguage();
        }

        /// <summary>
        /// Change the GUI to match the current Language.
        /// </summary>
        private void LoadLanguage()
        {
            Text = @"DeadLock - " + _language.BarItemSettings;

            tpaGeneral.Text = _language.LblGeneral;
            tpaAppearance.Text = _language.LblAppearance;
            tpaAdvanced.Text = _language.LblAdvanced;

            //General
            lblAutoUpdate.Text = _language.ChbAutoUpdate;
            lblNotifyIcon.Text = _language.ChbShowNotifyIcon;
            lblMinimized.Text = _language.ChbStartMinimized;
            lblAdminWarning.Text = _language.ChbShowAdminWarning;

            tbtnAutoUpdate.ActiveState.Text = _language.TbtnOn;
            tbtnAutoUpdate.InactiveState.Text = _language.TbtnOff;

            tbtnNotifyIcon.ActiveState.Text = _language.TbtnOn;
            tbtnNotifyIcon.InactiveState.Text = _language.TbtnOff;

            tbtnStartMinimized.ActiveState.Text = _language.TbtnOn;
            tbtnStartMinimized.InactiveState.Text = _language.TbtnOff;

            tbtnAdminWarning.ActiveState.Text = _language.TbtnOn;
            tbtnAdminWarning.InactiveState.Text = _language.TbtnOff;

            //Appearance
            lblThemeStyle.Text = _language.LblThemeStyle;
            lblBorderThickness.Text = _language.LblBorderThickness;
            lblFormSize.Text = _language.LblRememberFormSize;
            lblDetails.Text = _language.LblShowDetails;
            lblLanguage.Text = _language.LblLanguage;

            tbtnFormSize.ActiveState.Text = _language.TbtnOn;
            tbtnFormSize.InactiveState.Text = _language.TbtnOff;

            tbtnDetails.ActiveState.Text = _language.TbtnOn;
            tbtnDetails.InactiveState.Text = _language.TbtnOff;

            //Advanced
            lblAutorun.Text = _language.LblAutoRunDeadLock;
            lblWindowsExplorerIntegration.Text = _language.LblWindowsExplorerIntegration;
            lblOwnership.Text = _language.LblOwnership;

            tbtnAutoRun.ActiveState.Text = _language.TbtnOn;
            tbtnAutoRun.InactiveState.Text = _language.TbtnOff;

            tbtnWindowsExplorerIntegration.ActiveState.Text = _language.TbtnOn;
            tbtnWindowsExplorerIntegration.InactiveState.Text = _language.TbtnOff;

            tbtnOwnership.ActiveState.Text = _language.TbtnOn;
            tbtnOwnership.InactiveState.Text = _language.TbtnOff;

            btnClose.Text = _language.BtnClose;
            btnReset.Text = _language.BtnReset;
            btnSave.Text = _language.BtnSave;
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
                itxtBorderThickness.IntegerValue = Properties.Settings.Default.BorderThickness;
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
                    _nfi.Visible = true;
                }
                else
                {
                    Properties.Settings.Default.ShowNotifyIcon = false;
                    _nfi.Visible = false;
                }
                Properties.Settings.Default.StartMinimized = tbtnStartMinimized.ToggleState == ToggleButtonState.Active;
                Properties.Settings.Default.ShowAdminWarning = tbtnAdminWarning.ToggleState == ToggleButtonState.Active;

                if ((cpbThemeStyle.MetroColor != Properties.Settings.Default.MetroColor) || (Properties.Settings.Default.BorderThickness != (int)itxtBorderThickness.IntegerValue) || (tbtnDetails.ToggleState == ToggleButtonState.Active) != Properties.Settings.Default.ViewDetails || cboLanguage.SelectedIndex != Properties.Settings.Default.Language || txtLanguagePath.Text != Properties.Settings.Default.LanguagePath)
                {
                    MessageBoxAdv.Show(_language.MsgRestartRequired, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Properties.Settings.Default.MetroColor = cpbThemeStyle.SelectedColor;
                Properties.Settings.Default.BorderThickness = (int)itxtBorderThickness.IntegerValue;
                Properties.Settings.Default.RememberFormSize = tbtnFormSize.ToggleState == ToggleButtonState.Active;
                Properties.Settings.Default.ViewDetails = tbtnDetails.ToggleState == ToggleButtonState.Active;

                Properties.Settings.Default.Language = cboLanguage.SelectedIndex;
                Properties.Settings.Default.LanguagePath = txtLanguagePath.Text;

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
        private static void StartRegManager(IReadOnlyList<string> args)
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
                BorderThickness = Properties.Settings.Default.BorderThickness;
                MetroColor = Properties.Settings.Default.MetroColor;
                BorderColor = Properties.Settings.Default.MetroColor;
                CaptionBarColor = Properties.Settings.Default.MetroColor;

                btnClose.MetroColor = Properties.Settings.Default.MetroColor;
                btnReset.MetroColor = Properties.Settings.Default.MetroColor;
                btnSave.MetroColor = Properties.Settings.Default.MetroColor;

                tbcPanels.FixedSingleBorderColor = Properties.Settings.Default.MetroColor;
                tbcPanels.ActiveTabColor = Properties.Settings.Default.MetroColor;

                itxtBorderThickness.Metrocolor = Properties.Settings.Default.MetroColor;
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
                if ((cpbThemeStyle.MetroColor != Properties.Settings.Default.MetroColor) || (Properties.Settings.Default.BorderThickness != (int)itxtBorderThickness.IntegerValue) || (tbtnDetails.ToggleState == ToggleButtonState.Active) != Properties.Settings.Default.ViewDetails || cboLanguage.SelectedIndex != Properties.Settings.Default.Language || txtLanguagePath.Text != Properties.Settings.Default.LanguagePath)
                {
                    MessageBoxAdv.Show(_language.MsgRestartRequired, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
