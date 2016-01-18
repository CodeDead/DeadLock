#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DeadLock.Classes;
using Syncfusion.Windows.Forms;

namespace DeadLock.Forms
{
    public partial class FrmAbout : MetroForm
    {
        #region Variables
        private readonly Language _language;
        #endregion

        /// <summary>
        /// Generate a new FrmAbout form.
        /// </summary>
        /// <param name="language">The current Language.</param>
        public FrmAbout(Language language)
        {
            InitializeComponent();
            _language = language;

            LoadLanguage();
        }

        /// <summary>
        /// Change the GUI to match the current Language.
        /// </summary>
        private void LoadLanguage()
        {
            Text = "DeadLock - " + _language.BarItemAbout;
            txtAbout.Text = _language.TxtAboutCreated + Environment.NewLine + _language.TxtAboutImages + Environment.NewLine + _language.TxtAboutTheme + Environment.NewLine + Environment.NewLine + _language.TxtAboutCopyright + Environment.NewLine + Environment.NewLine + _language.TxtAboutTranslation + Environment.NewLine + _language.Comment + " - " + _language.Author;
            btnClose.Text = _language.BtnClose;
            btnLicense.Text = _language.BtnLicense;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCodeDead_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://codedead.com/");
            }
            catch (Win32Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\gpl.pdf");
            }
            catch (Win32Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                btnLicense.MetroColor = Properties.Settings.Default.MetroColor;
                btnCodeDead.MetroColor = Properties.Settings.Default.MetroColor;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}