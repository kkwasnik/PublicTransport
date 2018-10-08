using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ApplicationDatabase.Interfaces;         

namespace DesktopApplication
{
    public partial class ChangePasswordForm : Form
    {                    
        private readonly IDataService _dataService;                                                                                                  
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private string UserName;

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

        public ChangePasswordForm(IDataService dataService, string login)
        {
            this.UserName = login;
            this.InitializeComponent();
            this._dataService = dataService;
            this.passtxt.PasswordChar = '*';
            this.passtxt.MaxLength = 10;
            this.confirmtxt.PasswordChar = '*';
            this.confirmtxt.MaxLength = 10;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));   
            this.loginlbl.Text = this.loginlbl.Text + this.UserName;
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
        public static string HashPass(string password)
        {
            byte[] HashValue, MessageBytes = new UnicodeEncoding().GetBytes(password);

            SHA512Managed SHhash = new SHA512Managed();

            HashValue = SHhash.ComputeHash(MessageBytes);

            return Convert.ToBase64String(HashValue);
        }

        private void LeaveBN_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void Confirmlbl_Click(object sender, EventArgs e)
        {

        }

        private void labelka_Click(object sender, EventArgs e)
        {

        }
        public void CheckIF2()
        {
            if (passtxt.Text != confirmtxt.Text)
            {
                MessageBox.Show("Podane hasła różnią się.");
                passtxt.Clear();
                confirmtxt.Clear();
            }
            else if (String.IsNullOrEmpty(this.UserName))
            {
                MessageBox.Show("Brak podanego loginu dla konta.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);       
            }
            else if (String.IsNullOrEmpty(passtxt.Text) || String.IsNullOrEmpty(confirmtxt.Text))
            {
                MessageBox.Show("Brak podanego hasła dla konta.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passtxt.Clear();
            }
            else if (passtxt.Text.Length < 5)
            {
                MessageBox.Show("Hasło musi mieć co najmniej 5 znaków.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passtxt.Focus();
            }
            else if (confirmtxt.Text.Length < 5)
            {
                MessageBox.Show("Hasło musi mieć co najmniej 5 znaków.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                confirmtxt.Focus();
            }
            else if (passtxt.Text == confirmtxt.Text)
            {
                ChangePassMethod();
            }
        }
        public void ChangePassMethod()
        {
            bool exists = false;
            DialogResult dialog = MessageBox.Show("Na pewno zmienić hasło dla użytkownika : " + this.UserName + " ?", "Password change", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {     
                this._dataService.ChangePassword(this.UserName, HashPass(passtxt.Text)); 
                 this.Close();;
            }
        }

        private void ChangePassBN_Click(object sender, EventArgs e)
        {
            CheckIF2();
        }        

        private void passtxt_Enter(object sender, EventArgs e)
        {
            passtxt.Focus();
            if (passtxt.Focus())
           { 
                labelka.Visible = true;
                labelka2.Visible = true;
                labelka3.Visible = true;
            }
        }

        private void confirmtxt_Enter(object sender, EventArgs e)
        {
            confirmtxt.Focus();
            if (confirmtxt.Focus())
            {
                labelka.Visible = true;
                labelka2.Visible = true;
                labelka3.Visible = true;
            }
        }

        private void ChangePasswordForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}