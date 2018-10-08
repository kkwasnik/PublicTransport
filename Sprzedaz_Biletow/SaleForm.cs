using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ApplicationDatabase.Interfaces;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DesktopApplication
{
    public partial class SaleForm : Form
    {    
        private readonly IDataService _dataService;                                                                                          
        string bruttoo;
        string net;
        string vaat;
        string nettoProduktu;
        string vatProduktu;
        public string productID;
        public string type;       
        public bool month = false;
        public bool day7 = false;
        public bool day30 = false;
        public bool year = false;
        public string validTO;
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

        public SaleForm(IDataService dataService)
        {
            this._dataService = dataService;
            this.InitializeComponent();
            this.TicketStartPicker.MinDate = DateTime.Now;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        //Zablokowanie możliwości wyjścia poprzez X
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ClassStyle = 0x200;
                return param;
            }
        }
        private void Exit_SELL_Click(object sender, EventArgs e)
        {
            this.Close();
        }  

        private void ListaProduktów_SelectedIndexChanged(object sender, EventArgs e)
        {
        } 

        /*
        *
        Metoda wyszukująca dany produkt spośród listy produktów zapisanych w bazie
        sortując po typie produktu.
        */
        private void productsearch_TextChanged(object sender, EventArgs e)
        {             
            foreach (var item in ProductList.Items)
            {
                bool found = false;
                foreach (var itemToverify in ((ListViewItem)item).SubItems)
                {
                    if (((ListViewItem.ListViewSubItem)itemToverify).Text.Contains(productsearch.Text) && !productsearch.Text.Equals(string.Empty))
                    {
                        found = true;
                    }
                }

                if (found)
                {                  
                    ((ListViewItem)item).Selected = true;
                    ((ListViewItem)item).BackColor = Color.CornflowerBlue;
                    ((ListViewItem)item).ForeColor = Color.White;
                    
                }
                else
                {
                    found = false;
                    ((ListViewItem)item).Selected = false;
                    ((ListViewItem)item).BackColor = Color.White;
                    ((ListViewItem)item).ForeColor = Color.Black;
                }
            }       
        }
        public void SprawdzCzyVAT()
        {

        }
        /*
        *
        Metoda przekazująca produkt do listy produktów do kupienia.
        */
        public void Addbtn_Click(object sender, EventArgs e)
        {
            if (ProductList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nie wybrano produktu!");
            }
            else if (ProductList.SelectedItems.Count != 0)
            {
                string BJ = ProductList.SelectedItems[0].SubItems[3].Text;
                type = ProductList.SelectedItems[0].SubItems[1].Text;
                if (VATbox.SelectedValue == null)
                {
                    Needed.Visible = true;
                    VATbox.Focus();
                }
                if (VATbox.SelectedItem != null)
                {
                    if (BJ.Equals("BJ"))//Bilet Jednorazowy
                    {
                        Needed.Visible = false;
                        string ticketCounter = Convert.ToString(IloscBiletow.Value);
                        ListViewItem itemClone;
                        foreach (System.Windows.Forms.ListViewItem item in ProductList.SelectedItems)
                        {
                            itemClone = item.Clone() as System.Windows.Forms.ListViewItem;
                            ProductsToSell.Items.Add(itemClone);
                            itemClone.SubItems.Add((ticketCounter));
                        }
                        Counter();
                        Addbtn.Visible = false;
                    }
                    else
                    {
                        productID = ProductList.SelectedItems[0].SubItems[0].Text;
                        if (type.Equals("7DI"))//7 - NDAY TICKET
                        {
                            TicketActivePanel.Visible = true;
                            day7 = true;
                        }
                        else if (type.Equals("30DI"))//30 - NDAY TICKET
                        {
                            TicketActivePanel.Visible = true;
                            day30 = true;
                        }
                        else if (type.Equals("1Y"))//YEAR TICKET
                        {
                            year = true;
                            TicketActivePanel.Visible = true;
                        }
                        else if (type.Equals("MONTH"))//NMONTH TICKET
                        {
                            month = true;
                            TicketActivePanel.Visible = true;
                        }
                        else
                        {
                            day30 = true;
                            day7 = false;
                            year = false;
                            month = false;
                            TicketActivePanel.Visible = false;
                        }

                        IloscBiletow.Value = 1;
                        Needed.Visible = false;
                        //przekazanie z jednej listview do następnej.
                        //int b = 1;                                      
                        ListViewItem itemClone;
                        foreach (ListViewItem item in ProductList.SelectedItems)
                        {
                            itemClone = item.Clone() as ListViewItem;
                            //ListaProduktów.Items.Remove(item);
                            ProductsToSell.Items.Add(itemClone);
                            itemClone.SubItems.Add((IloscBiletow.Value.ToString(CultureInfo.InvariantCulture)));
                        }
                        //IloscBiletow.Value = b;
                        Counter();
                        Addbtn.Visible = false;
                    }
                }
                IloscBiletow.Visible = false;
                Quantity.Visible = false;
                IloscBiletow.Value = 1;
            }
        }

        /*
        *
        Metoda kalkulująca kwoty brutto,netto oraz vat w zależności od wybranego produktu,
        oraz stawki VAT.
        */
        public void Counter()
        {                                   
            var sum = this.ProductsToSell.Items
              .Cast<ListViewItem>()
              .Sum(item => double.Parse(item.SubItems[4].Text) * (double)IloscBiletow.Value);
            bruttoo = sum.ToString();
            BRUTTO.Text = "    " + bruttoo + " PLN";

            //zliczanie VATU z BJ. 
            var abc = Math.Round(CalculateVat(sum), 2, MidpointRounding.AwayFromZero);
            vaat = abc.ToString();
            VATAMOUNT.Text = "    " + vaat + " PLN";
            //Wartość netto z BJ.
            var netAmount = Math.Round((sum - abc), 2, MidpointRounding.AwayFromZero);
            net = netAmount.ToString();
            NETAmount.Text = "    " + net + " PLN";

            //zliczanie VATU bez BJ. 
            var suma = this.ProductsToSell.Items
             .Cast<System.Windows.Forms.ListViewItem>()
             .Sum(item => double.Parse(item.SubItems[4].Text));
            var abc2 = Math.Round(CalculateVat(suma), 2, MidpointRounding.AwayFromZero);
            vatProduktu = abc2.ToString();
            //Wartość netto bez BJ.
            double netAmount2 = Math.Round((suma - abc2), 2, MidpointRounding.AwayFromZero);
            nettoProduktu = netAmount2.ToString(CultureInfo.InvariantCulture);
        }
        /*
        *
        Metoda wyliczająca VAT.
        */
        public double CalculateVat(double value)
        {
            string selected = this.VATbox.GetItemText(this.VATbox.SelectedItem);
            double abc = Convert.ToDouble(selected);
            return (value * abc) / (100 + abc);
        } 

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void VATbox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /*
        *
        Metoda zatwierdzająca płatność, po zakupione dane przekazywane są do klasy Platnosc.
        */
        public void Buy_Click(object sender, EventArgs e)
        {
            if (selectedusrTXT.Text.Length == 0)
            {
                MessageBox.Show("Nie wybrano klienta!");
                ClientsData.Focus();
            }
            else if (ProductsToSell.Items.Count == 0)
            {
                ProductList.Focus();
                MessageBox.Show("Nie wybrano Produktu!");
            }
            else if (ProductsToSell.Items.Count == 1)
            {
                DialogResult dialog = MessageBox.Show("Przejść do zatwierdzania transakcji dla klienta :" + selectedusrTXT.Text + "?", "Potwierdzenie transakcji", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    PaymentForm pla = new PaymentForm(_dataService);
                    if (Application.OpenForms.OfType<PaymentForm>().Count() == 1)
                        Application.OpenForms.OfType<PaymentForm>().First().Close();
                    pla.PassValue = CLIENTIDTXT.Text;
                    var cl = ProductsToSell.Items[0].SubItems[0].Text;
                    var productDesc = ProductsToSell.Items[0].SubItems[3].Text;
                    var cl1 = ProductsToSell.Items[0].SubItems[1].Text;
                    //var cl2 = ProductsToSell.Items[0].SubItems[4].Text;//brutto
                    var cl3 = ProductsToSell.Items[0].SubItems[5].Text;
                    //DateTime validTOTIME = TicketStartPicker.Value;
                    string activeFrom;
                    string validation;
                    pla.PassValue2 = cl;
                    pla.PassValue3 = vaat;
                    pla.PassValue4 = cl1;
                    pla.PassValue5 = bruttoo;
                    pla.PassValue6 = net;
                    pla.PassValue7 = VATbox.Text;
                    pla.PassValue8 = cl3;
                    pla.PassValue9 = productDesc;
                    pla.PassValue10 = selectedusrTXT.Text;
                    pla.PassValue13 = Comments.Text;
                    /*
                     * W zależności jaki bilet został wybrany, taka data ważności biletu zostaje dostosowana.
                     * 
                     */
                    if (month == true)
                    {
                        activeFrom = DateTime.Parse(TicketStartPicker.Text).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue11 = activeFrom;
                        validation = DateTime.Parse(TicketStartPicker.Text).AddMonths(1).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue12 = validation;
                    }
                    else if (day7 == true)
                    {
                        activeFrom = DateTime.Parse(TicketStartPicker.Text).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue11 = activeFrom;
                        validation = DateTime.Parse(TicketStartPicker.Text).AddDays(7).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue12 = validation;
                    }
                    else if (day30 == true)
                    {
                        activeFrom = DateTime.Parse(TicketStartPicker.Text).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue11 = activeFrom;
                        validation = DateTime.Parse(TicketStartPicker.Text).AddDays(30).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue12 = validation;
                    }
                    else if (year == true)
                    {
                        activeFrom = DateTime.Parse(TicketStartPicker.Text).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue11 = activeFrom;
                        TicketStartPicker.Value.AddYears(1);
                        validation = DateTime.Parse(TicketStartPicker.Text).AddYears(1).ToString("yyyy-MM-dd HH:mm:ss");
                        pla.PassValue12 = validation;
                    }
                    else
                    {
                        pla.PassValue11 = "";
                        pla.PassValue12 = "";
                    }
                    pla.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Wybierz tylko jeden produkt!");
            }
        }
        /*
        *
        Usunięcie przekazanego biletu z listy produktów do zakupienia.
        */
        private void removeticket_Click(object sender, EventArgs e)
        {
            if (ProductsToSell.SelectedItems.Count == 0)
            {
            }
            else
            {
                ListViewItem itemClone;
                foreach (ListViewItem item in ProductsToSell.SelectedItems)
                {
                    itemClone = item.Clone() as ListViewItem;
                    ProductsToSell.Items.Remove(item);
                    //ListaProduktów.Items.Add(itemClone);
                    TicketActivePanel.Visible = false;
                    TicketStartPicker.Value = System.DateTime.Now;
                }
                Counter();
                Addbtn.Visible = true;
            }
        }

        private void Comment_Click(object sender, EventArgs e)
        {

        }    

        private void Sprzedaz_Shown(object sender, EventArgs e)
        {
            foreach (var product in this._dataService.LoadCustomers())
            {
                ClientsData.Items.Add(product);
            }
            foreach (var product in this._dataService.LoadProducts())
            {
                ProductList.Items.Add(product);
            }
        }
        private void ClientsData_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void IloscBiletow_ValueChanged(object sender, EventArgs e)
        {
        }
        private void ListaProduktów_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ProductList.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
        }
        /*
        *
        Metoda przekazująca do pola tekstowego dane klienta, dla którego dany produkt ma zostać zakupiony.
        */
        private void ClientsData_DoubleClick(object sender, EventArgs e)
        {
            string ID = ClientsData.SelectedItems[0].SubItems[0].Text;
            string name = ClientsData.SelectedItems[0].SubItems[1].Text;
            string surname = ClientsData.SelectedItems[0].SubItems[2].Text;
            selectedusrTXT.Text = name + " " + surname;
            CLIENTIDTXT.Text = ID;
        }
        private void CLIENTIDTXT_TextChanged(object sender, EventArgs e)
        {

        }
        private void selectedusrTXT_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void SurnameSRCH_Enter(object sender, EventArgs e)
        {
            if (SurnameSRCH.Text == "--Wpisz Nazwisko--")
            {
                this.SurnameSRCH.Clear();
            }
        }

        private void productsearch_Enter(object sender, EventArgs e)
        {
            if (productsearch.Text == "--Wpisz Typ biletu--")
            {
                this.productsearch.Clear();
            } 
        }

        private void SurnameSRCH_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SurnameSRCH.Text))
            {
                this.SurnameSRCH.Text = "--Wpisz Nazwisko--";
            }
            if (ClientsData.Items.Count == 0 && SurnameSRCH.Text == "--Wpisz Nazwisko--")
            {                              
                foreach (var product in this._dataService.LoadCustomers())
                {
                    ClientsData.Items.Add(product);
                }
            }
        }
        private void productsearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productsearch.Text))
            {
                this.productsearch.Text = "--Wpisz Typ biletu--";
            }
            else if (ProductList.Items.Count == 0 && productsearch.Text == "--Wpisz Typ biletu--")
            {
                foreach (var product in this._dataService.LoadProducts())
                {
                    ProductList.Items.Add(product);
                }
            }
        }
        private void IloscBiletow_Leave(object sender, EventArgs e)
        {
        }

        private void SurnameSRCH_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ClientsData.Items)
            {
                bool found = false;
                foreach (var itemToverify in ((ListViewItem)item).SubItems)
                {
                    if (((ListViewItem.ListViewSubItem)itemToverify).Text.Contains(SurnameSRCH.Text) && !SurnameSRCH.Text.Equals(string.Empty))
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    ((ListViewItem)item).Selected = true;
                    ((ListViewItem)item).BackColor = Color.CornflowerBlue;
                    ((ListViewItem)item).ForeColor = Color.White;

                }
                else
                {
                    found = false;
                    ((ListViewItem)item).Selected = false;
                    ((ListViewItem)item).BackColor = Color.White;
                    ((ListViewItem)item).ForeColor = Color.Black;
                }
            } 
        }

        private void RefreshClients_Click(object sender, EventArgs e)
        {
            ClientsData.Items.Clear();
        }

        private void RefreshPRoducts_Click(object sender, EventArgs e)
        {
            ProductList.Items.Clear(); 
            foreach (var product in this._dataService.LoadProducts())
            {
                ProductList.Items.Add(product);
            }
        }

        private void BRUTTO_TextChanged(object sender, EventArgs e)
        {

        }
        private void Sprzedaz_Load(object sender, EventArgs e)
        {

        }
        private void VATbox_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        private void VATAMOUNT_TextChanged(object sender, EventArgs e)
        {
        }
        private void NETAmount_TextChanged(object sender, EventArgs e)
        {

        }
        private void ProductsToSell_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }
        private void ListaProduktów_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ProductList.Columns[e.ColumnIndex].Width;
        }
        private void ClientsData_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ClientsData.Columns[e.ColumnIndex].Width;
        }

        private void ProductsToSell_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ProductsToSell.Columns[e.ColumnIndex].Width;
        }
        private void Needed_Click(object sender, EventArgs e)
        {

        }
        private void ListaProduktów_Click(object sender, EventArgs e)
        {
            string BJ = ProductList.SelectedItems[0].SubItems[3].Text;
            if (BJ.Equals("BJ"))
            {
                if (Addbtn.Visible == false)
                {
                    IloscBiletow.Visible = false;
                    Quantity.Visible = false;
                }
                else
                {
                    IloscBiletow.Visible = true;
                    Quantity.Visible = true;
                }
            }
            else
            {
                IloscBiletow.Visible = false;
                Quantity.Visible = false;
            }
        }       

        private void TicketActivePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void TicketStartPicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void Comments_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaleForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}