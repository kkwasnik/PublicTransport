using System;
using System.Data;
using System.Linq;
using System.Text;        
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Security.Cryptography; 
using System.Text.RegularExpressions;
using MessageBox = System.Windows.Forms.MessageBox;    
using System.Runtime.InteropServices;
using ApplicationDatabase.Interfaces;   

namespace DesktopApplication
{                                
    public partial class AdminForm : Form
    {
        private readonly IDataService _dataService;    
        public string checkedPOKitem;   
        DataTable dt = new DataTable();       
        int i;   
        Int32 adm;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private string UserName;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
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

        public AdminForm(IDataService dataService)
        {
            this._dataService = dataService;
            this.InitializeComponent();
            this.passtxt.PasswordChar = '*';
            this.passtxt.MaxLength = 10;
            this.confirmtxt.PasswordChar = '*';
            this.confirmtxt.MaxLength = 10;
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
        public string HashPass(string password)
        {
            byte[] HashValue, MessageBytes = new UnicodeEncoding().GetBytes(password);

            SHA512Managed SHhash = new SHA512Managed();

            HashValue = SHhash.ComputeHash(MessageBytes);

            return Convert.ToBase64String(HashValue);
        }   

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

        /*
        *
        Metoda sprawdzająca poprawność wpisanych danych w pola tekstowe za pomocą wyrażeń regularnych.
        *
        */    
        public void CheckIF()
        {
            string email = mailtxt.Text;
            string telefon = phonetxt.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regex2 = new Regex(@"^([0-9]{9})$");
            Match match = regex.Match(email);
            Match match2 = regex2.Match(telefon);

            if (passtxt.Text != confirmtxt.Text)
            {
                MessageBox.Show("Podane hasła różnią się.");
                passtxt.Clear();
                confirmtxt.Clear();
            }
            else if (String.IsNullOrEmpty(logintxt.Text))
            {
                MessageBox.Show("Brak podanego loginu dla konta.", "Bląd", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(nametxt.Text))
            {
                MessageBox.Show("Brak podanego imienia.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nametxt.Clear();
            }
            else if (String.IsNullOrEmpty(surenametxt.Text))
            {
                MessageBox.Show("Brak podanego nazwiska.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                surenametxt.Clear();
            }

            else if (!match.Success)
            {
                MessageBox.Show("Podany adres email :" + email + " jest niepoprawny.");
            }
            else if (!match2.Success)
            {
                MessageBox.Show("Podany telefon :" + telefon + " jest niepoprawny.");
            }
            else if (String.IsNullOrEmpty(passtxt.Text))
            {
                MessageBox.Show("Brak podanego hasła dla konta.", "Bląd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passtxt.Clear();
            }
            else if (passtxt.Text.Length < 5)
            {
                MessageBox.Show(
                    "Hasło musi mieć co najmniej 5 znaków.",
                    "Bląd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                passtxt.Focus();
            }
            else if (confirmtxt.Text.Length < 5)
            {
                MessageBox.Show(
                    "Hasło musi mieć co najmniej 5 znaków.",
                    "Bląd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                confirmtxt.Focus();
            }
            else if (logintxt.Text.Length < 5)
            {
                MessageBox.Show(
                    "Login musi mieć co najmniej 5 znaków.",
                    "Bląd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (passtxt.Text == confirmtxt.Text)
            {

                if (truebox.Checked == false && falsebox.Checked == false)
                {
                    MessageBox.Show("Proszę uzupełnić status konta.");
                }                                               

                var active = truebox.Checked ? 1 : 0;  
                string dt = DateTime.Parse(this.activeFromDate.Value.ToString(CultureInfo.InvariantCulture)).ToString("yyyy-MM-dd HH:mm:ss");
                string endDate = DateTime.Parse(this.activeFromDate.Value.ToString(CultureInfo.InvariantCulture)).AddDays(30).ToString("yyyy-MM-dd HH:mm:ss");
                this._dataService.RegisterOpUser(logintxt.Text, nametxt.Text, surenametxt.Text, phonetxt.Text, mailtxt.Text, HashPass(passtxt.Text), active, dt, endDate, 0, 0);

            }
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            //adm2.Size = new Size(880, 460);
        }

        private void Cennik_Click(object sender, EventArgs e)
        {

        }

        private void AdminReg_Click(object sender, EventArgs e)
        {
            //adm2.Size = new Size(570, 432);
            //adm2.Size = new Size(880, 460);
        }

        private void logintxt_TextChanged(object sender, EventArgs e)
        {
            logintxt.Focus();
            if (logintxt.Focus())
            {
                telefonlab.Visible = false;
            }
        }

        private void passtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void truebox_CheckedChanged(object sender, EventArgs e)
        {
            if (truebox.Checked)
            {
                falsebox.Checked = false;
                activeFromDate.Visible = false;
                Activefrom.Visible = false;
            }
        }

        private void falsebox_CheckedChanged(object sender, EventArgs e)
        {
            if (falsebox.Checked)
            {
                truebox.Checked = false;
                activeFromDate.Visible = true;
                Activefrom.Visible = true;
            }
            if (falsebox.Checked == false)
            {
                activeFromDate.Visible = false;
                Activefrom.Visible = false;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            nametxt.Focus();
            if (nametxt.Focus())
            {
                telefonlab.Visible = false;
            }
        }

        private void surenametxt_TextChanged(object sender, EventArgs e)
        {
            surenametxt.Focus();
            if (surenametxt.Focus())
            {
                telefonlab.Visible = false;
            }
        }

        private void mailtxt_TextChanged(object sender, EventArgs e)
        {
            mailtxt.Focus();
            if (mailtxt.Focus())
            {
                telefonlab.Visible = false;
            }
        }

        private void phonetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            //aby scroll bar był bottom
            //RegistrationRules.SelectionStart = RegistrationRules.Text.Length;
            //RegistrationRules.ScrollToCaret();

            if (rulesTXT.ReachedBottom() && Regulaminbox.Checked == true)
            {
                CheckIF();
                boxNotChecked.Visible = false;
            }
            else
            {
                boxNotChecked.Visible = true;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void telefonlab_Click(object sender, EventArgs e)
        {

        }

        private void AdminShown(object sender, EventArgs e)
        {
            var userList = this._dataService.LoadOpUsers();
            foreach (var item in userList)
            {
                Int32 n = this.GridObslugaKont.Rows.Add();
                this.GridObslugaKont.Rows[n].Cells[0].Value = item.ID.ToString(); //ID - nie wyswietlane
                this.GridObslugaKont.Rows[n].Cells[1].Value = item.UserName;
                this.GridObslugaKont.Rows[n].Cells[2].Value = item.Name;
                this.GridObslugaKont.Rows[n].Cells[3].Value = item.Surname;
                this.GridObslugaKont.Rows[n].Cells[4].Value = item.Email;
                this.GridObslugaKont.Rows[n].Cells[5].Value = item.Phone;
                this.GridObslugaKont.Rows[n].Cells[6].Value = item.StartDate;
                this.GridObslugaKont.Rows[n].Cells[7].Value = item.EndDate;
                this.GridObslugaKont.Rows[n].Cells[9].Value = item.POK;
                if (item.isAdmin.Equals(true))
                {
                    this.GridObslugaKont.Rows[n].Cells[8].Value = ("TAK");
                }
                else if (item.isAdmin.Equals(false))
                {
                    this.GridObslugaKont.Rows[n].Cells[8].Value = ("NIE");
                }
            }
        }

        private void FalsePic_Click(object sender, EventArgs e)
        {

        }

        private void TrueBox1_Click(object sender, EventArgs e)
        {

        }

        /*
        *
        Metoda usuwająca użytkownika z systemu.
        *
        */    
        private void DeleteClick(object sender, EventArgs e)
        {
            string DEL = "delete from `OpUser` where `loid`=?loid;";
            DialogResult dialog = MessageBox.Show(
                @"Czy na pewno usunąć konto użytkownika?",
                @"Usuwanie konta",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (dialog == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(this.UserName))
                {                 
                    MessageBox.Show(@"Proszę zaznaczyć użytkownika do usunięcia.");
                }
                else
                {       
                    this._dataService.DeleteAccount(this.UserName);
                    this.Close();
                }
            }
            else if (dialog == DialogResult.Cancel)
            {
                
            }
        }

        /*
         *
         Metoda aktualizująca dane użytkownika.
        *
        */ 
        private void SaveChanges_Click(object sender, EventArgs e)
        {
            if (ComboAdminBox.SelectedIndex == 0)
            {
                adm = 1;
            }
            else if (ComboAdminBox.SelectedIndex == 1)
            {
                adm = 0;
            }                                                                                                                                                     
            var stDate = DateTime.Parse(startDatePicker.Text);
            var enDate = DateTime.Parse(EndDatePicker.Text);
            DialogResult dialog = MessageBox.Show(
                "Na pewno zaktualizować dane?",
                "Data Update",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            var pok = 1; 
            if (checkPOKBOX.Items[1].ToString().Contains("1"))
            {
                pok = 1;
            }
            else if (checkPOKBOX.Items[2].ToString().Contains("2"))
            {      
                pok = 2;
            }
            else if (checkPOKBOX.Items[2].ToString().Contains("3"))
            {        
                pok = 3;
            }

            if (dialog == DialogResult.OK)
            {
                this._dataService.UpdatePokUserData(this.UserName, emailbltxt.Text, enDate, stDate, pok, adm, phonetextlbl.Text);                    
            }
        }

        private void Obsluga_Konta_Click(object sender, EventArgs e)
        {

        }

        private void emailbltxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void GridObslugaKont_DoubleClick(object sender, EventArgs e)
        {

        }

        private void SelectAllCheckBoxes(bool CheckThem)
        {
            for (int i = 0; i <= (checkPOKBOX.Items.Count - 1); i++)
            {
                if (CheckThem)
                {
                    checkPOKBOX.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    checkPOKBOX.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        /*
        *
        Metoda przechwytująca poprzez jednokrotny klick myszy do pól tekstowych dane użytkownika.
        *
        */

        private void GridObslugaKontCellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i >= 0)
            {
                DataGridViewRow row = GridObslugaKont.Rows[i];
                this.UserName = row.Cells[1].Value.ToString();
                emailbltxt.Text = row.Cells[4].Value.ToString();
                phonetextlbl.Text = row.Cells[5].Value.ToString();
                ComboAdminBox.Text = row.Cells[8].Value.ToString();
                NotVisLoid.Text = row.Cells[0].Value.ToString();
                startDatePicker.Text = row.Cells[6].Value.ToString();
                EndDatePicker.Text = row.Cells[7].Value.ToString();
                if (checkPOKBOX.Items[0].ToString().Contains(row.Cells[9].Value.ToString()))
                {
                    checkPOKBOX.SetItemCheckState(0, CheckState.Checked);
                    checkPOKBOX.SetItemCheckState(1, CheckState.Unchecked);
                    checkPOKBOX.SetItemCheckState(2, CheckState.Unchecked);
                }
                if (checkPOKBOX.Items[1].ToString().Contains(row.Cells[9].Value.ToString()))
                {
                    checkPOKBOX.SetItemCheckState(0, CheckState.Unchecked);
                    checkPOKBOX.SetItemCheckState(1, CheckState.Checked);
                    checkPOKBOX.SetItemCheckState(2, CheckState.Unchecked);
                }
                if (checkPOKBOX.Items[2].ToString().Contains(row.Cells[9].Value.ToString()))
                {
                    checkPOKBOX.SetItemCheckState(0, CheckState.Unchecked);
                    checkPOKBOX.SetItemCheckState(1, CheckState.Unchecked);
                    checkPOKBOX.SetItemCheckState(2, CheckState.Checked);
                }
            }
            else
            {
                MessageBox.Show("Proszę odświeżyć widok.");
            }
        }

        /*
        *
        Odświeżenie danych pobranych do tabeli odnośnie użytkowników systemu.
        *
        */

        private void RefreshClickClick(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            this.GridObslugaKont.Rows.Clear();
            var userList = this._dataService.LoadOpUsers();
            foreach (var item in userList)
            {
                int n = this.GridObslugaKont.Rows.Add();
                this.GridObslugaKont.Rows[n].Cells[0].Value = item.ID.ToString(); //ID - nie wyswietlane
                this.GridObslugaKont.Rows[n].Cells[1].Value = item.UserName;
                this.GridObslugaKont.Rows[n].Cells[2].Value = item.Name;
                this.GridObslugaKont.Rows[n].Cells[3].Value = item.Surname;
                this.GridObslugaKont.Rows[n].Cells[4].Value = item.Email;
                this.GridObslugaKont.Rows[n].Cells[5].Value = item.Phone;
                this.GridObslugaKont.Rows[n].Cells[6].Value = item.StartDate;
                this.GridObslugaKont.Rows[n].Cells[7].Value = item.EndDate;
                this.GridObslugaKont.Rows[n].Cells[9].Value = item.POK;
                if (item.isAdmin.Equals(true))
                {
                    this.GridObslugaKont.Rows[n].Cells[8].Value = ("TAK");
                }
                else if (item.isAdmin.Equals(false))
                {
                    this.GridObslugaKont.Rows[n].Cells[8].Value = ("NIE");
                }
            }

            this.LoginSearch.Text = @"?--Wpisz Login--?";
        }

        private void NotVisLoid_TextChanged(object sender, EventArgs e)
        {

        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void phonetextlbl_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboAdminBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /*
        *
        Metoda wyszukująca danego użytkownika zaczynającego się na podaną literę, lub cyfrę.
        *
        */    
        private void LoginSearchTextChanged(object sender, EventArgs e)
        {
            this.GridObslugaKont.Rows.Clear();
            var userList = this._dataService.SearchOpUsers(this.LoginSearch.Text);
            foreach (var item in userList)
            {
                int n = this.GridObslugaKont.Rows.Add();
                this.GridObslugaKont.Rows[n].Cells[0].Value = item.ID; //ID - nie wyswietlany
                this.GridObslugaKont.Rows[n].Cells[1].Value = item.UserName;  
                this.GridObslugaKont.Rows[n].Cells[2].Value = item.Name;
                this.GridObslugaKont.Rows[n].Cells[3].Value = item.Surname;
                this.GridObslugaKont.Rows[n].Cells[4].Value = item.Email;
                this.GridObslugaKont.Rows[n].Cells[5].Value = item.Phone;
                this.GridObslugaKont.Rows[n].Cells[6].Value = item.StartDate;
                this.GridObslugaKont.Rows[n].Cells[7].Value = item.EndDate;
                this.GridObslugaKont.Rows[n].Cells[9].Value = item.POK;
                if (item.isAdmin.Equals(true))
                {
                    this.GridObslugaKont.Rows[n].Cells[8].Value = ("TAK");
                }
                else if (item.isAdmin.Equals(false))
                {
                    this.GridObslugaKont.Rows[n].Cells[8].Value = ("NIE");
                }
            }
        }

        private void LoginSearch_Enter(object sender, EventArgs e)
        {
            this.LoginSearch.Clear();
            this.GridObslugaKont.Rows.Clear();
        }

        private void PassChange_Click(object sender, EventArgs e)
        {
            ChangePasswordForm f1 = new ChangePasswordForm(this._dataService, this.UserName);
            if (System.Windows.Forms.Application.OpenForms.OfType<ChangePasswordForm>().Count() == 1)
                System.Windows.Forms.Application.OpenForms.OfType<ChangePasswordForm>().First().Close();
            f1.Show();
        }

        private void phonetxt_Enter(object sender, EventArgs e)
        {
            phonetxt.Focus();
            if (phonetxt.Focus())
            {
                telefonlab.Visible = true;
            }
        }

        private void phonetxt_Leave(object sender, EventArgs e)
        {
            telefonlab.Visible = false;
        }

        private void LoginSearch_Leave(object sender, EventArgs e)
        {
            //this.LoginSearch.Text = "?--Wpisz Login--?";
        }

        private void GridObslugaKont_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void AktywneOd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GridObslugaKont_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.i = e.RowIndex;
            if (this.i >= 0)
            {
                DataGridViewRow row = this.GridObslugaKont.Rows[this.i];
                this.emailbltxt.Text = row.Cells[4].Value.ToString();
                this.phonetextlbl.Text = row.Cells[5].Value.ToString();
                this.ComboAdminBox.Text = row.Cells[8].Value.ToString();
                this.NotVisLoid.Text = row.Cells[0].Value.ToString();
                this.startDatePicker.Text = row.Cells[6].Value.ToString();
                this.EndDatePicker.Text = row.Cells[7].Value.ToString();
                if (row.Cells[9].Value.Equals(this.checkPOKBOX.Items[0]))
                {
                    this.checkPOKBOX.SetItemCheckState(0, CheckState.Checked);
                    this.checkPOKBOX.SetItemCheckState(1, CheckState.Unchecked);
                    this.checkPOKBOX.SetItemCheckState(2, CheckState.Unchecked);
                }
                else if (row.Cells[9].Value.Equals(this.checkPOKBOX.Items[1]))
                {
                    this.checkPOKBOX.SetItemCheckState(0, CheckState.Unchecked);
                    this.checkPOKBOX.SetItemCheckState(1, CheckState.Checked);
                    this.checkPOKBOX.SetItemCheckState(2, CheckState.Unchecked);
                }
                else if (row.Cells[9].Value.Equals(this.checkPOKBOX.Items[2]))
                {
                    this.checkPOKBOX.SetItemCheckState(0, CheckState.Unchecked);
                    this.checkPOKBOX.SetItemCheckState(1, CheckState.Unchecked);
                    this.checkPOKBOX.SetItemCheckState(2, CheckState.Checked);
                }
            }
            else
            {
                MessageBox.Show(@"Proszę odświeżyć widok.");
            }
        }

        private void checkPOKBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkPOKBOX.Items.Count; i++)
            {
                if (this.checkPOKBOX.GetItemChecked(i))
                {
                    this.checkedPOKitem = this.checkPOKBOX.GetItemText(i);
                    //next line invalid extension method
                    //checkPOKBOX.Items[i];
                }
            }
        }

        private void checkPOKBOX_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkPOKBOX.Items.Count; ++ix)
                if (ix != e.Index) checkPOKBOX.SetItemChecked(ix, false);
        }

        private void boxNotChecked_Click(object sender, EventArgs e)
        {

        }

        private void rulesTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void rulesTXT_VScroll(object sender, EventArgs e)
        {

        }

        private void Obsluga_Konta_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AdminReg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Informacje_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Cennik_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
/*
    Metoda sprawdzająca czy tekst przy rejestracji został przeczytany,
    czyli musi znajdować się na samym dole.
    */

public static class RichTextBoxExtension
{
    [DllImport("user32")]
    private static extern int GetScrollInfo(IntPtr hwnd, int nBar, ref SCROLLINFO scrollInfo);

    public struct SCROLLINFO
    {
        public int cbSize;

        public int fMask;

        public int min;

        public int max;

        public int nPage;

        public int nPos;

        public int nTrackPos;
    }

    public static bool ReachedBottom(this RichTextBox rtb)
    {
        SCROLLINFO scrollInfo = new SCROLLINFO();
        scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
        //SIF_RANGE = 0x1, SIF_TRACKPOS = 0x10,  SIF_PAGE= 0x2
        scrollInfo.fMask = 0x10 | 0x1 | 0x2;
        GetScrollInfo(rtb.Handle, 1, ref scrollInfo); //nBar = 1 -> VScrollbar
        return scrollInfo.max == scrollInfo.nTrackPos + scrollInfo.nPage;
    }
}