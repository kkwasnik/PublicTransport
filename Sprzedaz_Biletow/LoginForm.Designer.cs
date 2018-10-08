namespace DesktopApplication
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LoginProgress = new System.Windows.Forms.ProgressBar();
            this.Progressbar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserNameTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.UserNameTextBox, "UserNameTextBox");
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            this.UserNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserNameTextBoxKeyDown);
            this.UserNameTextBox.MouseEnter += new System.EventHandler(this.UserNameTextBox_MouseEnter);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.PasswordTextBox, "PasswordTextBox");
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBoxKeyDown);
            this.PasswordTextBox.MouseEnter += new System.EventHandler(this.PasswordTextBox_MouseEnter);
            // 
            // Login
            // 
            this.Login.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.Login, "Login");
            this.Login.BackColor = System.Drawing.Color.LightBlue;
            this.Login.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Login.Name = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.LoginProgress_Click);
            this.Login.MouseEnter += new System.EventHandler(this.Login_MouseEnter);
            this.Login.MouseLeave += new System.EventHandler(this.Login_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.AutoEllipsis = true;
            this.Exit.BackColor = System.Drawing.Color.LightBlue;
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.Exit, "Exit");
            this.Exit.Name = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.button2_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LoginProgress
            // 
            this.LoginProgress.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.LoginProgress, "LoginProgress");
            this.LoginProgress.MarqueeAnimationSpeed = 150;
            this.LoginProgress.Maximum = 150;
            this.LoginProgress.Name = "LoginProgress";
            this.LoginProgress.Click += new System.EventHandler(this.LoginProgressClick);
            // 
            // Progressbar
            // 
            this.Progressbar.Tick += new System.EventHandler(this.ProgressbarTick);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LoginProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar LoginProgress;
        private System.Windows.Forms.Timer Progressbar;
    }
}

