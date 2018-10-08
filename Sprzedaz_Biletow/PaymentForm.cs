using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ApplicationDatabase.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf; 
using MessageBox = System.Windows.Forms.MessageBox;

namespace DesktopApplication
{
    public partial class PaymentForm : Form
    {
        private readonly IDataService _dataService;

        public bool CardBool;

        public bool CashBool;

        public bool transferBOOL;
        public string orderNr;
        public string PRODUCTID;
        public string VAT;
        public string Ticket;
        public string CLIENTID;
        public string BRUTTO;
        public string NETTO;
        public string VATAMOUNT;    
        public string clientName;
        public string PaymentType;
        public string Quantity;
        public string productDesc;
        public string z;
        public string activeDate;
        public string validationTime;
        public string komentarz;
        string now3;
        string street;
        string postal_code;
        string city;
        string idTransakcji;
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

        public PaymentForm(IDataService dataService)
        {
            this._dataService = dataService;
            this.InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public string PassValue
        {
            get { return CLIENTID; }
            set { CLIENTID = value; }
        }
        public string PassValue2
        {
            get { return PRODUCTID; }
            set { PRODUCTID = value; }
        }
        public string PassValue3
        {
            get { return VAT; }
            set { VAT = value; }
        }
        public string PassValue4
        {
            get { return Ticket; }
            set { Ticket = value; }
        }
        public string PassValue5
        {
            get { return BRUTTO; }
            set { BRUTTO = value; }
        }
        public string PassValue6
        {
            get { return NETTO; }
            set { NETTO = value; }
        }
        public string PassValue7
        {
            get { return VATAMOUNT; }
            set { VATAMOUNT = value; }
        }
        public string PassValue8
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public string PassValue9
        {
            get { return productDesc; }
            set { productDesc = value; }
        }
        public string PassValue10
        {
            get { return clientName; }
            set { clientName = value; }
        }
        public string PassValue11
        {
            get { return activeDate; }
            set { activeDate = value; }
        }
        public string PassValue12
        {
            get { return validationTime; }
            set { validationTime = value; }
        }
        public string PassValue13
        {
            get { return komentarz; }
            set { komentarz = value; }
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
        public bool CashWasClicked = false;
        public bool CardWasClicked = false;
        public bool TransferWasClicked = false;
        private void Platnosc_Load(object sender, EventArgs e)
        {
            SaleForm sp = new SaleForm(this._dataService);
            //MessageBox.Show(" TICKET:" + Ticket + " ID:" + CLIENTID + " VAT:" + VAT + "STAWKA:" + VATAMOUNT + " BRUTTO:" + BRUTTO + " NETTO:" + NETTO);
        }
        private void Leave_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Przyjeto_Click(object sender, EventArgs e)
        {

        }

        private void txtlbl_Click(object sender, EventArgs e)
        {

        }

        private void YE_Click(object sender, EventArgs e)
        {
            NIEprzyjeto.Visible = false;
            YE.Visible = false;
            Przyjeto.Visible = false;
            confirmlbl.Visible = true;
            NIEprzyjeto2.Visible = true;
            YE2.Visible = true;
        }

        private void NIEprzyjeto_Click(object sender, EventArgs e)
        {
            txtlbl.Visible = true;
            Transfer.Visible = true;
            Cash.Visible = true;
            NIEprzyjeto.Visible = false;
            YE.Visible = false;
            Przyjeto.Visible = false;
            CARD.Visible = true;
            CardWasClicked = false;
            CashWasClicked = false;
            TransferWasClicked = false;
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            TransferWasClicked = true;
            txtlbl.Visible = false;
            Transfer.Visible = false;
            Cash.Visible = false;
            NIEprzyjeto.Visible = true;
            YE.Visible = true;
            Przyjeto.Visible = true;
            CARD.Visible = false;
            this.CashBool = false;
            this.CardBool = false;
            transferBOOL = true;
        }

        private void CARD_Click(object sender, EventArgs e)
        {
            CardWasClicked = true;
            txtlbl.Visible = false;
            Transfer.Visible = false;
            Cash.Visible = false;
            NIEprzyjeto.Visible = true;
            YE.Visible = true;
            Przyjeto.Visible = true;
            CARD.Visible = false;
            this.CashBool = false;
            this.CardBool = true;
            transferBOOL = false;
        }
        private void Cash_Click(object sender, EventArgs e)
        {
            CashWasClicked = true;
            txtlbl.Visible = false;
            Transfer.Visible = false;
            Cash.Visible = false;
            NIEprzyjeto.Visible = true;
            YE.Visible = true;
            Przyjeto.Visible = true;
            CARD.Visible = false;
            this.CashBool = true;
            this.CardBool = false;
            transferBOOL = false;
        }

        private void confirmlbl_Click(object sender, EventArgs e)
        {
        }
        /*
        *
        Metoda definująca typ płatności.
        */
        public void TypPlatnosci()
        {
            if (this.CashWasClicked == true)
            {
                this.PaymentType = "Gotówka";
            }
            else if (this.TransferWasClicked == true)
            {
                this.PaymentType = "Przelew";
            }
            else if (this.CardWasClicked == true)
            {
                this.PaymentType = "Karta";
            }
        }

        /*
        *
        Metoda zatwierdzająca ostatecznie płatność, zostaje wprowadzana do bazy danych z wszelkimi danymi, które zostały uprzednio wprowadzone.
        */
        private void YE2_Click(object sender, EventArgs e)
        {
            now3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            TypPlatnosci();
            string bruttoAmount = (BRUTTO).Replace(",", ".");
            string nettoAmount = (NETTO).Replace(",", ".");
            string AmountVat = (VATAMOUNT).Replace(",", ".");
            string POK = "POK";
            var user = this._dataService.GetPokInformation(LoginForm.sendtext);
            this._dataService.ConfirmPurchase(PRODUCTID, Ticket, Quantity, bruttoAmount, nettoAmount, AmountVat, CLIENTID, PaymentType, user.FirstOrDefault().UserName, now3, activeDate, validationTime);
            MessageBox.Show("Tansakcja zatwierdzona.");
            YE2.Visible = false;
            NIEprzyjeto2.Visible = false;
            BillBN.Visible = true;
            InvoiceBN.Visible = true;
            nipTXT.Visible = true;
        }

        private void NIEprzyjeto2_Click(object sender, EventArgs e)
        {
            NIEprzyjeto.Visible = true;
            YE.Visible = true;
            Przyjeto.Visible = true;
            confirmlbl.Visible = false;
            NIEprzyjeto2.Visible = false;
            YE2.Visible = false;
            nipTXT.Visible = false;
        }   

        /*
        *
        Metoda odpowiedzialna. za tworzenie paragonu.
        */
        public void Bill()
        {
            var pokUserInfo = this._dataService.GetPokInformation(LoginForm.sendtext);
            orderNr = this._dataService.GetTransactionId();
            string path = Directory.GetCurrentDirectory();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string now2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            iTextSharp.text.Font x = FontFactory.GetFont("HELVETICA_BOLD", 17);
            System.Windows.Shapes.Rectangle ee = new System.Windows.Shapes.Rectangle();
            var pdfDoc = new Document(new iTextSharp.text.Rectangle(200f, 390f));
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = desktop + "\\PAR_NR_" + orderNr + ".pdf";
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.OpenOrCreate));
                pdfDoc.Open();
                pdfDoc.Add(new Paragraph("       Smart Sell", x));
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(path + "\\logo.png");
                image.ScalePercent(22f);
                image.SetAbsolutePosition(25, 315);
                pdfDoc.Add(image);
                PdfContentByte cb = writer.DirectContent;

                cb.SaveState();
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 9f);
                cb.BeginText();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Zarząd Transportu Miejskiego", 105, 311, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ul. Dembowskiego 17", 105, 300, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "36-100 Kolbuszowa", 101, 288, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "PARAGON NIEFISKALNY", 100, 20, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ODBIORCA :", 8, 218, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ID KLIENTA :", 8, 208, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NR TRANSAKCJI :", 8, 198, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, clientName, 88, 218, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ilość :" + Quantity, 8, 145, 0);
                if (Convert.ToInt64(CLIENTID) < 10)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "00" + CLIENTID, 88, 208, 0);
                }
                else if (Convert.ToInt64(CLIENTID) >= 10)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0" + CLIENTID, 88, 208, 0);
                }
                if (Convert.ToInt64(orderNr) < 10)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "00" + orderNr, 88, 198, 0);
                }
                else if (Convert.ToInt64(orderNr) >= 10)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0" + orderNr, 88, 198, 0);
                }
                cb.EndText();
                cb.RestoreState();

                PdfContentByte cb2 = writer.DirectContent;
                cb2.SaveState();
                cb2.SetColorFill(BaseColor.BLACK);
                cb2.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f);
                cb2.BeginText();
                cb2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIP :", 17, 271, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PUNKT SPRZEDAŻY :", 9, 261, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PRACOWNIK :", 8, 251, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "DATA :", 19, 241, 0);

                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "9283456172", 190, 271, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, pokUserInfo.FirstOrDefault().POK.ToString(), 190, 261, 0);//163
                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, pokUserInfo.FirstOrDefault().Name + " " + pokUserInfo.FirstOrDefault().Surname, 190, 251, 0);//142
                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, now2, 190, 241, 0);

                cb2.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NETTO :", 8, 75, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "VAT :", 8, 65, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, VATAMOUNT + " %", 50, 65, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TYP PŁATNOŚCI :", 8, 50, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "zł  " + NETTO, 190, 75, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "zł  " + VAT, 190, 65, 0);
                if (this.CardBool == true)
                {
                    cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Karta", 190, 50, 0);
                }
                else if (this.CashBool == true)
                {
                    cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Gotówka", 190, 50, 0);
                }
                else if (transferBOOL == true)
                {
                    cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Przelew bankowy", 190, 50, 0);
                }
                ColumnText ct = new ColumnText(cb2);
                Phrase longtxt = new Phrase(productDesc);
                ct.SetSimpleColumn(longtxt, 8, 184, 192, 10, 11, Element.ALIGN_LEFT);
                ct.Go();
                cb2.EndText();
                cb2.RestoreState();

                PdfContentByte cb3 = writer.DirectContent;
                cb3.SaveState();
                cb3.SetColorFill(BaseColor.BLACK);
                cb3.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 9f);
                cb3.BeginText();

                cb3.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Potwierdzenie KP", 100, 228, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DATA WAŻNOŚCI :", 8, 130, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "OD :", 8, 120, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DO :", 8, 110, 0);
                if (activeDate != "")
                {
                    cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, activeDate, 32, 120, 0);//dodac
                }
                else
                {
                    cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BRAK", 32, 120, 0);//dodac
                }
                if (validationTime != "")
                {
                    cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, validationTime, 32, 110, 0);//dodac
                }
                else
                {
                    cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "BRAK", 32, 110, 0);//dodac
                }
                cb3.EndText();
                cb3.RestoreState();

                PdfContentByte cb4 = writer.DirectContent;
                cb4.SaveState();
                cb4.SetColorFill(BaseColor.BLACK);
                cb4.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 12f);
                cb4.BeginText();
                cb4.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUMA :", 8, 85, 0);
                cb4.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "zł  " + BRUTTO, 190, 85, 0);
                cb4.EndText();
                cb4.RestoreState();
                pdfDoc.Close();
            }
        }
        /*
        *
        Metoda odpowiedzialna za tworzenie faktury.
        */
        public void Invoice()
        {
            var pokUserInfo = this._dataService.GetPokInformation(LoginForm.sendtext);    
            string path = Directory.GetCurrentDirectory();
            orderNr = this._dataService.GetTransactionId();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string now2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string now4 = DateTime.Now.ToString("yyyy/MM/dd");
            string now5 = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd HH:mm:ss");

            iTextSharp.text.Font x = FontFactory.GetFont("HELVETICA_BOLD", 17);
            System.Windows.Shapes.Rectangle ee = new System.Windows.Shapes.Rectangle();
            var pdfDoc = new Document(new iTextSharp.text.Rectangle(550f, 440f));
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = desktop + "\\FV_" + pokUserInfo.FirstOrDefault().POK + "_" + orderNr + ".pdf";
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.OpenOrCreate));
                pdfDoc.Open();

                //Ustwienie koloru 
                Color myColor = Color.LightGray;
                string htmlColor = ColorTranslator.ToHtml(myColor);
                PdfPTable table = new PdfPTable(1);
                PdfPCell cell = new PdfPCell(new Paragraph("Faktura FV/" + pokUserInfo.FirstOrDefault().POK + "/" + now4, new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 14f)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER; //| iTextSharp.text.Rectangle.TOP_BORDER;
                cell.BorderWidthBottom = 2f;
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.WidthPercentage = 42;
                table.AddCell(cell);
                pdfDoc.Add(table);

                iTextSharp.text.Font f = new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 15f);
                Chunk c = new Chunk("Oryginał/Kopia", f);
                c.SetBackground(BaseColor.LIGHT_GRAY);
                PdfContentByte cb55 = writer.DirectContent;
                ColumnText ct2 = new ColumnText(cb55);
                ct2.SetSimpleColumn(new Phrase(c),
                                  540, 415, 425, 22, 25, Element.ALIGN_RIGHT | Element.ALIGN_TOP);
                ct2.Go();

                Chunk c1 = new Chunk("Nabywca: ", f);
                c1.SetBackground(BaseColor.LIGHT_GRAY);
                ct2.SetSimpleColumn(new Phrase(c1),
                                  52, 305, 825, 22, 25, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ct2.Go();
                Chunk c2 = new Chunk("Sprzedawca: ", f);
                c2.SetBackground(BaseColor.LIGHT_GRAY);
                ct2.SetSimpleColumn(new Phrase(c2),
                                  272, 305, 825, 22, 25, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ct2.Go();

                iTextSharp.text.Font f2 = new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f);
                Chunk c3 = new Chunk("Podpis osoby uprawnionej do wystawienia faktury", f2);
                c3.SetBackground(BaseColor.LIGHT_GRAY);
                ct2.SetSimpleColumn(new Phrase(c3),
                                  52, 115, 429, 22, 25, Element.ALIGN_LEFT | Element.ALIGN_TOP);
                ct2.Go();

                Chunk c4 = new Chunk("Podpis osoby uprawnionej do otrzymania faktury", f2);
                c4.SetBackground(BaseColor.LIGHT_GRAY);
                ct2.SetSimpleColumn(new Phrase(c4),
                                  315, 115, 820, 22, 25, Element.ALIGN_RIGHT | Element.ALIGN_TOP);
                ct2.Go();
                Chunk c5 = new Chunk("UWAGI:", f);
                c5.SetBackground(BaseColor.LIGHT_GRAY);
                ct2.SetSimpleColumn(new Phrase(c5),
                                  22, 50, 140, 22, 25, Element.ALIGN_LEFT | Element.ALIGN_CENTER);
                ct2.Go();

                PdfContentByte cb = writer.DirectContent;
                cb.SaveState();
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 8f);
                cb.BeginText();

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, komentarz, 138, 27, 0);

                //dane do faktury
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, clientName, 52, 255, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ul. " + street, 52, 240, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, postal_code + " " + city, 52, 225, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Zarząd Transportu Miejskiego", 272, 255, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Dembowskiego 17", 272, 240, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "36-100 Kolbuszowa ", 272, 225, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, now2, 162, 345, 0);//data wystawienia
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, now5, 162, 325, 0);//termin zaplaty
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, now3, 352, 345, 0);//data sprzedazy
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "1 z 1", 322, 305, 0);//strona 
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, nipTXT.Text, 93, 210, 0);//NIP nabywcy
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "00" + CLIENTID, 112, 195, 0);//ID klienta
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "2119743555", 309, 210, 0);//NIP sprzedawcy
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "359369141", 313, 195, 0);// REGON
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pokUserInfo.FirstOrDefault().POK.ToString(), 310, 180, 0);//strona 
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "12 1050 9870 1420 0023 4240 6432", 334, 165, 0);//strona 
                if (this.CardBool == true)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Karta", 352, 325, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 182, 305, 0);
                }
                else if (this.CashBool == true)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Gotówka", 352, 325, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "0", 182, 305, 0);
                }
                else if (transferBOOL == true)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Przelew bankowy", 352, 325, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "10", 182, 305, 0);//termin zaplaty w dniach
                }
                cb.EndText();
                cb.RestoreState();

                PdfContentByte cb3 = writer.DirectContent;
                cb3.SaveState();
                cb3.SetColorFill(BaseColor.BLACK);
                cb3.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 9f);
                cb3.BeginText();

                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ".............................................................................", 52, 60, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "...........................................................................", 503, 60, 0);

                cb3.ShowTextAligned(PdfContentByte.ALIGN_CENTER, pokUserInfo.FirstOrDefault().Name + " " + pokUserInfo.FirstOrDefault().Surname, 150, 67, 0);

                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Data wystawienia: ", 52, 345, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Termin zapłaty: ", 52, 325, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Termin zapłaty (w dniach):    ", 52, 305, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Data sprzedaży: ", 272, 345, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Typ płatności: ", 272, 325, 0);//dodac
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Strona: ", 272, 305, 0);//dodac
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIP: ", 52, 210, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIP: ", 272, 210, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Id klienta: ", 52, 195, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Regon: ", 272, 195, 0);
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "MPS: ", 272, 180, 0);//dodac
                cb3.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Numer konta: ", 272, 165, 0);//dodac
                cb3.EndText();
                cb3.RestoreState();

                PdfContentByte cb2 = writer.DirectContent;
                cb2.SetColorFill(BaseColor.BLACK);
                cb2.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 2f);

                PdfPTable table2 = new PdfPTable(8);
                table2.TotalWidth = 450f;

                //table2.WidthPercentage = 90f;
                int[] firstTablecellwidth = { 3, 6, 20, 8, 8, 8, 8, 8 };
                table2.SetWidths(firstTablecellwidth);

                PdfPCell theCell = new PdfPCell(new Paragraph("Lp.", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 9f)));
                PdfPCell theCell2 = new PdfPCell(new Paragraph("Ilość", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell theCell3 = new PdfPCell(new Paragraph("Nazwa Towaru", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell theCell4 = new PdfPCell(new Paragraph("Id produktu", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell theCell5 = new PdfPCell(new Paragraph("Wartość netto", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell theCell6 = new PdfPCell(new Paragraph("Stawka VAT", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell theCell7 = new PdfPCell(new Paragraph("Kwota VAT", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell theCell8 = new PdfPCell(new Paragraph("Wartość brutto", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 8f)));
                PdfPCell odp1 = new PdfPCell(new Paragraph("1", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp2 = new PdfPCell(new Paragraph(this.Quantity, new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp3 = new PdfPCell(new Paragraph(this.productDesc, new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp4 = new PdfPCell(new Paragraph(this.PRODUCTID, new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp5 = new PdfPCell(new Paragraph(this.NETTO + "zł", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp6 = new PdfPCell(new Paragraph(this.VATAMOUNT + "%", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp7 = new PdfPCell(new Paragraph(this.VAT + "zł", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                PdfPCell odp8 = new PdfPCell(new Paragraph(this.BRUTTO + "zł", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false), 7f)));
                theCell.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                odp1.HorizontalAlignment = Element.ALIGN_CENTER;
                odp2.HorizontalAlignment = Element.ALIGN_CENTER;
                odp3.HorizontalAlignment = Element.ALIGN_CENTER;
                odp4.HorizontalAlignment = Element.ALIGN_CENTER;
                odp5.HorizontalAlignment = Element.ALIGN_CENTER;
                odp6.HorizontalAlignment = Element.ALIGN_CENTER;
                odp7.HorizontalAlignment = Element.ALIGN_CENTER;
                odp8.HorizontalAlignment = Element.ALIGN_CENTER;
                theCell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell2.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell3.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell4.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell5.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell6.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell7.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                theCell8.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                table2.AddCell(theCell);
                table2.AddCell(theCell2);
                table2.AddCell(theCell3);
                table2.AddCell(theCell4);
                table2.AddCell(theCell5);
                table2.AddCell(theCell6);
                table2.AddCell(theCell7);
                table2.AddCell(theCell8);
                table2.AddCell(odp1);
                table2.AddCell(odp2);
                table2.AddCell(odp3);
                table2.AddCell(odp4);
                table2.AddCell(odp5);
                table2.AddCell(odp6);
                table2.AddCell(odp7);
                table2.AddCell(odp8);

                PdfPCell sumUP = new PdfPCell(new Paragraph("Razem:", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 10f)));
                PdfPCell sumUP2 = new PdfPCell(new Paragraph(BRUTTO + "zł", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, false), 9f)));
                sumUP2.HorizontalAlignment = Element.ALIGN_RIGHT;
                sumUP.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml(htmlColor));
                PdfPTable nested = new PdfPTable(2);
                nested.TotalWidth = 450f;
                int[] firstTablecellwidth2 = { 13, 18 };
                nested.SetWidths(firstTablecellwidth2);
                nested.AddCell(sumUP);
                nested.AddCell(sumUP2);
                nested.WriteSelectedRows(0, -1, 52, 127, cb2);
                table2.WriteSelectedRows(0, -1, 52, 158, cb2);
                pdfDoc.Close();
            }
        }
        //System.Diagnostics.Process.Start(path + "\\PAR_NR_" + orderNr + ".pdf");
        private void BillBN_Click(object sender, EventArgs e)
        {
            this.Bill();
        }
        protected void InvoiceBN_Click(object sender, EventArgs e)
        {
            string NIP = nipTXT.Text;
            Regex regex = new Regex(@"^((\d{10})|(\d{3}[- ]\d{3}[- ]\d{2}[- ]\d{2})|(\d{3}[- ]\d{2}[- ]\d{2}[- ]\d{3}))$");
            Match match = regex.Match(NIP);
            if (!match.Success)
            {
                MessageBox.Show("Podany NIP :" + NIP + " jest niepoprawny.");
            }
            else
            {
                Invoice();
                nipTXT.Visible = false;
            }
        }
        private void nipTXT_TextChanged(object sender, EventArgs e)
        {

        }
        private void nipTXT_Enter(object sender, EventArgs e)
        {
            if (nipTXT.Text == "Wprowadź NIP")
            {
                this.nipTXT.Clear();
            }
        }
        private void nipTXT_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nipTXT.Text))
            {
                this.nipTXT.Text = "Wprowadź NIP";
            }
        }

        private void PaymentForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
