namespace DesktopApplication
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.txtlbl = new System.Windows.Forms.Label();
            this.Cash = new System.Windows.Forms.Button();
            this.CARD = new System.Windows.Forms.Button();
            this.Transfer = new System.Windows.Forms.Button();
            this.LeaveBN = new System.Windows.Forms.Button();
            this.YE = new System.Windows.Forms.Button();
            this.NIEprzyjeto = new System.Windows.Forms.Button();
            this.Przyjeto = new System.Windows.Forms.Label();
            this.confirmlbl = new System.Windows.Forms.Label();
            this.YE2 = new System.Windows.Forms.Button();
            this.NIEprzyjeto2 = new System.Windows.Forms.Button();
            this.BillBN = new System.Windows.Forms.Button();
            this.InvoiceBN = new System.Windows.Forms.Button();
            this.nipTXT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtlbl
            // 
            this.txtlbl.AutoSize = true;
            this.txtlbl.BackColor = System.Drawing.Color.LightBlue;
            this.txtlbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlbl.Location = new System.Drawing.Point(85, 9);
            this.txtlbl.Name = "txtlbl";
            this.txtlbl.Size = new System.Drawing.Size(356, 15);
            this.txtlbl.TabIndex = 0;
            this.txtlbl.Text = "Prosze wybrać forme płatności spośród poniżej przedstawionych";
            this.txtlbl.Click += new System.EventHandler(this.txtlbl_Click);
            // 
            // Cash
            // 
            this.Cash.BackColor = System.Drawing.Color.Gold;
            this.Cash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cash.Location = new System.Drawing.Point(34, 91);
            this.Cash.Name = "Cash";
            this.Cash.Size = new System.Drawing.Size(109, 50);
            this.Cash.TabIndex = 1;
            this.Cash.Text = "Gotówka";
            this.Cash.UseVisualStyleBackColor = false;
            this.Cash.Click += new System.EventHandler(this.Cash_Click);
            // 
            // CARD
            // 
            this.CARD.BackColor = System.Drawing.Color.MediumVioletRed;
            this.CARD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CARD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CARD.Location = new System.Drawing.Point(209, 91);
            this.CARD.Name = "CARD";
            this.CARD.Size = new System.Drawing.Size(109, 50);
            this.CARD.TabIndex = 2;
            this.CARD.Text = "Karta";
            this.CARD.UseVisualStyleBackColor = false;
            this.CARD.Click += new System.EventHandler(this.CARD_Click);
            // 
            // Transfer
            // 
            this.Transfer.BackColor = System.Drawing.Color.Brown;
            this.Transfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Transfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transfer.Location = new System.Drawing.Point(379, 91);
            this.Transfer.Name = "Transfer";
            this.Transfer.Size = new System.Drawing.Size(109, 50);
            this.Transfer.TabIndex = 3;
            this.Transfer.Text = "Przelew";
            this.Transfer.UseVisualStyleBackColor = false;
            this.Transfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // LeaveBN
            // 
            this.LeaveBN.BackColor = System.Drawing.Color.LightBlue;
            this.LeaveBN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LeaveBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaveBN.Location = new System.Drawing.Point(219, 187);
            this.LeaveBN.Name = "LeaveBN";
            this.LeaveBN.Size = new System.Drawing.Size(79, 29);
            this.LeaveBN.TabIndex = 4;
            this.LeaveBN.Text = "Wyjdź";
            this.LeaveBN.UseVisualStyleBackColor = false;
            this.LeaveBN.Click += new System.EventHandler(this.Leave_Click);
            // 
            // YE
            // 
            this.YE.BackColor = System.Drawing.Color.LightBlue;
            this.YE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YE.Location = new System.Drawing.Point(133, 74);
            this.YE.Name = "YE";
            this.YE.Size = new System.Drawing.Size(76, 41);
            this.YE.TabIndex = 5;
            this.YE.Text = "TAK";
            this.YE.UseVisualStyleBackColor = false;
            this.YE.Visible = false;
            this.YE.Click += new System.EventHandler(this.YE_Click);
            // 
            // NIEprzyjeto
            // 
            this.NIEprzyjeto.BackColor = System.Drawing.Color.LightBlue;
            this.NIEprzyjeto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NIEprzyjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIEprzyjeto.Location = new System.Drawing.Point(313, 74);
            this.NIEprzyjeto.Name = "NIEprzyjeto";
            this.NIEprzyjeto.Size = new System.Drawing.Size(76, 41);
            this.NIEprzyjeto.TabIndex = 6;
            this.NIEprzyjeto.Text = "NIE";
            this.NIEprzyjeto.UseVisualStyleBackColor = false;
            this.NIEprzyjeto.Visible = false;
            this.NIEprzyjeto.Click += new System.EventHandler(this.NIEprzyjeto_Click);
            // 
            // Przyjeto
            // 
            this.Przyjeto.AutoSize = true;
            this.Przyjeto.BackColor = System.Drawing.Color.LightBlue;
            this.Przyjeto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.Przyjeto.Location = new System.Drawing.Point(206, 9);
            this.Przyjeto.Name = "Przyjeto";
            this.Przyjeto.Size = new System.Drawing.Size(118, 15);
            this.Przyjeto.TabIndex = 7;
            this.Przyjeto.Text = "Przyjęto płatność ? :";
            this.Przyjeto.Visible = false;
            this.Przyjeto.Click += new System.EventHandler(this.Przyjeto_Click);
            // 
            // confirmlbl
            // 
            this.confirmlbl.AutoSize = true;
            this.confirmlbl.BackColor = System.Drawing.Color.LightBlue;
            this.confirmlbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
            this.confirmlbl.Location = new System.Drawing.Point(192, 9);
            this.confirmlbl.Name = "confirmlbl";
            this.confirmlbl.Size = new System.Drawing.Size(155, 15);
            this.confirmlbl.TabIndex = 8;
            this.confirmlbl.Text = "Potwierdzić kupno biletu ?";
            this.confirmlbl.Visible = false;
            this.confirmlbl.Click += new System.EventHandler(this.confirmlbl_Click);
            // 
            // YE2
            // 
            this.YE2.BackColor = System.Drawing.Color.Brown;
            this.YE2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YE2.Location = new System.Drawing.Point(133, 74);
            this.YE2.Name = "YE2";
            this.YE2.Size = new System.Drawing.Size(88, 41);
            this.YE2.TabIndex = 9;
            this.YE2.Text = "Zatwierdź";
            this.YE2.UseVisualStyleBackColor = false;
            this.YE2.Visible = false;
            this.YE2.Click += new System.EventHandler(this.YE2_Click);
            // 
            // NIEprzyjeto2
            // 
            this.NIEprzyjeto2.BackColor = System.Drawing.Color.Brown;
            this.NIEprzyjeto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIEprzyjeto2.Location = new System.Drawing.Point(301, 74);
            this.NIEprzyjeto2.Name = "NIEprzyjeto2";
            this.NIEprzyjeto2.Size = new System.Drawing.Size(88, 41);
            this.NIEprzyjeto2.TabIndex = 10;
            this.NIEprzyjeto2.Text = "Anuluj";
            this.NIEprzyjeto2.UseVisualStyleBackColor = false;
            this.NIEprzyjeto2.Visible = false;
            this.NIEprzyjeto2.Click += new System.EventHandler(this.NIEprzyjeto2_Click);
            // 
            // BillBN
            // 
            this.BillBN.BackColor = System.Drawing.Color.Orange;
            this.BillBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillBN.Location = new System.Drawing.Point(120, 48);
            this.BillBN.Name = "BillBN";
            this.BillBN.Size = new System.Drawing.Size(117, 37);
            this.BillBN.TabIndex = 11;
            this.BillBN.Text = "Paragon";
            this.BillBN.UseVisualStyleBackColor = false;
            this.BillBN.Visible = false;
            this.BillBN.Click += new System.EventHandler(this.BillBN_Click);
            // 
            // InvoiceBN
            // 
            this.InvoiceBN.BackColor = System.Drawing.Color.LightBlue;
            this.InvoiceBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceBN.Location = new System.Drawing.Point(285, 48);
            this.InvoiceBN.Name = "InvoiceBN";
            this.InvoiceBN.Size = new System.Drawing.Size(117, 37);
            this.InvoiceBN.TabIndex = 12;
            this.InvoiceBN.Text = "Faktura";
            this.InvoiceBN.UseVisualStyleBackColor = false;
            this.InvoiceBN.Visible = false;
            this.InvoiceBN.Click += new System.EventHandler(this.InvoiceBN_Click);
            // 
            // nipTXT
            // 
            this.nipTXT.BackColor = System.Drawing.Color.LightBlue;
            this.nipTXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nipTXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.nipTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nipTXT.Location = new System.Drawing.Point(297, 91);
            this.nipTXT.MaxLength = 14;
            this.nipTXT.Name = "nipTXT";
            this.nipTXT.Size = new System.Drawing.Size(92, 20);
            this.nipTXT.TabIndex = 13;
            this.nipTXT.Text = "Wprowadź NIP";
            this.nipTXT.Visible = false;
            this.nipTXT.TextChanged += new System.EventHandler(this.nipTXT_TextChanged);
            this.nipTXT.Enter += new System.EventHandler(this.nipTXT_Enter);
            this.nipTXT.Leave += new System.EventHandler(this.nipTXT_Leave);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(531, 228);
            this.Controls.Add(this.nipTXT);
            this.Controls.Add(this.InvoiceBN);
            this.Controls.Add(this.BillBN);
            this.Controls.Add(this.NIEprzyjeto2);
            this.Controls.Add(this.YE2);
            this.Controls.Add(this.confirmlbl);
            this.Controls.Add(this.Przyjeto);
            this.Controls.Add(this.NIEprzyjeto);
            this.Controls.Add(this.YE);
            this.Controls.Add(this.LeaveBN);
            this.Controls.Add(this.Transfer);
            this.Controls.Add(this.CARD);
            this.Controls.Add(this.Cash);
            this.Controls.Add(this.txtlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Platnosc";
            this.Load += new System.EventHandler(this.Platnosc_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PaymentForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtlbl;
        private System.Windows.Forms.Button Cash;
        private System.Windows.Forms.Button CARD;
        private System.Windows.Forms.Button Transfer;
        private System.Windows.Forms.Button LeaveBN;
        private System.Windows.Forms.Button YE;
        private System.Windows.Forms.Button NIEprzyjeto;
        private System.Windows.Forms.Label Przyjeto;
        private System.Windows.Forms.Label confirmlbl;
        private System.Windows.Forms.Button YE2;
        private System.Windows.Forms.Button NIEprzyjeto2;
        private System.Windows.Forms.Button BillBN;
        private System.Windows.Forms.Button InvoiceBN;
        private System.Windows.Forms.TextBox nipTXT;
    }
}