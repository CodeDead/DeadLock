#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace DeadLock.Forms
{
    public partial class FrmUpdater : MetroForm
    {
        private readonly string _downloadLink;
        private readonly WebClient _webClient;

        public FrmUpdater(string link)
        {
            InitializeComponent();
            _downloadLink = link;
            _webClient = new WebClient();

            _webClient.DownloadFileCompleted += Completed;
            _webClient.DownloadProgressChanged += ProgressChanged;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            string extension = _downloadLink.Substring(_downloadLink.Length - 4, 4);
            SaveFileDialog sfd = new SaveFileDialog {Filter = extension.ToUpper() + @" (*" + extension + @")|*" + extension};
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = sfd.FileName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length == 0) return;
            DisableControls();
            _webClient.DownloadFileAsync(new Uri(_downloadLink), txtPath.Text);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pgbDownload.Value = e.ProgressPercentage;
        }

        private void EnableControls()
        {
            txtPath.Enabled = true;
            btnSelectPath.Enabled = true;
            btnUpdate.Enabled = true;
            pgbDownload.Value = 0;
        }

        private void DisableControls()
        {
            txtPath.Enabled = false;
            btnSelectPath.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                EnableControls();
            }
            else if (e.Error != null)
            {
                MessageBoxAdv.Show(e.Error.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableControls();
            }
            else
            {
                try
                {
                    System.Diagnostics.Process.Start(txtPath.Text);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBoxAdv.Show(ex.Message, "DeadLock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _webClient.CancelAsync();
        }
    }
}