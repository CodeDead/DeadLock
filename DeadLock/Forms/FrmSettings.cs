#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace DeadLock.Forms
{
    public partial class FrmSettings : MetroForm
    {

        private NotifyIcon _nfi;
        private MetroForm _frmMain;

        public FrmSettings(NotifyIcon nfi, MetroForm frmMain)
        {
            InitializeComponent();
            _nfi = nfi;
            _frmMain = frmMain;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadSettings()
        {
            try
            {
                tbtnAutoUpdate.ToggleState = Properties.Settings.Default.AutoUpdate ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnNotifyIcon.ToggleState = Properties.Settings.Default.ShowNotifyIcon ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnStartMinimized.ToggleState = Properties.Settings.Default.StartMinimized ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnAdminWarning.ToggleState = Properties.Settings.Default.ShowAdminWarning ? ToggleButtonState.Active : ToggleButtonState.Inactive;

                cpbThemeStyle.SelectedColor = Properties.Settings.Default.MetroColor;
                itxtBorderThickness.IntegerValue = Properties.Settings.Default.BorderThickness;
                tbtnFormSize.ToggleState = Properties.Settings.Default.RememberFormSize ? ToggleButtonState.Active : ToggleButtonState.Inactive;
                tbtnDetails.ToggleState = Properties.Settings.Default.ViewDetails ? ToggleButtonState.Active : ToggleButtonState.Inactive;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    MessageBoxAdv.Show("A restart is required in order to change the appearance.", "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Properties.Settings.Default.MetroColor = cpbThemeStyle.SelectedColor;
                Properties.Settings.Default.BorderThickness = (int)itxtBorderThickness.IntegerValue;
                Properties.Settings.Default.RememberFormSize = tbtnFormSize.ToggleState == ToggleButtonState.Active;
                Properties.Settings.Default.ViewDetails = tbtnDetails.ToggleState == ToggleButtonState.Active;

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
