namespace DesktopApplication
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.passtxt = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.surnametxt = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.ExitReg = new System.Windows.Forms.Button();
            this.surname = new System.Windows.Forms.Label();
            this.mailtxt = new System.Windows.Forms.TextBox();
            this.ReTypePASS = new System.Windows.Forms.Label();
            this.RetypeText = new System.Windows.Forms.TextBox();
            this.Informacja = new System.Windows.Forms.Label();
            this.PESELLBL = new System.Windows.Forms.Label();
            this.peseltxt = new System.Windows.Forms.TextBox();
            this.streettxt = new System.Windows.Forms.TextBox();
            this.Streetlbl = new System.Windows.Forms.Label();
            this.kodpoczt = new System.Windows.Forms.Label();
            this.zipCode = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.TextBox();
            this.AR = new System.Windows.Forms.CheckBox();
            this.AMR = new System.Windows.Forms.CheckBox();
            this.Regulamin = new System.Windows.Forms.Label();
            this.zgodamarklbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passtxt
            // 
            this.passtxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.passtxt.Location = new System.Drawing.Point(151, 97);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(95, 20);
            this.passtxt.TabIndex = 1;
            this.passtxt.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // firstName
            // 
            this.firstName.Cursor = System.Windows.Forms.Cursors.Default;
            this.firstName.Location = new System.Drawing.Point(153, 27);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(118, 20);
            this.firstName.TabIndex = 2;
            this.firstName.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // surnametxt
            // 
            this.surnametxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.surnametxt.Location = new System.Drawing.Point(151, 63);
            this.surnametxt.Name = "surnametxt";
            this.surnametxt.Size = new System.Drawing.Size(117, 20);
            this.surnametxt.TabIndex = 3;
            this.surnametxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.BackColor = System.Drawing.Color.LightBlue;
            this.pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pass.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.pass.Location = new System.Drawing.Point(43, 97);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(44, 15);
            this.pass.TabIndex = 5;
            this.pass.Text = "Hasło :";
            this.pass.Click += new System.EventHandler(this.passtext_Click);
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.BackColor = System.Drawing.Color.LightBlue;
            this.mail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mail.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.mail.Location = new System.Drawing.Point(43, 218);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(76, 15);
            this.mail.TabIndex = 6;
            this.mail.Text = "Adres email :";
            this.mail.Click += new System.EventHandler(this.mailtext_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.LightBlue;
            this.name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.name.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.name.Location = new System.Drawing.Point(44, 32);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(35, 15);
            this.name.TabIndex = 7;
            this.name.Text = "Imię :";
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.LightBlue;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Location = new System.Drawing.Point(94, 413);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(79, 30);
            this.Save.TabIndex = 8;
            this.Save.Text = "Zapisz";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ExitReg
            // 
            this.ExitReg.BackColor = System.Drawing.Color.LightBlue;
            this.ExitReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitReg.Location = new System.Drawing.Point(244, 413);
            this.ExitReg.Name = "ExitReg";
            this.ExitReg.Size = new System.Drawing.Size(79, 30);
            this.ExitReg.TabIndex = 9;
            this.ExitReg.Text = "Wyjdź";
            this.ExitReg.UseVisualStyleBackColor = false;
            this.ExitReg.Click += new System.EventHandler(this.ExitReg_Click);
            // 
            // surname
            // 
            this.surname.AutoSize = true;
            this.surname.BackColor = System.Drawing.Color.LightBlue;
            this.surname.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.surname.Location = new System.Drawing.Point(44, 63);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(58, 15);
            this.surname.TabIndex = 10;
            this.surname.Text = "Nazwisko";
            this.surname.Click += new System.EventHandler(this.surname_Click);
            // 
            // mailtxt
            // 
            this.mailtxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.mailtxt.Location = new System.Drawing.Point(151, 216);
            this.mailtxt.Name = "mailtxt";
            this.mailtxt.Size = new System.Drawing.Size(139, 20);
            this.mailtxt.TabIndex = 11;
            this.mailtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // ReTypePASS
            // 
            this.ReTypePASS.AutoSize = true;
            this.ReTypePASS.BackColor = System.Drawing.Color.LightBlue;
            this.ReTypePASS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReTypePASS.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ReTypePASS.Location = new System.Drawing.Point(43, 137);
            this.ReTypePASS.Name = "ReTypePASS";
            this.ReTypePASS.Size = new System.Drawing.Size(88, 15);
            this.ReTypePASS.TabIndex = 20;
            this.ReTypePASS.Text = "Powtórz hasło :";
            this.ReTypePASS.Click += new System.EventHandler(this.ReTypePASS_Click);
            // 
            // RetypeText
            // 
            this.RetypeText.Cursor = System.Windows.Forms.Cursors.Default;
            this.RetypeText.Location = new System.Drawing.Point(151, 137);
            this.RetypeText.Name = "RetypeText";
            this.RetypeText.Size = new System.Drawing.Size(95, 20);
            this.RetypeText.TabIndex = 21;
            this.RetypeText.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Informacja
            // 
            this.Informacja.AutoSize = true;
            this.Informacja.BackColor = System.Drawing.Color.LightBlue;
            this.Informacja.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Informacja.Location = new System.Drawing.Point(133, 9);
            this.Informacja.Name = "Informacja";
            this.Informacja.Size = new System.Drawing.Size(190, 15);
            this.Informacja.TabIndex = 24;
            this.Informacja.Text = "Proszę wypełnić poniższy formularz.";
            // 
            // PESELLBL
            // 
            this.PESELLBL.AutoSize = true;
            this.PESELLBL.BackColor = System.Drawing.Color.LightBlue;
            this.PESELLBL.Location = new System.Drawing.Point(43, 176);
            this.PESELLBL.Name = "PESELLBL";
            this.PESELLBL.Size = new System.Drawing.Size(47, 13);
            this.PESELLBL.TabIndex = 25;
            this.PESELLBL.Text = "PESEL :";
            // 
            // peseltxt
            // 
            this.peseltxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.peseltxt.Location = new System.Drawing.Point(151, 176);
            this.peseltxt.Name = "peseltxt";
            this.peseltxt.Size = new System.Drawing.Size(138, 20);
            this.peseltxt.TabIndex = 26;
            // 
            // streettxt
            // 
            this.streettxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.streettxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.streettxt.Location = new System.Drawing.Point(244, 343);
            this.streettxt.Name = "streettxt";
            this.streettxt.Size = new System.Drawing.Size(138, 20);
            this.streettxt.TabIndex = 27;
            this.streettxt.TextChanged += new System.EventHandler(this.streettxt_TextChanged);
            // 
            // Streetlbl
            // 
            this.Streetlbl.AutoSize = true;
            this.Streetlbl.BackColor = System.Drawing.Color.LightBlue;
            this.Streetlbl.Location = new System.Drawing.Point(150, 343);
            this.Streetlbl.Name = "Streetlbl";
            this.Streetlbl.Size = new System.Drawing.Size(37, 13);
            this.Streetlbl.TabIndex = 28;
            this.Streetlbl.Text = "Ulica :";
            // 
            // kodpoczt
            // 
            this.kodpoczt.AutoSize = true;
            this.kodpoczt.BackColor = System.Drawing.Color.LightBlue;
            this.kodpoczt.Location = new System.Drawing.Point(150, 309);
            this.kodpoczt.Name = "kodpoczt";
            this.kodpoczt.Size = new System.Drawing.Size(80, 13);
            this.kodpoczt.TabIndex = 29;
            this.kodpoczt.Text = "Kod-pocztowy :";
            // 
            // zipCode
            // 
            this.zipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zipCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.zipCode.Location = new System.Drawing.Point(244, 309);
            this.zipCode.Name = "zipCode";
            this.zipCode.Size = new System.Drawing.Size(57, 20);
            this.zipCode.TabIndex = 30;
            this.zipCode.TextChanged += new System.EventHandler(this.zipCode_TextChanged);
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.BackColor = System.Drawing.Color.LightBlue;
            this.cityLabel.Location = new System.Drawing.Point(43, 259);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(74, 13);
            this.cityLabel.TabIndex = 31;
            this.cityLabel.Text = "Miejscowość :";
            // 
            // city
            // 
            this.city.Cursor = System.Windows.Forms.Cursors.Default;
            this.city.Location = new System.Drawing.Point(151, 259);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(139, 20);
            this.city.TabIndex = 32;
            this.city.TextChanged += new System.EventHandler(this.city_TextChanged);
            // 
            // AR
            // 
            this.AR.AutoSize = true;
            this.AR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AR.Location = new System.Drawing.Point(125, 309);
            this.AR.Name = "AR";
            this.AR.Size = new System.Drawing.Size(13, 12);
            this.AR.TabIndex = 33;
            this.AR.UseVisualStyleBackColor = true;
            // 
            // AMR
            // 
            this.AMR.AutoSize = true;
            this.AMR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AMR.Location = new System.Drawing.Point(125, 343);
            this.AMR.Name = "AMR";
            this.AMR.Size = new System.Drawing.Size(13, 12);
            this.AMR.TabIndex = 34;
            this.AMR.UseVisualStyleBackColor = true;
            // 
            // Regulamin
            // 
            this.Regulamin.AutoSize = true;
            this.Regulamin.BackColor = System.Drawing.Color.LightBlue;
            this.Regulamin.Location = new System.Drawing.Point(6, 309);
            this.Regulamin.Name = "Regulamin";
            this.Regulamin.Size = new System.Drawing.Size(103, 13);
            this.Regulamin.TabIndex = 35;
            this.Regulamin.Text = "Akceptuje regulamin";
            // 
            // zgodamarklbl
            // 
            this.zgodamarklbl.AutoSize = true;
            this.zgodamarklbl.BackColor = System.Drawing.Color.LightBlue;
            this.zgodamarklbl.Location = new System.Drawing.Point(2, 343);
            this.zgodamarklbl.Name = "zgodamarklbl";
            this.zgodamarklbl.Size = new System.Drawing.Size(107, 13);
            this.zgodamarklbl.TabIndex = 36;
            this.zgodamarklbl.Text = "Zgoda marketingowa";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(394, 441);
            this.Controls.Add(this.zgodamarklbl);
            this.Controls.Add(this.Regulamin);
            this.Controls.Add(this.AMR);
            this.Controls.Add(this.AR);
            this.Controls.Add(this.city);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.zipCode);
            this.Controls.Add(this.kodpoczt);
            this.Controls.Add(this.Streetlbl);
            this.Controls.Add(this.streettxt);
            this.Controls.Add(this.peseltxt);
            this.Controls.Add(this.PESELLBL);
            this.Controls.Add(this.Informacja);
            this.Controls.Add(this.RetypeText);
            this.Controls.Add(this.ReTypePASS);
            this.Controls.Add(this.mailtxt);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.ExitReg);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.name);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.surnametxt);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.passtxt);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 480);
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejestracja";
            this.Load += new System.EventHandler(this.Reg_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RegistrationForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox passtxt;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox surnametxt;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button ExitReg;
        private System.Windows.Forms.Label surname;
        private System.Windows.Forms.TextBox mailtxt;
        private System.Windows.Forms.Label ReTypePASS;
        private System.Windows.Forms.TextBox RetypeText;
        private System.Windows.Forms.Label Informacja;
        private System.Windows.Forms.Label PESELLBL;
        private System.Windows.Forms.TextBox peseltxt;
        private System.Windows.Forms.TextBox streettxt;
        private System.Windows.Forms.Label Streetlbl;
        private System.Windows.Forms.Label kodpoczt;
        private System.Windows.Forms.TextBox zipCode;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.CheckBox AR;
        private System.Windows.Forms.CheckBox AMR;
        private System.Windows.Forms.Label Regulamin;
        private System.Windows.Forms.Label zgodamarklbl;
    }
}