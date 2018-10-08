namespace AutoUpd
{
    partial class Launcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.LauncherPB = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.TextBox();
            this.BackgroungWorker = new System.ComponentModel.BackgroundWorker();
            this.V = new System.Windows.Forms.Label();
            this.DownloadCompletedtxt = new System.Windows.Forms.TextBox();
            this.Versja = new System.Windows.Forms.Label();
            this.CHCKUPD = new System.Windows.Forms.Label();
            this.WhenStart = new System.Windows.Forms.Timer(this.components);
            this.WaitToUnzip = new System.Windows.Forms.Timer(this.components);
            this.WaitToInstall = new System.Windows.Forms.Timer(this.components);
            this.WaintToRun = new System.Windows.Forms.Timer(this.components);
            this.UpToDateRun = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LauncherPB
            // 
            this.LauncherPB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LauncherPB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.LauncherPB.Location = new System.Drawing.Point(12, 62);
            this.LauncherPB.Name = "LauncherPB";
            this.LauncherPB.Size = new System.Drawing.Size(570, 28);
            this.LauncherPB.TabIndex = 0;
            this.LauncherPB.Click += new System.EventHandler(this.LauncherPB_Click);
            // 
            // lbProgress
            // 
            this.lbProgress.BackColor = System.Drawing.Color.Black;
            this.lbProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbProgress.Enabled = false;
            this.lbProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProgress.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lbProgress.Location = new System.Drawing.Point(258, 37);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.ReadOnly = true;
            this.lbProgress.Size = new System.Drawing.Size(50, 19);
            this.lbProgress.TabIndex = 2;
            this.lbProgress.Text = "       ";
            this.lbProgress.TextChanged += new System.EventHandler(this.lbProgress_TextChanged);
            // 
            // BackgroungWorker
            // 
            this.BackgroungWorker.WorkerReportsProgress = true;
            this.BackgroungWorker.WorkerSupportsCancellation = true;
            this.BackgroungWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroungWorker_DoWork);
            this.BackgroungWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroungWorker_ProgressChanged);
            this.BackgroungWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroungWorker_RunWorkerCompleted);
            // 
            // V
            // 
            this.V.AutoSize = true;
            this.V.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.V.Location = new System.Drawing.Point(221, 7);
            this.V.Name = "V";
            this.V.Size = new System.Drawing.Size(58, 15);
            this.V.TabIndex = 6;
            this.V.Text = "                 ";
            this.V.Click += new System.EventHandler(this.V_Click);
            // 
            // DownloadCompletedtxt
            // 
            this.DownloadCompletedtxt.BackColor = System.Drawing.Color.LimeGreen;
            this.DownloadCompletedtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DownloadCompletedtxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.DownloadCompletedtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadCompletedtxt.Location = new System.Drawing.Point(224, 72);
            this.DownloadCompletedtxt.Name = "DownloadCompletedtxt";
            this.DownloadCompletedtxt.ReadOnly = true;
            this.DownloadCompletedtxt.Size = new System.Drawing.Size(111, 13);
            this.DownloadCompletedtxt.TabIndex = 7;
            this.DownloadCompletedtxt.Text = "Download completed!";
            this.DownloadCompletedtxt.Visible = false;
            this.DownloadCompletedtxt.TextChanged += new System.EventHandler(this.DownloadCompletedtxt_TextChanged);
            // 
            // Versja
            // 
            this.Versja.AutoSize = true;
            this.Versja.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Versja.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Versja.ForeColor = System.Drawing.Color.Red;
            this.Versja.Location = new System.Drawing.Point(491, 9);
            this.Versja.Name = "Versja";
            this.Versja.Size = new System.Drawing.Size(39, 20);
            this.Versja.TabIndex = 12;
            this.Versja.Text = "      ";
            this.Versja.Click += new System.EventHandler(this.Versja_Click);
            // 
            // CHCKUPD
            // 
            this.CHCKUPD.AutoSize = true;
            this.CHCKUPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHCKUPD.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CHCKUPD.Location = new System.Drawing.Point(12, 10);
            this.CHCKUPD.Name = "CHCKUPD";
            this.CHCKUPD.Size = new System.Drawing.Size(23, 16);
            this.CHCKUPD.TabIndex = 13;
            this.CHCKUPD.Text = "     ";
            this.CHCKUPD.Click += new System.EventHandler(this.CHCKUPD_Click);
            // 
            // WhenStart
            // 
            this.WhenStart.Interval = 1200;
            this.WhenStart.Tick += new System.EventHandler(this.WhenStart_Tick);
            // 
            // WaitToUnzip
            // 
            this.WaitToUnzip.Interval = 3000;
            this.WaitToUnzip.Tick += new System.EventHandler(this.WaitToUnzip_Tick);
            // 
            // WaitToInstall
            // 
            this.WaitToInstall.Interval = 2000;
            this.WaitToInstall.Tick += new System.EventHandler(this.WaitToInstall_Tick);
            // 
            // WaintToRun
            // 
            this.WaintToRun.Interval = 1500;
            this.WaintToRun.Tick += new System.EventHandler(this.WaintToRun_Tick);
            // 
            // UpToDateRun
            // 
            this.UpToDateRun.Interval = 1500;
            this.UpToDateRun.Tick += new System.EventHandler(this.UpToDateRun_Tick);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(593, 97);
            this.ControlBox = false;
            this.Controls.Add(this.CHCKUPD);
            this.Controls.Add(this.Versja);
            this.Controls.Add(this.DownloadCompletedtxt);
            this.Controls.Add(this.V);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.LauncherPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.Shown += new System.EventHandler(this.Launcher_Shown);
            this.Enter += new System.EventHandler(this.Launcher_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar LauncherPB;
        private System.Windows.Forms.TextBox lbProgress;
        private System.ComponentModel.BackgroundWorker BackgroungWorker;
        private System.Windows.Forms.Label V;
        private System.Windows.Forms.TextBox DownloadCompletedtxt;
        private System.Windows.Forms.Label Versja;
        private System.Windows.Forms.Label CHCKUPD;
        private System.Windows.Forms.Timer WhenStart;
        private System.Windows.Forms.Timer WaitToUnzip;
        private System.Windows.Forms.Timer WaitToInstall;
        private System.Windows.Forms.Timer WaintToRun;
        private System.Windows.Forms.Timer UpToDateRun;
    }
}