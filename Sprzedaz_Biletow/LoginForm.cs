using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ApplicationDatabase.Interfaces;       

namespace DesktopApplication
{                                             
    public partial class LoginForm : Form
    {
        public static string sendtext = string.Empty;
        private readonly IDataService _dataService;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
                                                                 
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]    
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     
            int nTopRect,   
            int nRightRect,   
            int nBottomRect,  
            int nWidthEllipse, 
            int nHeightEllipse
        );  

        public LoginForm(IDataService interfaceData)
        {
            this.InitializeComponent();   
            this._dataService = interfaceData;
            this.timer1.Start();
            this.Progressbar.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ClassStyle = 0x200;
                return param;
            }
        }

        /*
        *
        Szyfrowanie hasła za pomocą metody SHA512.
        *
        */
        public string HashPass(string password)
        {
            byte[] HashValue, MessageBytes = new UnicodeEncoding().GetBytes(password);

            SHA512Managed SHhash = new SHA512Managed();

            HashValue = SHhash.ComputeHash(MessageBytes);

            return Convert.ToBase64String(HashValue);
        }  

        /*
        *
        Logowanie do aplikacji, sprawdzanie ważności konta.
        *
        */
        public void Logowanie()
        {
            try
            {
                string user = this.UserNameTextBox.Text.ToLowerInvariant();           
                if (this._dataService.EnterApplication(user, this.HashPass(this.PasswordTextBox.Text)))
                {    
                    this.Hide();
                    sendtext = this.UserNameTextBox.Text;
                    MainWindowForm ss = new MainWindowForm(this._dataService);
                    ss.Show();
                }
            }
            catch (Exception ex)
            {                                          
                MessageBox.Show(ex.Message, @"Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }  

        private void button2_Click(object sender, EventArgs e)
        {
            ////MessageBox.Show("   Dziekujemy za skorzystanie z naszych uslug.  ");
            System.Windows.Forms.Application.Exit();
        }

        public void LoginProgress_Click(object sender, EventArgs e)
        {
            this.LoginProgress.Value = 0;
            this.LoginProgress.Enabled = true;
            this.LoginProgress.Visible = true;
            this.Progressbar.Start();
        }    

        private void LoginProgressClick(object sender, EventArgs e)
        {

        }
        /*
        *
        Pasek postępowania podczas logowania do aplikacji.
        *
        */
        private void ProgressbarTick(object sender, EventArgs e)
        {
            this.LoginProgress.Value = Convert.ToInt32(this.LoginProgress.Value) + 10;          
            if (Convert.ToInt32(this.LoginProgress.Value) == 150)
            {
                this.Progressbar.Stop();  
                this.Logowanie();
            }
        }

        private void UserNameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login.PerformClick();                       
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void PasswordTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }   

        private void UserNameTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (this.UserNameTextBox.Text.Contains(@"Username"))
            {
                this.UserNameTextBox.Text = string.Empty;
                this.UserNameTextBox.ForeColor = Color.Black; ;
            }
        }

        private void PasswordTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (this.PasswordTextBox.Text.Contains(@"Password"))
            {
                this.PasswordTextBox.Text = string.Empty;
                this.PasswordTextBox.ForeColor = Color.Black; ;
                this.PasswordTextBox.PasswordChar = '*';
                this.PasswordTextBox.MaxLength = 10;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {                                                    
                this.PasswordTextBox.ForeColor = Color.Black; ;
                this.PasswordTextBox.PasswordChar = '*';
                this.PasswordTextBox.MaxLength = 10;           
        }

        private void Login_MouseEnter(object sender, EventArgs e)
        {                               
            this.Login.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Login_MouseLeave(object sender, EventArgs e)
        {       
            this.Login.BackColor = Color.LightBlue;
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            this.Exit.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {      
            this.Exit.BackColor = Color.LightBlue;
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {      
            this.UserNameTextBox.ForeColor = Color.Black; ;  
            this.UserNameTextBox.MaxLength = 10;
        }
    }
}