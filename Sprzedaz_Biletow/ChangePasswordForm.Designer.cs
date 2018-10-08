namespace DesktopApplication
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.loginlbl = new System.Windows.Forms.Label();
            this.NewPASSlbl = new System.Windows.Forms.Label();
            this.Confirmlbl = new System.Windows.Forms.Label();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.confirmtxt = new System.Windows.Forms.TextBox();
            this.ChangePassBN = new System.Windows.Forms.Button();
            this.LeaveBN = new System.Windows.Forms.Button();
            this.labelka = new System.Windows.Forms.Label();
            this.labelka2 = new System.Windows.Forms.Label();
            this.labelka3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginlbl
            // 
            this.loginlbl.AutoSize = true;
            this.loginlbl.BackColor = System.Drawing.Color.LightBlue;
            this.loginlbl.Location = new System.Drawing.Point(12, 48);
            this.loginlbl.Name = "loginlbl";
            this.loginlbl.Size = new System.Drawing.Size(160, 13);
            this.loginlbl.TabIndex = 0;
            this.loginlbl.Text = "Zmiana hasła dla użytkownika : ";
            // 
            // NewPASSlbl
            // 
            this.NewPASSlbl.AutoSize = true;
            this.NewPASSlbl.BackColor = System.Drawing.Color.LightBlue;
            this.NewPASSlbl.Location = new System.Drawing.Point(13, 89);
            this.NewPASSlbl.Name = "NewPASSlbl";
            this.NewPASSlbl.Size = new System.Drawing.Size(86, 13);
            this.NewPASSlbl.TabIndex = 1;
            this.NewPASSlbl.Text = "New password : ";
            // 
            // Confirmlbl
            // 
            this.Confirmlbl.AutoSize = true;
            this.Confirmlbl.BackColor = System.Drawing.Color.LightBlue;
            this.Confirmlbl.Location = new System.Drawing.Point(13, 132);
            this.Confirmlbl.Name = "Confirmlbl";
            this.Confirmlbl.Size = new System.Drawing.Size(48, 13);
            this.Confirmlbl.TabIndex = 2;
            this.Confirmlbl.Text = "Confirm :";
            this.Confirmlbl.Click += new System.EventHandler(this.Confirmlbl_Click);
            // 
            // passtxt
            // 
            this.passtxt.Location = new System.Drawing.Point(113, 89);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(100, 20);
            this.passtxt.TabIndex = 12;
            this.passtxt.Enter += new System.EventHandler(this.passtxt_Enter);
            // 
            // confirmtxt
            // 
            this.confirmtxt.Location = new System.Drawing.Point(113, 132);
            this.confirmtxt.Name = "confirmtxt";
            this.confirmtxt.Size = new System.Drawing.Size(100, 20);
            this.confirmtxt.TabIndex = 11;
            this.confirmtxt.Enter += new System.EventHandler(this.confirmtxt_Enter);
            // 
            // ChangePassBN
            // 
            this.ChangePassBN.BackColor = System.Drawing.Color.LightBlue;
            this.ChangePassBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangePassBN.Location = new System.Drawing.Point(27, 251);
            this.ChangePassBN.Name = "ChangePassBN";
            this.ChangePassBN.Size = new System.Drawing.Size(84, 23);
            this.ChangePassBN.TabIndex = 7;
            this.ChangePassBN.Text = "Update pass";
            this.ChangePassBN.UseVisualStyleBackColor = false;
            this.ChangePassBN.Click += new System.EventHandler(this.ChangePassBN_Click);
            // 
            // LeaveBN
            // 
            this.LeaveBN.BackColor = System.Drawing.Color.LightBlue;
            this.LeaveBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaveBN.Location = new System.Drawing.Point(127, 251);
            this.LeaveBN.Name = "LeaveBN";
            this.LeaveBN.Size = new System.Drawing.Size(75, 23);
            this.LeaveBN.TabIndex = 8;
            this.LeaveBN.Text = "Leave";
            this.LeaveBN.UseVisualStyleBackColor = false;
            this.LeaveBN.Click += new System.EventHandler(this.LeaveBN_Click);
            // 
            // labelka
            // 
            this.labelka.AutoSize = true;
            this.labelka.BackColor = System.Drawing.Color.LightBlue;
            this.labelka.Location = new System.Drawing.Point(35, 175);
            this.labelka.Name = "labelka";
            this.labelka.Size = new System.Drawing.Size(195, 13);
            this.labelka.TabIndex = 9;
            this.labelka.Text = "Wszystkie powyższe pola są wymagane";
            this.labelka.Visible = false;
            this.labelka.Click += new System.EventHandler(this.labelka_Click);
            // 
            // labelka2
            // 
            this.labelka2.AutoSize = true;
            this.labelka2.BackColor = System.Drawing.Color.LightBlue;
            this.labelka2.Location = new System.Drawing.Point(86, 188);
            this.labelka2.Name = "labelka2";
            this.labelka2.Size = new System.Drawing.Size(97, 13);
            this.labelka2.TabIndex = 10;
            this.labelka2.Text = "przy zmianie hasła.";
            this.labelka2.Visible = false;
            // 
            // labelka3
            // 
            this.labelka3.AutoSize = true;
            this.labelka3.BackColor = System.Drawing.Color.LightBlue;
            this.labelka3.ForeColor = System.Drawing.Color.Red;
            this.labelka3.Location = new System.Drawing.Point(24, 175);
            this.labelka3.Name = "labelka3";
            this.labelka3.Size = new System.Drawing.Size(11, 13);
            this.labelka3.TabIndex = 14;
            this.labelka3.Text = "*";
            this.labelka3.Visible = false;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(251, 302);
            this.ControlBox = false;
            this.Controls.Add(this.labelka3);
            this.Controls.Add(this.labelka2);
            this.Controls.Add(this.labelka);
            this.Controls.Add(this.LeaveBN);
            this.Controls.Add(this.ChangePassBN);
            this.Controls.Add(this.confirmtxt);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.Confirmlbl);
            this.Controls.Add(this.NewPASSlbl);
            this.Controls.Add(this.loginlbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePass";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangePasswordForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginlbl;
        private System.Windows.Forms.Label NewPASSlbl;
        private System.Windows.Forms.Label Confirmlbl;
        private System.Windows.Forms.TextBox passtxt;
        private System.Windows.Forms.TextBox confirmtxt;
        private System.Windows.Forms.Button ChangePassBN;
        private System.Windows.Forms.Button LeaveBN;
        private System.Windows.Forms.Label labelka;
        private System.Windows.Forms.Label labelka2;
        private System.Windows.Forms.Label labelka3;
    }
}