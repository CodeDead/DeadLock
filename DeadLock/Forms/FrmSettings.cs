#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

        private readonly NotifyIcon _nfi;
        private bool _originalIntegration;
        private bool _originalStartup;
        private readonly Language _language;

        public FrmSettings(NotifyIcon nfi, Language l)
        {
            InitializeComponent();
            _nfi = nfi;
            _language = l;

            LoadLanguage();
        }

        private void LoadLanguage()
        {
            Text = @"DeadLock - " + _language.TxtSettings;

            tpaGeneral.Text = _language.LblGeneral;
            tpaAppearance.Text = _language.LblAppearance;
            tpaAdvanced.Text = _language.LblAdvanced;

            lblAutoUpdate.Text = _language.ChbAutoUpdate;
            lblNotifyIcon.Text = _language.ChbShowNotifyIcon;
            lblMinimized.Text = _language.ChbStartMinimized;
            lblAdminWarning.Text = _language.ChbShowAdminWarning;

            lblThemeStyle.Text = _language.LblThemeStyle;
            lblBorderThickness.Text = _language.LblBorderThickness;
            lblFormSize.Text = _language.LblRememberFormSize;
            lblDetails.Text = _language.LblShowDetails;
            lblLanguage.Text = _language.LblLanguage;

            lblAutorun.Text = _language.LblAutoRunDeadLock;
            lblWindowsExplorerIntegration.Text = _language.LblWindowsExplorerIntegration;
            lblOwnership.Text = _language.LblOwnership;

            btnClose.Text = _language.BtnSettingsClose;
            btnReset.Text = _language.BtnReset;
            btnSave.Text = _language.BtnSave;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

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

                tbtnWindowsExplorerIntegration.ToggleState = ExplorerIntegration() ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                _originalIntegration = tbtnWindowsExplorerIntegration.ToggleState == ToggleButtonState.Active;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool AutoStartUp()
        {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "DeadLock", "").ToString() == Application.ExecutablePath;
        }

        private static bool ExplorerIntegration()
        {
            bool fileExplorerIntegration = false;
            bool folderExplorerIntegration = false;
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"*\shell\DeadLock\command"))
            {
                if (key != null && key.GetValue(@"", "").ToString() == Application.ExecutablePath + " %1")
                {
                    fileExplorerIntegration = true;
                }
            }


            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\DeadLock\command"))
            {
                if (key != null && key.GetValue(@"", "").ToString() == Application.ExecutablePath + " %1")
                {
                    folderExplorerIntegration = true;
                }
            }

            return folderExplorerIntegration && fileExplorerIntegration;
        }

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

                if ((cpbThemeStyle.MetroColor != Properties.Settings.Default.MetroColor) || (Properties.Settings.Default.BorderThickness != (int)itxtBorderThickness.IntegerValue))
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

                if(_originalStartup != (tbtnAutoRun.ToggleState == ToggleButtonState.Active))
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

        private static void StartRegManager(IReadOnlyList<string> args)
        {
            string a = "";
            for (int i = 0; i < args.Count; i++)
            {
                a += args[i];
                if (i != args.Count -1)
                {
                    a += " ";
                }
            }
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

        private void LoadTheme()
        {
            try
            {
                BorderThickness = Properties.Settings.Default.BorderThickness;
                MetroColor = Properties.Settings.Default.MetroColor;
                BorderColor = Properties.Settings.Default.MetroColor;

                btnClose.MetroColor = Properties.Settings.Default.MetroColor;
                btnReset.MetroColor = Properties.Settings.Default.MetroColor;
                btnSave.MetroColor = Properties.Settings.Default.MetroColor;
                tbcPanels.FixedSingleBorderColor = Properties.Settings.Default.MetroColor;
                tbcPanels.ActiveTabColor = Properties.Settings.Default.MetroColor;
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
                if (ExplorerIntegration())
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
            cboLanguage.SelectedIndex = 2;
            OpenFileDialog ofd = new OpenFileDialog {Filter = @"XML (*.xml)|*.xml"};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtLanguagePath.Text = ofd.FileName;
            }
        }
    }
}
