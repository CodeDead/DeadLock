#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace DeadLock.Forms
{
    public partial class FrmAbout : MetroForm
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCodeDead_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://codedead.com/");
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            try
            {
                BorderThickness = Properties.Settings.Default.BorderThickness;
                MetroColor = Properties.Settings.Default.MetroColor;
                BorderColor = Properties.Settings.Default.MetroColor;

                btnClose.MetroColor = Properties.Settings.Default.MetroColor;
                btnLicense.MetroColor = Properties.Settings.Default.MetroColor;
                btnCodeDead.MetroColor = Properties.Settings.Default.MetroColor;
            }
            catch (Exception ex)
            {
                MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
