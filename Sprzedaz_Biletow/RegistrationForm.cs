using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ApplicationDatabase.Interfaces;

namespace DesktopApplication
{
    public partial class RegistrationForm : Form
    {                                              
        public const int WM_NCLBUTTONDOWN = 0xA1; 
        private readonly IDataService _dataService;
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

        public RegistrationForm(IDataService interfaceData)
        {
            InitializeComponent();
            this._dataService = interfaceData;
            passtxt.PasswordChar = '*';
            passtxt.MaxLength = 10;
            RetypeText.PasswordChar = '*';
            RetypeText.MaxLength = 10;
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
        Metoda szyfrująca hasło za pomocą sha-512.
        *
        */
        public static string HashPass(string password)
        {
            byte[] HashValue, MessageBytes = new UnicodeEncoding().GetBytes(password);

            SHA512Managed SHhash = new SHA512Managed();

            HashValue = SHhash.ComputeHash(MessageBytes);

            return Convert.ToBase64String(HashValue);
        }

        /*
        *
        Metoda tworząca nowego klienta systemu.
        *
        */
        public void RegisterNewClient()
        {                                 
            string EncryptedPass = HashPass(passtxt.Text);                                                                                                                                                                        
            this._dataService.AddNewClient(firstName.Text, surnametxt.Text, EncryptedPass, peseltxt.Text, mailtxt.Text,
                streettxt.Text, zipCode.Text, city.Text, AR.Checked, AMR.Checked);  
            this.Close();
        }    

        private void password_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void name_Click(object sender, EventArgs e)
        {
        
        }

        private void surname_Click(object sender, EventArgs e)
        {
        
        }

        private void mailtext_Click(object sender, EventArgs e)
        {

        }

        private void passtext_Click(object sender, EventArgs e)
        {

        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }  

        /*
        *
        Metoda sprawdzająca poprawność wpisanych danych w pola tekstowe za pomocą wyrażeń regularnych.
        *
        */
        public void CheckIF()
        {
            string email = mailtxt.Text;
            string pesel = peseltxt.Text;
            string postal = zipCode.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regex2 = new Regex(@"^\d{11}$");
            Regex regex3 = new Regex(@"^\d{2}-\d{3}$");
            Match match = regex.Match(email);
            Match match2 = regex2.Match(pesel);
            Match match3 = regex3.Match(postal);

            if (passtxt.Text != RetypeText.Text)
            {
                MessageBox.Show("Podane hasła różnią się.");
                passtxt.Clear();
                RetypeText.Clear();
            }
            else if (!match.Success)
            {
                MessageBox.Show("Podany adres email :" + email + " jest niepoprawny.");
            }
            else if (!match2.Success)
            {
                MessageBox.Show("Podany pesel :" + pesel + " jest niepoprawny.");
            }
            else if (!match3.Success)
            {
                MessageBox.Show("Podany kod-pocztowy :" + postal + " jest niepoprawny.");
            }    
            else if (String.IsNullOrEmpty(firstName.Text))
            {
                MessageBox.Show("Brak podanego imienia.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firstName.Clear();
            }
            else if (String.IsNullOrEmpty(surnametxt.Text))
            {
                MessageBox.Show("Brak podanego nazwiska.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surnametxt.Clear();
            }
            else if (String.IsNullOrEmpty(mailtxt.Text))
            {
                MessageBox.Show("Brak podanego adresu email.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mailtxt.Clear();
            }
            else if (String.IsNullOrEmpty(city.Text))
            {
                MessageBox.Show("Brak podanej miejscowości.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                city.Clear();
            }
            else if (String.IsNullOrEmpty(streettxt.Text))
            {
                MessageBox.Show("Brak podanej ulicy.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                streettxt.Clear();
            }
            else if (String.IsNullOrEmpty(zipCode.Text))
            {
                MessageBox.Show("Brak podanego kodu pocztowego.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                zipCode.Clear();
            }
            else if (String.IsNullOrEmpty(peseltxt.Text))
            {
                MessageBox.Show("Brak podanego numeru pesel.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                peseltxt.Clear();
            }
            else if (String.IsNullOrEmpty(passtxt.Text))
            {
                MessageBox.Show("Brak podanego hasła dla konta.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passtxt.Clear();
            }
            else if (passtxt.Text.Length < 5)
            {
                MessageBox.Show("Hasło musi mieć co najmniej 5 znaków.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passtxt.Focus();
            }
            else if (RetypeText.Text.Length < 5)
            {
                MessageBox.Show("Hasło musi mieć co najmniej 5 znaków.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RetypeText.Focus();
            }  
            else if (passtxt.Text == RetypeText.Text)
            {      
                RegisterNewClient();
            }
   }

        private void Save_Click(object sender, EventArgs e)
        {
            CheckIF();
            //+ po poprawnym utworzeniu smtp wyslac potwierdzenie
        }

        private void ExitReg_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        private void ReTypePASS_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }          

        private void city_TextChanged(object sender, EventArgs e)
        {

        }

        private void zipCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void streettxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
