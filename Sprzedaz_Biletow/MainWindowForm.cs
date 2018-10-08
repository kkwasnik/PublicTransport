using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ApplicationDatabase.DataServices;
using ApplicationDatabase.Interfaces;    

namespace DesktopApplication
{
    public partial class MainWindowForm : Form
    {
        private readonly IDataService _dataService;
        public static string ver = Program.lv;
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

        public MainWindowForm(IDataService dataService)
        {                           
            this.InitializeComponent();
            this._dataService = dataService;
            this.timer1.Start(); 
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
        
        private void MAIN_Load(object sender, EventArgs e)
        {
            this.Versja.Text = ver;
            try
            {
                this.Administracja.Visible = this._dataService.ValidateIfAdmin(LoginForm.sendtext);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm adm = new AdminForm(this._dataService);
            if (Application.OpenForms.OfType<AdminForm>().Count() == 1)
            {
                Application.OpenForms.OfType<AdminForm>().First().Close();
            }

            adm.Show();
        }

        private void Wyloguj_Click(object sender, EventArgs e)
        {
            IDataService _dataService = new DataService();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Hide();
            }

            LoginForm sd = new LoginForm(_dataService);
            sd.Show();
        }  

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.Time_lbl.Text = dateTime.ToString();
        }

        private void Rejestracja_Click(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm(_dataService);
            if (Application.OpenForms.OfType<RegistrationForm>().Count() == 1)
                Application.OpenForms.OfType<RegistrationForm>().First().Close();
            form.Show();
        }       

        private void Konfiguracja_Click(object sender, EventArgs e)
        {

        }
        private void SaleFormButton_Click(object sender, EventArgs e)
        {
            IDataService _dataService = new DataService();
            SaleForm sell = new SaleForm(_dataService);
            if (Application.OpenForms.OfType<SaleForm>().Count() == 1)
                Application.OpenForms.OfType<SaleForm>().First().Close();
            sell.Show();
        }

        private void Administracja_VisibleChanged(object sender, EventArgs e)
        {

        }
        private void Versja_Click(object sender, EventArgs e)
        {

        }

        private void CzasoUmilacz_Click(object sender, EventArgs e)
        {

        }

        private void ReportsBN_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainWindowForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }             

        private void Rejestracja_MouseEnter(object sender, EventArgs e)
        {           
            this.Rejestracja.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Rejestracja_MouseLeave(object sender, EventArgs e)
        {               
            this.Rejestracja.BackColor = Color.LightBlue;
        }

        private void Administracja_MouseEnter(object sender, EventArgs e)
        {
            this.Administracja.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Administracja_MouseLeave(object sender, EventArgs e)
        {
            this.Administracja.BackColor = Color.LightBlue;
        }

        private void ObsKli_MouseLeave(object sender, EventArgs e)
        {
            this.ObsKli.BackColor = Color.LightBlue;
        }

        private void ObsKli_MouseEnter(object sender, EventArgs e)
        {
            this.ObsKli.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Konfiguracja_MouseEnter(object sender, EventArgs e)
        {
            this.Konfiguracja.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Konfiguracja_MouseLeave(object sender, EventArgs e)
        {
            this.Konfiguracja.BackColor = Color.LightBlue;
        }

        private void SaleFormButton_MouseLeave(object sender, EventArgs e)
        {
            this.SaleFormButton.BackColor = Color.LightBlue;
        }

        private void SaleFormButton_MouseEnter(object sender, EventArgs e)
        {
            this.SaleFormButton.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void ReportsBN_MouseLeave(object sender, EventArgs e)
        {
            this.ReportsBN.BackColor = Color.LightBlue;
        }

        private void ReportsBN_MouseEnter(object sender, EventArgs e)
        {
            this.ReportsBN.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Wyloguj_MouseEnter(object sender, EventArgs e)
        {
            this.Wyloguj.BackColor = ColorTranslator.FromHtml("#e68a00");
        }

        private void Wyloguj_MouseLeave(object sender, EventArgs e)
        {                                    
            this.Wyloguj.BackColor = Color.LightBlue;
        }
    }
}