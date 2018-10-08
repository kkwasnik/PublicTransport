namespace DesktopApplication
{
    partial class SaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleForm));
            this.Exit_SELL = new System.Windows.Forms.Button();
            this.ProductList = new System.Windows.Forms.ListView();
            this.ProductID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productsearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.Label();
            this.Client = new System.Windows.Forms.Label();
            this.Comments = new System.Windows.Forms.RichTextBox();
            this.Addbtn = new System.Windows.Forms.Button();
            this.ProductsToSell = new System.Windows.Forms.ListView();
            this.ID2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zone2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ilosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Buy = new System.Windows.Forms.Button();
            this.removeticket = new System.Windows.Forms.Button();
            this.Comment = new System.Windows.Forms.Label();
            this.TotalCost = new System.Windows.Forms.Label();
            this.VATlab = new System.Windows.Forms.Label();
            this.VATbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IloscBiletow = new System.Windows.Forms.NumericUpDown();
            this.ClientsData = new System.Windows.Forms.ListView();
            this.ID3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imie3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nazwisko3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SurnameSRCH = new System.Windows.Forms.TextBox();
            this.selectedusrTXT = new System.Windows.Forms.TextBox();
            this.SelectedUSR = new System.Windows.Forms.Label();
            this.BRUTTO = new System.Windows.Forms.TextBox();
            this.VATAMOUNT = new System.Windows.Forms.TextBox();
            this.RefreshClients = new System.Windows.Forms.Button();
            this.RefreshPRoducts = new System.Windows.Forms.Button();
            this.Needed = new System.Windows.Forms.Label();
            this.NETAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CLIENTIDTXT = new System.Windows.Forms.TextBox();
            this.TicketStartPicker = new System.Windows.Forms.DateTimePicker();
            this.TicketActivePanel = new System.Windows.Forms.Panel();
            this.activefromtxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IloscBiletow)).BeginInit();
            this.TicketActivePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit_SELL
            // 
            this.Exit_SELL.BackColor = System.Drawing.Color.LightBlue;
            this.Exit_SELL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_SELL.Location = new System.Drawing.Point(772, 399);
            this.Exit_SELL.Name = "Exit_SELL";
            this.Exit_SELL.Size = new System.Drawing.Size(69, 29);
            this.Exit_SELL.TabIndex = 2;
            this.Exit_SELL.Text = "Wyjdź";
            this.Exit_SELL.UseVisualStyleBackColor = false;
            this.Exit_SELL.Click += new System.EventHandler(this.Exit_SELL_Click);
            // 
            // ListaProduktów
            // 
            this.ProductList.BackColor = System.Drawing.Color.White;
            this.ProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductID,
            this.Description,
            this.Zone,
            this.Type,
            this.Price});
            this.ProductList.FullRowSelect = true;
            this.ProductList.GridLines = true;
            this.ProductList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProductList.Location = new System.Drawing.Point(355, 8);
            this.ProductList.MultiSelect = false;
            this.ProductList.Name = "ProductList";
            this.ProductList.Size = new System.Drawing.Size(486, 164);
            this.ProductList.TabIndex = 10;
            this.ProductList.UseCompatibleStateImageBehavior = false;
            this.ProductList.View = System.Windows.Forms.View.Details;
            this.ProductList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListaProduktów_ColumnClick);
            this.ProductList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListaProduktów_ColumnWidthChanging);
            this.ProductList.SelectedIndexChanged += new System.EventHandler(this.ListaProduktów_SelectedIndexChanged);
            this.ProductList.Click += new System.EventHandler(this.ListaProduktów_Click);
            // 
            // ProductID
            // 
            this.ProductID.Text = "ID produktu";
            this.ProductID.Width = 78;
            // 
            // Description
            // 
            this.Description.Text = "Opis produktu";
            this.Description.Width = 190;
            // 
            // Zone
            // 
            this.Zone.Text = "Strefa";
            // 
            // Type
            // 
            this.Type.Text = "Typ biletu";
            this.Type.Width = 74;
            // 
            // Price
            // 
            this.Price.Text = "Cena";
            // 
            // productsearch
            // 
            this.productsearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.productsearch.Location = new System.Drawing.Point(611, 183);
            this.productsearch.Name = "productsearch";
            this.productsearch.Size = new System.Drawing.Size(155, 20);
            this.productsearch.TabIndex = 11;
            this.productsearch.Text = "--Wpisz Typ biletu--";
            this.productsearch.TextChanged += new System.EventHandler(this.productsearch_TextChanged);
            this.productsearch.Enter += new System.EventHandler(this.productsearch_Enter);
            this.productsearch.Leave += new System.EventHandler(this.productsearch_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(506, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Szukaj Produktu :";
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.BackColor = System.Drawing.Color.LightBlue;
            this.Quantity.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Location = new System.Drawing.Point(352, 183);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(33, 15);
            this.Quantity.TabIndex = 13;
            this.Quantity.Text = "Ilość";
            this.Quantity.Visible = false;
            // 
            // Client
            // 
            this.Client.AutoSize = true;
            this.Client.BackColor = System.Drawing.Color.LightBlue;
            this.Client.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Client.Location = new System.Drawing.Point(19, 9);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(82, 15);
            this.Client.TabIndex = 15;
            this.Client.Text = "Dane Klienta :";
            // 
            // Comments
            // 
            this.Comments.Cursor = System.Windows.Forms.Cursors.Default;
            this.Comments.Location = new System.Drawing.Point(22, 369);
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(170, 59);
            this.Comments.TabIndex = 20;
            this.Comments.Text = "";
            this.Comments.TextChanged += new System.EventHandler(this.Comments_TextChanged);
            // 
            // Addbtn
            // 
            this.Addbtn.BackColor = System.Drawing.Color.LightBlue;
            this.Addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Addbtn.Location = new System.Drawing.Point(772, 183);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(69, 23);
            this.Addbtn.TabIndex = 21;
            this.Addbtn.Text = "Dodaj";
            this.Addbtn.UseVisualStyleBackColor = false;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // ProductsToSell
            // 
            this.ProductsToSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductsToSell.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID2,
            this.Description2,
            this.Zone2,
            this.Type2,
            this.Price2,
            this.Ilosc});
            this.ProductsToSell.FullRowSelect = true;
            this.ProductsToSell.GridLines = true;
            this.ProductsToSell.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProductsToSell.LabelWrap = false;
            this.ProductsToSell.Location = new System.Drawing.Point(22, 204);
            this.ProductsToSell.MultiSelect = false;
            this.ProductsToSell.Name = "ProductsToSell";
            this.ProductsToSell.Size = new System.Drawing.Size(479, 78);
            this.ProductsToSell.TabIndex = 22;
            this.ProductsToSell.UseCompatibleStateImageBehavior = false;
            this.ProductsToSell.View = System.Windows.Forms.View.Details;
            this.ProductsToSell.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ProductsToSell_ColumnWidthChanging);
            this.ProductsToSell.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ProductsToSell_ItemSelectionChanged);
            this.ProductsToSell.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // ID2
            // 
            this.ID2.Text = "ID produktu";
            this.ID2.Width = 81;
            // 
            // Description2
            // 
            this.Description2.Text = "Opis produktu";
            this.Description2.Width = 130;
            // 
            // Zone2
            // 
            this.Zone2.Text = "Strefa";
            this.Zone2.Width = 65;
            // 
            // Type2
            // 
            this.Type2.Text = "Typ biletu";
            this.Type2.Width = 71;
            // 
            // Price2
            // 
            this.Price2.Text = "Cena";
            this.Price2.Width = 68;
            // 
            // Ilosc
            // 
            this.Ilosc.Text = "Ilość";
            // 
            // Buy
            // 
            this.Buy.BackColor = System.Drawing.Color.LightBlue;
            this.Buy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buy.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buy.Location = new System.Drawing.Point(345, 288);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(75, 23);
            this.Buy.TabIndex = 23;
            this.Buy.Text = "Kup";
            this.Buy.UseVisualStyleBackColor = false;
            this.Buy.Click += new System.EventHandler(this.Buy_Click);
            // 
            // removeticket
            // 
            this.removeticket.BackColor = System.Drawing.Color.LightBlue;
            this.removeticket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeticket.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeticket.Location = new System.Drawing.Point(426, 288);
            this.removeticket.Name = "removeticket";
            this.removeticket.Size = new System.Drawing.Size(75, 23);
            this.removeticket.TabIndex = 24;
            this.removeticket.Text = "Usuń bilet";
            this.removeticket.UseVisualStyleBackColor = false;
            this.removeticket.Click += new System.EventHandler(this.removeticket_Click);
            // 
            // Comment
            // 
            this.Comment.AutoSize = true;
            this.Comment.BackColor = System.Drawing.Color.LightBlue;
            this.Comment.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comment.Location = new System.Drawing.Point(19, 337);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(131, 15);
            this.Comment.TabIndex = 25;
            this.Comment.Text = "Komentarz do Faktury :";
            this.Comment.Click += new System.EventHandler(this.Comment_Click);
            // 
            // TotalCost
            // 
            this.TotalCost.AutoSize = true;
            this.TotalCost.BackColor = System.Drawing.Color.LightBlue;
            this.TotalCost.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TotalCost.Location = new System.Drawing.Point(617, 217);
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.Size = new System.Drawing.Size(81, 19);
            this.TotalCost.TabIndex = 26;
            this.TotalCost.Text = " BRUTTO :";
            // 
            // VATlab
            // 
            this.VATlab.AutoSize = true;
            this.VATlab.BackColor = System.Drawing.Color.LightBlue;
            this.VATlab.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VATlab.Location = new System.Drawing.Point(656, 310);
            this.VATlab.Name = "VATlab";
            this.VATlab.Size = new System.Drawing.Size(42, 17);
            this.VATlab.TabIndex = 27;
            this.VATlab.Text = "VAT :";
            // 
            // VATbox
            // 
            this.VATbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VATbox.FormattingEnabled = true;
            this.VATbox.Items.AddRange(new object[] {
            "8",
            "15",
            "23"});
            this.VATbox.Location = new System.Drawing.Point(91, 297);
            this.VATbox.Name = "VATbox";
            this.VATbox.Size = new System.Drawing.Size(48, 22);
            this.VATbox.TabIndex = 28;
            this.VATbox.SelectedIndexChanged += new System.EventHandler(this.VATbox_SelectedIndexChanged);
            this.VATbox.SelectedValueChanged += new System.EventHandler(this.VATbox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "VAT :";
            // 
            // IloscBiletow
            // 
            this.IloscBiletow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IloscBiletow.Location = new System.Drawing.Point(391, 183);
            this.IloscBiletow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IloscBiletow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IloscBiletow.Name = "IloscBiletow";
            this.IloscBiletow.Size = new System.Drawing.Size(55, 16);
            this.IloscBiletow.TabIndex = 30;
            this.IloscBiletow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IloscBiletow.Visible = false;
            this.IloscBiletow.ValueChanged += new System.EventHandler(this.IloscBiletow_ValueChanged);
            this.IloscBiletow.Leave += new System.EventHandler(this.IloscBiletow_Leave);
            // 
            // ClientsData
            // 
            this.ClientsData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID3,
            this.imie3,
            this.Nazwisko3});
            this.ClientsData.FullRowSelect = true;
            this.ClientsData.GridLines = true;
            this.ClientsData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ClientsData.Location = new System.Drawing.Point(20, 27);
            this.ClientsData.MultiSelect = false;
            this.ClientsData.Name = "ClientsData";
            this.ClientsData.Size = new System.Drawing.Size(244, 145);
            this.ClientsData.TabIndex = 32;
            this.ClientsData.UseCompatibleStateImageBehavior = false;
            this.ClientsData.View = System.Windows.Forms.View.Details;
            this.ClientsData.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ClientsData_ColumnWidthChanging);
            this.ClientsData.SelectedIndexChanged += new System.EventHandler(this.ClientsData_SelectedIndexChanged);
            this.ClientsData.DoubleClick += new System.EventHandler(this.ClientsData_DoubleClick);
            // 
            // ID3
            // 
            this.ID3.Text = "ID";
            this.ID3.Width = 41;
            // 
            // imie3
            // 
            this.imie3.Text = "Imię";
            this.imie3.Width = 87;
            // 
            // Nazwisko3
            // 
            this.Nazwisko3.Text = "Nazwisko";
            this.Nazwisko3.Width = 107;
            // 
            // SurnameSRCH
            // 
            this.SurnameSRCH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SurnameSRCH.Cursor = System.Windows.Forms.Cursors.Default;
            this.SurnameSRCH.Location = new System.Drawing.Point(129, 10);
            this.SurnameSRCH.Name = "SurnameSRCH";
            this.SurnameSRCH.Size = new System.Drawing.Size(100, 13);
            this.SurnameSRCH.TabIndex = 33;
            this.SurnameSRCH.Text = "--Wpisz Nazwisko--";
            this.SurnameSRCH.TextChanged += new System.EventHandler(this.SurnameSRCH_TextChanged);
            this.SurnameSRCH.Enter += new System.EventHandler(this.SurnameSRCH_Enter);
            this.SurnameSRCH.Leave += new System.EventHandler(this.SurnameSRCH_Leave);
            // 
            // selectedusrTXT
            // 
            this.selectedusrTXT.BackColor = System.Drawing.Color.Gray;
            this.selectedusrTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedusrTXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectedusrTXT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedusrTXT.ForeColor = System.Drawing.Color.Brown;
            this.selectedusrTXT.Location = new System.Drawing.Point(134, 178);
            this.selectedusrTXT.Name = "selectedusrTXT";
            this.selectedusrTXT.ReadOnly = true;
            this.selectedusrTXT.Size = new System.Drawing.Size(130, 15);
            this.selectedusrTXT.TabIndex = 34;
            this.selectedusrTXT.TextChanged += new System.EventHandler(this.selectedusrTXT_TextChanged);
            // 
            // SelectedUSR
            // 
            this.SelectedUSR.AutoSize = true;
            this.SelectedUSR.BackColor = System.Drawing.Color.LightBlue;
            this.SelectedUSR.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedUSR.Location = new System.Drawing.Point(21, 176);
            this.SelectedUSR.Name = "SelectedUSR";
            this.SelectedUSR.Size = new System.Drawing.Size(88, 15);
            this.SelectedUSR.TabIndex = 35;
            this.SelectedUSR.Text = "Wybrany klient :";
            // 
            // BRUTTO
            // 
            this.BRUTTO.BackColor = System.Drawing.Color.Gray;
            this.BRUTTO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BRUTTO.Cursor = System.Windows.Forms.Cursors.Default;
            this.BRUTTO.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRUTTO.ForeColor = System.Drawing.Color.Brown;
            this.BRUTTO.Location = new System.Drawing.Point(722, 217);
            this.BRUTTO.Name = "BRUTTO";
            this.BRUTTO.ReadOnly = true;
            this.BRUTTO.Size = new System.Drawing.Size(109, 19);
            this.BRUTTO.TabIndex = 37;
            this.BRUTTO.Text = "    0 PLN";
            this.BRUTTO.TextChanged += new System.EventHandler(this.BRUTTO_TextChanged);
            // 
            // VATAMOUNT
            // 
            this.VATAMOUNT.BackColor = System.Drawing.Color.Gray;
            this.VATAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VATAMOUNT.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VATAMOUNT.ForeColor = System.Drawing.Color.Brown;
            this.VATAMOUNT.Location = new System.Drawing.Point(722, 309);
            this.VATAMOUNT.Name = "VATAMOUNT";
            this.VATAMOUNT.ReadOnly = true;
            this.VATAMOUNT.Size = new System.Drawing.Size(109, 18);
            this.VATAMOUNT.TabIndex = 38;
            this.VATAMOUNT.Text = "    0 PLN";
            this.VATAMOUNT.TextChanged += new System.EventHandler(this.VATAMOUNT_TextChanged);
            // 
            // RefreshClients
            // 
            this.RefreshClients.BackColor = System.Drawing.Color.LightBlue;
            this.RefreshClients.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RefreshClients.BackgroundImage")));
            this.RefreshClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshClients.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshClients.Location = new System.Drawing.Point(244, 3);
            this.RefreshClients.Name = "RefreshClients";
            this.RefreshClients.Size = new System.Drawing.Size(20, 21);
            this.RefreshClients.TabIndex = 39;
            this.RefreshClients.UseVisualStyleBackColor = false;
            this.RefreshClients.Click += new System.EventHandler(this.RefreshClients_Click);
            // 
            // RefreshPRoducts
            // 
            this.RefreshPRoducts.BackColor = System.Drawing.Color.LightBlue;
            this.RefreshPRoducts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RefreshPRoducts.BackgroundImage")));
            this.RefreshPRoducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshPRoducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshPRoducts.Location = new System.Drawing.Point(465, 177);
            this.RefreshPRoducts.Name = "RefreshPRoducts";
            this.RefreshPRoducts.Size = new System.Drawing.Size(28, 22);
            this.RefreshPRoducts.TabIndex = 40;
            this.RefreshPRoducts.UseVisualStyleBackColor = false;
            this.RefreshPRoducts.Click += new System.EventHandler(this.RefreshPRoducts_Click);
            // 
            // Needed
            // 
            this.Needed.AutoSize = true;
            this.Needed.BackColor = System.Drawing.Color.Black;
            this.Needed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Needed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Needed.ForeColor = System.Drawing.Color.Red;
            this.Needed.Location = new System.Drawing.Point(145, 297);
            this.Needed.Name = "Needed";
            this.Needed.Size = new System.Drawing.Size(17, 19);
            this.Needed.TabIndex = 41;
            this.Needed.Text = "*";
            this.Needed.Visible = false;
            this.Needed.Click += new System.EventHandler(this.Needed_Click);
            // 
            // NETAmount
            // 
            this.NETAmount.BackColor = System.Drawing.Color.Gray;
            this.NETAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NETAmount.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.NETAmount.ForeColor = System.Drawing.Color.Brown;
            this.NETAmount.Location = new System.Drawing.Point(722, 263);
            this.NETAmount.Name = "NETAmount";
            this.NETAmount.ReadOnly = true;
            this.NETAmount.Size = new System.Drawing.Size(109, 19);
            this.NETAmount.TabIndex = 42;
            this.NETAmount.Text = "    0 PLN";
            this.NETAmount.TextChanged += new System.EventHandler(this.NETAmount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightBlue;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(627, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 43;
            this.label3.Text = " NETTO :";
            // 
            // CLIENTIDTXT
            // 
            this.CLIENTIDTXT.BackColor = System.Drawing.Color.Black;
            this.CLIENTIDTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CLIENTIDTXT.Location = new System.Drawing.Point(-29, 27);
            this.CLIENTIDTXT.Name = "CLIENTIDTXT";
            this.CLIENTIDTXT.ReadOnly = true;
            this.CLIENTIDTXT.Size = new System.Drawing.Size(43, 13);
            this.CLIENTIDTXT.TabIndex = 44;
            this.CLIENTIDTXT.Visible = false;
            this.CLIENTIDTXT.TextChanged += new System.EventHandler(this.CLIENTIDTXT_TextChanged);
            // 
            // TicketStartPicker
            // 
            this.TicketStartPicker.CalendarForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TicketStartPicker.CalendarMonthBackground = System.Drawing.Color.Black;
            this.TicketStartPicker.CalendarTitleForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TicketStartPicker.Checked = false;
            this.TicketStartPicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.TicketStartPicker.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketStartPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TicketStartPicker.Location = new System.Drawing.Point(3, 25);
            this.TicketStartPicker.Name = "TicketStartPicker";
            this.TicketStartPicker.Size = new System.Drawing.Size(132, 20);
            this.TicketStartPicker.TabIndex = 45;
            this.TicketStartPicker.TabStop = false;
            this.TicketStartPicker.Value = new System.DateTime(2016, 3, 28, 16, 18, 40, 0);
            this.TicketStartPicker.ValueChanged += new System.EventHandler(this.TicketStartPicker_ValueChanged);
            // 
            // TicketActivePanel
            // 
            this.TicketActivePanel.BackColor = System.Drawing.Color.Black;
            this.TicketActivePanel.Controls.Add(this.activefromtxt);
            this.TicketActivePanel.Controls.Add(this.TicketStartPicker);
            this.TicketActivePanel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TicketActivePanel.Location = new System.Drawing.Point(355, 321);
            this.TicketActivePanel.Name = "TicketActivePanel";
            this.TicketActivePanel.Size = new System.Drawing.Size(138, 48);
            this.TicketActivePanel.TabIndex = 46;
            this.TicketActivePanel.Visible = false;
            this.TicketActivePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TicketActivePanel_Paint);
            // 
            // activefromtxt
            // 
            this.activefromtxt.AutoSize = true;
            this.activefromtxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activefromtxt.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activefromtxt.ForeColor = System.Drawing.Color.LightBlue;
            this.activefromtxt.Location = new System.Drawing.Point(19, 5);
            this.activefromtxt.Name = "activefromtxt";
            this.activefromtxt.Size = new System.Drawing.Size(93, 13);
            this.activefromtxt.TabIndex = 46;
            this.activefromtxt.Text = "AKTYWNY OD :";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(853, 435);
            this.Controls.Add(this.TicketActivePanel);
            this.Controls.Add(this.CLIENTIDTXT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NETAmount);
            this.Controls.Add(this.Needed);
            this.Controls.Add(this.RefreshPRoducts);
            this.Controls.Add(this.RefreshClients);
            this.Controls.Add(this.VATAMOUNT);
            this.Controls.Add(this.BRUTTO);
            this.Controls.Add(this.SelectedUSR);
            this.Controls.Add(this.selectedusrTXT);
            this.Controls.Add(this.SurnameSRCH);
            this.Controls.Add(this.ClientsData);
            this.Controls.Add(this.IloscBiletow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VATbox);
            this.Controls.Add(this.VATlab);
            this.Controls.Add(this.TotalCost);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.removeticket);
            this.Controls.Add(this.Buy);
            this.Controls.Add(this.ProductsToSell);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.Comments);
            this.Controls.Add(this.Client);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productsearch);
            this.Controls.Add(this.ProductList);
            this.Controls.Add(this.Exit_SELL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprzedaż";
            this.Load += new System.EventHandler(this.Sprzedaz_Load);
            this.Shown += new System.EventHandler(this.Sprzedaz_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SaleForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.IloscBiletow)).EndInit();
            this.TicketActivePanel.ResumeLayout(false);
            this.TicketActivePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit_SELL;
        private System.Windows.Forms.ColumnHeader ProductID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Zone;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.TextBox productsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label Client;
        private System.Windows.Forms.RichTextBox Comments;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.ColumnHeader ID2;
        private System.Windows.Forms.ColumnHeader Description2;
        private System.Windows.Forms.ColumnHeader Zone2;
        private System.Windows.Forms.ColumnHeader Type2;
        private System.Windows.Forms.ColumnHeader Price2;
        private System.Windows.Forms.Button Buy;
        private System.Windows.Forms.Button removeticket;
        private System.Windows.Forms.Label Comment;
        private System.Windows.Forms.Label TotalCost;
        private System.Windows.Forms.Label VATlab;
        private System.Windows.Forms.ComboBox VATbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown IloscBiletow;
        private System.Windows.Forms.ColumnHeader ID3;
        private System.Windows.Forms.ColumnHeader imie3;
        private System.Windows.Forms.ColumnHeader Nazwisko3;
        private System.Windows.Forms.TextBox SurnameSRCH;
        private System.Windows.Forms.Label SelectedUSR;
        private System.Windows.Forms.TextBox BRUTTO;
        private System.Windows.Forms.TextBox VATAMOUNT;
        private System.Windows.Forms.Button RefreshClients;
        private System.Windows.Forms.Button RefreshPRoducts;
        private System.Windows.Forms.ColumnHeader Ilosc;
        private System.Windows.Forms.Label Needed;
        private System.Windows.Forms.TextBox NETAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CLIENTIDTXT;
        public System.Windows.Forms.TextBox selectedusrTXT;
        public System.Windows.Forms.ListView ProductList;
        public System.Windows.Forms.ListView ProductsToSell;
        public System.Windows.Forms.ListView ClientsData;
        private System.Windows.Forms.DateTimePicker TicketStartPicker;
        private System.Windows.Forms.Panel TicketActivePanel;
        private System.Windows.Forms.Label activefromtxt;
    }
}