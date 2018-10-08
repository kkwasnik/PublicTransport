namespace DesktopApplication
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.Administracja = new System.Windows.Forms.Button();
            this.Wyloguj = new System.Windows.Forms.Button();
            this.Time_lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Rejestracja = new System.Windows.Forms.Button();
            this.Konfiguracja = new System.Windows.Forms.Button();
            this.SaleFormButton = new System.Windows.Forms.Button();
            this.Versja = new System.Windows.Forms.Label();
            this.CzasoUmilacz = new System.Windows.Forms.Button();
            this.ReportsBN = new System.Windows.Forms.Button();
            this.ObsKli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Administracja
            // 
            this.Administracja.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.Administracja, "Administracja");
            this.Administracja.Name = "Administracja";
            this.Administracja.UseVisualStyleBackColor = false;
            this.Administracja.VisibleChanged += new System.EventHandler(this.Administracja_VisibleChanged);
            this.Administracja.Click += new System.EventHandler(this.button1_Click);
            this.Administracja.MouseEnter += new System.EventHandler(this.Administracja_MouseEnter);
            this.Administracja.MouseLeave += new System.EventHandler(this.Administracja_MouseLeave);
            // 
            // Wyloguj
            // 
            this.Wyloguj.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.Wyloguj, "Wyloguj");
            this.Wyloguj.Name = "Wyloguj";
            this.Wyloguj.UseVisualStyleBackColor = false;
            this.Wyloguj.Click += new System.EventHandler(this.Wyloguj_Click);
            this.Wyloguj.MouseEnter += new System.EventHandler(this.Wyloguj_MouseEnter);
            this.Wyloguj.MouseLeave += new System.EventHandler(this.Wyloguj_MouseLeave);
            // 
            // Time_lbl
            // 
            resources.ApplyResources(this.Time_lbl, "Time_lbl");
            this.Time_lbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Time_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Time_lbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Time_lbl.ForeColor = System.Drawing.SystemColors.Info;
            this.Time_lbl.Name = "Time_lbl";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Rejestracja
            // 
            this.Rejestracja.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.Rejestracja, "Rejestracja");
            this.Rejestracja.Name = "Rejestracja";
            this.Rejestracja.UseVisualStyleBackColor = false;
            this.Rejestracja.Click += new System.EventHandler(this.Rejestracja_Click);
            this.Rejestracja.MouseEnter += new System.EventHandler(this.Rejestracja_MouseEnter);
            this.Rejestracja.MouseLeave += new System.EventHandler(this.Rejestracja_MouseLeave);
            // 
            // Konfiguracja
            // 
            this.Konfiguracja.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.Konfiguracja, "Konfiguracja");
            this.Konfiguracja.Name = "Konfiguracja";
            this.Konfiguracja.UseVisualStyleBackColor = false;
            this.Konfiguracja.Click += new System.EventHandler(this.Konfiguracja_Click);
            this.Konfiguracja.MouseEnter += new System.EventHandler(this.Konfiguracja_MouseEnter);
            this.Konfiguracja.MouseLeave += new System.EventHandler(this.Konfiguracja_MouseLeave);
            // 
            // SaleFormButton
            // 
            this.SaleFormButton.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.SaleFormButton, "SaleFormButton");
            this.SaleFormButton.Name = "SaleFormButton";
            this.SaleFormButton.UseVisualStyleBackColor = false;
            this.SaleFormButton.Click += new System.EventHandler(this.SaleFormButton_Click);
            this.SaleFormButton.MouseEnter += new System.EventHandler(this.SaleFormButton_MouseEnter);
            this.SaleFormButton.MouseLeave += new System.EventHandler(this.SaleFormButton_MouseLeave);
            // 
            // Versja
            // 
            resources.ApplyResources(this.Versja, "Versja");
            this.Versja.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Versja.Cursor = System.Windows.Forms.Cursors.No;
            this.Versja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Versja.ForeColor = System.Drawing.Color.Crimson;
            this.Versja.Name = "Versja";
            this.Versja.Click += new System.EventHandler(this.Versja_Click);
            // 
            // CzasoUmilacz
            // 
            this.CzasoUmilacz.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.CzasoUmilacz, "CzasoUmilacz");
            this.CzasoUmilacz.ForeColor = System.Drawing.Color.Black;
            this.CzasoUmilacz.Name = "CzasoUmilacz";
            this.CzasoUmilacz.UseVisualStyleBackColor = false;
            this.CzasoUmilacz.Click += new System.EventHandler(this.CzasoUmilacz_Click);
            // 
            // ReportsBN
            // 
            this.ReportsBN.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.ReportsBN, "ReportsBN");
            this.ReportsBN.ForeColor = System.Drawing.Color.Black;
            this.ReportsBN.Name = "ReportsBN";
            this.ReportsBN.UseVisualStyleBackColor = false;
            this.ReportsBN.Click += new System.EventHandler(this.ReportsBN_Click);
            this.ReportsBN.MouseEnter += new System.EventHandler(this.ReportsBN_MouseEnter);
            this.ReportsBN.MouseLeave += new System.EventHandler(this.ReportsBN_MouseLeave);
            // 
            // ObsKli
            // 
            this.ObsKli.BackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.ObsKli, "ObsKli");
            this.ObsKli.Name = "ObsKli";
            this.ObsKli.UseVisualStyleBackColor = false;
            this.ObsKli.Click += new System.EventHandler(this.button1_Click_1);
            this.ObsKli.MouseEnter += new System.EventHandler(this.ObsKli_MouseEnter);
            this.ObsKli.MouseLeave += new System.EventHandler(this.ObsKli_MouseLeave);
            // 
            // MainWindowForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.Controls.Add(this.ObsKli);
            this.Controls.Add(this.ReportsBN);
            this.Controls.Add(this.CzasoUmilacz);
            this.Controls.Add(this.Versja);
            this.Controls.Add(this.SaleFormButton);
            this.Controls.Add(this.Konfiguracja);
            this.Controls.Add(this.Rejestracja);
            this.Controls.Add(this.Time_lbl);
            this.Controls.Add(this.Wyloguj);
            this.Controls.Add(this.Administracja);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindowForm";
            this.Load += new System.EventHandler(this.MAIN_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindowForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Administracja;
        private System.Windows.Forms.Button Wyloguj;
        private System.Windows.Forms.Label Time_lbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Rejestracja;
        private System.Windows.Forms.Button Konfiguracja;
        private System.Windows.Forms.Button SaleFormButton;
        private System.Windows.Forms.Label Versja;
        private System.Windows.Forms.Button CzasoUmilacz;
        private System.Windows.Forms.Button ReportsBN;
        private System.Windows.Forms.Button ObsKli;
    }
}