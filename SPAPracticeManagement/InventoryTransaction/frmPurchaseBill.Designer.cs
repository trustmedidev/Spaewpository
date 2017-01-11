namespace SPAPracticeManagement.InventoryTransaction
{
    partial class frmPurchaseBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseBill));
            this.lblTag = new System.Windows.Forms.Label();
            this.pnlTabControlAdd = new System.Windows.Forms.Panel();
            this.DtExp = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.ddlBillType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdTaxTerm = new System.Windows.Forms.DataGridView();
            this.Sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddOrSub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trnTaxVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotItTax = new System.Windows.Forms.TextBox();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.txtTotAmount = new System.Windows.Forms.TextBox();
            this.txtTaxTotal = new System.Windows.Forms.TextBox();
            this.txtItTaxPer = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtItTaxVal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ddlTaxTerm = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ddlSupplier = new System.Windows.Forms.ComboBox();
            this.txtGrossAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlGodown = new System.Windows.Forms.ComboBox();
            this.txtIndentNo = new System.Windows.Forms.TextBox();
            this.StockDt = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHdActiveYN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSubSave = new System.Windows.Forms.Button();
            this.grdDtl = new System.Windows.Forms.DataGridView();
            this.ItemCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItTaxPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItTaxVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DActiveYN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlUnit = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlBranch = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtActive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHidCode = new System.Windows.Forms.TextBox();
            this.txtGrdRowIndex = new System.Windows.Forms.TextBox();
            this.pnlTabControlSearch = new System.Windows.Forms.Panel();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.pnlTabControlAdd.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTaxTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).BeginInit();
            this.pnlTabControlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTag
            // 
            this.lblTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.lblTag.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.ForeColor = System.Drawing.Color.White;
            this.lblTag.Location = new System.Drawing.Point(204, 156);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(1853, 32);
            this.lblTag.TabIndex = 160;
            this.lblTag.Click += new System.EventHandler(this.lblTag_Click);
            // 
            // pnlTabControlAdd
            // 
            this.pnlTabControlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlAdd.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTabControlAdd.Controls.Add(this.DtExp);
            this.pnlTabControlAdd.Controls.Add(this.label24);
            this.pnlTabControlAdd.Controls.Add(this.panel4);
            this.pnlTabControlAdd.Controls.Add(this.label23);
            this.pnlTabControlAdd.Controls.Add(this.ddlBillType);
            this.pnlTabControlAdd.Controls.Add(this.label22);
            this.pnlTabControlAdd.Controls.Add(this.label21);
            this.pnlTabControlAdd.Controls.Add(this.label20);
            this.pnlTabControlAdd.Controls.Add(this.label19);
            this.pnlTabControlAdd.Controls.Add(this.panel2);
            this.pnlTabControlAdd.Controls.Add(this.txtTotItTax);
            this.pnlTabControlAdd.Controls.Add(this.txtNetTotal);
            this.pnlTabControlAdd.Controls.Add(this.txtTotAmount);
            this.pnlTabControlAdd.Controls.Add(this.txtTaxTotal);
            this.pnlTabControlAdd.Controls.Add(this.txtItTaxPer);
            this.pnlTabControlAdd.Controls.Add(this.label18);
            this.pnlTabControlAdd.Controls.Add(this.txtItTaxVal);
            this.pnlTabControlAdd.Controls.Add(this.label17);
            this.pnlTabControlAdd.Controls.Add(this.txtAmount);
            this.pnlTabControlAdd.Controls.Add(this.label16);
            this.pnlTabControlAdd.Controls.Add(this.txtRate);
            this.pnlTabControlAdd.Controls.Add(this.label14);
            this.pnlTabControlAdd.Controls.Add(this.label12);
            this.pnlTabControlAdd.Controls.Add(this.ddlTaxTerm);
            this.pnlTabControlAdd.Controls.Add(this.label13);
            this.pnlTabControlAdd.Controls.Add(this.ddlSupplier);
            this.pnlTabControlAdd.Controls.Add(this.txtGrossAmount);
            this.pnlTabControlAdd.Controls.Add(this.btnSave);
            this.pnlTabControlAdd.Controls.Add(this.label11);
            this.pnlTabControlAdd.Controls.Add(this.ddlGodown);
            this.pnlTabControlAdd.Controls.Add(this.txtIndentNo);
            this.pnlTabControlAdd.Controls.Add(this.StockDt);
            this.pnlTabControlAdd.Controls.Add(this.label10);
            this.pnlTabControlAdd.Controls.Add(this.txtHdActiveYN);
            this.pnlTabControlAdd.Controls.Add(this.label8);
            this.pnlTabControlAdd.Controls.Add(this.btnSubSave);
            this.pnlTabControlAdd.Controls.Add(this.grdDtl);
            this.pnlTabControlAdd.Controls.Add(this.btnSubAdd);
            this.pnlTabControlAdd.Controls.Add(this.label6);
            this.pnlTabControlAdd.Controls.Add(this.label2);
            this.pnlTabControlAdd.Controls.Add(this.ddlUnit);
            this.pnlTabControlAdd.Controls.Add(this.txtQty);
            this.pnlTabControlAdd.Controls.Add(this.label15);
            this.pnlTabControlAdd.Controls.Add(this.label9);
            this.pnlTabControlAdd.Controls.Add(this.label5);
            this.pnlTabControlAdd.Controls.Add(this.ddlItem);
            this.pnlTabControlAdd.Controls.Add(this.label3);
            this.pnlTabControlAdd.Controls.Add(this.ddlBranch);
            this.pnlTabControlAdd.Controls.Add(this.btnUpdate);
            this.pnlTabControlAdd.Controls.Add(this.btnClear);
            this.pnlTabControlAdd.Controls.Add(this.txtActive);
            this.pnlTabControlAdd.Controls.Add(this.label7);
            this.pnlTabControlAdd.Controls.Add(this.label4);
            this.pnlTabControlAdd.Location = new System.Drawing.Point(212, 234);
            this.pnlTabControlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlAdd.Name = "pnlTabControlAdd";
            this.pnlTabControlAdd.Size = new System.Drawing.Size(1663, 934);
            this.pnlTabControlAdd.TabIndex = 161;
            // 
            // DtExp
            // 
            this.DtExp.CustomFormat = "dd/MM/yyyy";
            this.DtExp.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtExp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtExp.Location = new System.Drawing.Point(1434, 78);
            this.DtExp.Name = "DtExp";
            this.DtExp.Size = new System.Drawing.Size(109, 28);
            this.DtExp.TabIndex = 171;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(1332, 77);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 21);
            this.label24.TabIndex = 170;
            this.label24.Text = "Expiry Date :";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(629, 568);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(340, 140);
            this.panel4.TabIndex = 169;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(623, 508);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 21);
            this.label23.TabIndex = 168;
            this.label23.Text = "Bill Type :";
            // 
            // ddlBillType
            // 
            this.ddlBillType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBillType.FormattingEnabled = true;
            this.ddlBillType.Items.AddRange(new object[] {
            "Cash",
            "Cerid",
            "Bank"});
            this.ddlBillType.Location = new System.Drawing.Point(627, 533);
            this.ddlBillType.Margin = new System.Windows.Forms.Padding(4);
            this.ddlBillType.Name = "ddlBillType";
            this.ddlBillType.Size = new System.Drawing.Size(345, 27);
            this.ddlBillType.TabIndex = 167;
            this.ddlBillType.Enter += new System.EventHandler(this.ddlBillType_Enter);
            this.ddlBillType.Validated += new System.EventHandler(this.ddlBillType_Validated);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(980, 600);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 21);
            this.label22.TabIndex = 166;
            this.label22.Text = "Net Total :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(980, 568);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 21);
            this.label21.TabIndex = 165;
            this.label21.Text = "Tax Total :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(980, 530);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 21);
            this.label20.TabIndex = 164;
            this.label20.Text = "Gross Amount :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(886, 478);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 21);
            this.label19.TabIndex = 163;
            this.label19.Text = "Sub Total :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdTaxTerm);
            this.panel2.Location = new System.Drawing.Point(11, 520);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 193);
            this.panel2.TabIndex = 162;
            // 
            // grdTaxTerm
            // 
            this.grdTaxTerm.AllowUserToAddRows = false;
            this.grdTaxTerm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTaxTerm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sl,
            this.TaxCd,
            this.TaxNm,
            this.AddOrSub,
            this.TaxPer,
            this.trnTaxVal,
            this.TaxAmount});
            this.grdTaxTerm.Location = new System.Drawing.Point(4, 12);
            this.grdTaxTerm.Name = "grdTaxTerm";
            this.grdTaxTerm.RowTemplate.Height = 24;
            this.grdTaxTerm.Size = new System.Drawing.Size(593, 172);
            this.grdTaxTerm.TabIndex = 136;
            // 
            // Sl
            // 
            this.Sl.HeaderText = "Sl.";
            this.Sl.Name = "Sl";
            this.Sl.Visible = false;
            this.Sl.Width = 40;
            // 
            // TaxCd
            // 
            this.TaxCd.HeaderText = "TaxCd";
            this.TaxCd.Name = "TaxCd";
            this.TaxCd.Visible = false;
            // 
            // TaxNm
            // 
            this.TaxNm.HeaderText = "Tax Name";
            this.TaxNm.Name = "TaxNm";
            this.TaxNm.ReadOnly = true;
            this.TaxNm.Width = 200;
            // 
            // AddOrSub
            // 
            this.AddOrSub.HeaderText = "+/-";
            this.AddOrSub.Name = "AddOrSub";
            this.AddOrSub.ReadOnly = true;
            this.AddOrSub.Width = 50;
            // 
            // TaxPer
            // 
            this.TaxPer.HeaderText = "Tax (%)";
            this.TaxPer.Name = "TaxPer";
            this.TaxPer.Visible = false;
            this.TaxPer.Width = 50;
            // 
            // trnTaxVal
            // 
            this.trnTaxVal.DataPropertyName = "TaxVal";
            this.trnTaxVal.HeaderText = "Tax. Val.";
            this.trnTaxVal.Name = "trnTaxVal";
            this.trnTaxVal.ReadOnly = true;
            // 
            // TaxAmount
            // 
            this.TaxAmount.HeaderText = "Amount";
            this.TaxAmount.Name = "TaxAmount";
            this.TaxAmount.ReadOnly = true;
            this.TaxAmount.Width = 200;
            // 
            // txtTotItTax
            // 
            this.txtTotItTax.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotItTax.Location = new System.Drawing.Point(1275, 479);
            this.txtTotItTax.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotItTax.MaxLength = 50;
            this.txtTotItTax.Name = "txtTotItTax";
            this.txtTotItTax.Size = new System.Drawing.Size(149, 27);
            this.txtTotItTax.TabIndex = 161;
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetTotal.Location = new System.Drawing.Point(1112, 597);
            this.txtNetTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtNetTotal.MaxLength = 50;
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.Size = new System.Drawing.Size(403, 27);
            this.txtNetTotal.TabIndex = 160;
            // 
            // txtTotAmount
            // 
            this.txtTotAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotAmount.Location = new System.Drawing.Point(1018, 478);
            this.txtTotAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotAmount.MaxLength = 50;
            this.txtTotAmount.Name = "txtTotAmount";
            this.txtTotAmount.Size = new System.Drawing.Size(180, 27);
            this.txtTotAmount.TabIndex = 159;
            // 
            // txtTaxTotal
            // 
            this.txtTaxTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxTotal.Location = new System.Drawing.Point(1112, 562);
            this.txtTaxTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaxTotal.MaxLength = 50;
            this.txtTaxTotal.Name = "txtTaxTotal";
            this.txtTaxTotal.Size = new System.Drawing.Size(404, 27);
            this.txtTaxTotal.TabIndex = 158;
            // 
            // txtItTaxPer
            // 
            this.txtItTaxPer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItTaxPer.Location = new System.Drawing.Point(1198, 125);
            this.txtItTaxPer.Margin = new System.Windows.Forms.Padding(4);
            this.txtItTaxPer.MaxLength = 50;
            this.txtItTaxPer.Name = "txtItTaxPer";
            this.txtItTaxPer.Size = new System.Drawing.Size(77, 27);
            this.txtItTaxPer.TabIndex = 156;
            this.txtItTaxPer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItTaxPer_KeyUp);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1196, 77);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 45);
            this.label18.TabIndex = 157;
            this.label18.Text = "Item Tax(%) :";
            // 
            // txtItTaxVal
            // 
            this.txtItTaxVal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItTaxVal.Location = new System.Drawing.Point(1273, 125);
            this.txtItTaxVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtItTaxVal.MaxLength = 50;
            this.txtItTaxVal.Name = "txtItTaxVal";
            this.txtItTaxVal.Size = new System.Drawing.Size(149, 27);
            this.txtItTaxVal.TabIndex = 154;
            this.txtItTaxVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItTaxVal_KeyUp);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1271, 77);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 45);
            this.label17.TabIndex = 155;
            this.label17.Text = "Item Tax val:";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(1018, 125);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.MaxLength = 50;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(180, 27);
            this.txtAmount.TabIndex = 152;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1012, 101);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 21);
            this.label16.TabIndex = 153;
            this.label16.Text = "Amount :";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(869, 125);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRate.MaxLength = 50;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(149, 27);
            this.txtRate.TabIndex = 150;
            this.txtRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(866, 101);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 21);
            this.label14.TabIndex = 151;
            this.label14.Text = "Rate :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(766, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 21);
            this.label12.TabIndex = 149;
            this.label12.Text = "Tax Term :";
            // 
            // ddlTaxTerm
            // 
            this.ddlTaxTerm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTaxTerm.FormattingEnabled = true;
            this.ddlTaxTerm.Location = new System.Drawing.Point(873, 41);
            this.ddlTaxTerm.Margin = new System.Windows.Forms.Padding(4);
            this.ddlTaxTerm.Name = "ddlTaxTerm";
            this.ddlTaxTerm.Size = new System.Drawing.Size(373, 27);
            this.ddlTaxTerm.TabIndex = 147;
            this.ddlTaxTerm.Enter += new System.EventHandler(this.ddlTaxTerm_Enter);
            this.ddlTaxTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlTaxTerm_KeyUp);
            this.ddlTaxTerm.Validated += new System.EventHandler(this.ddlTaxTerm_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(766, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 21);
            this.label13.TabIndex = 148;
            this.label13.Text = "Supplier :";
            // 
            // ddlSupplier
            // 
            this.ddlSupplier.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSupplier.FormattingEnabled = true;
            this.ddlSupplier.Location = new System.Drawing.Point(873, 9);
            this.ddlSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.ddlSupplier.Name = "ddlSupplier";
            this.ddlSupplier.Size = new System.Drawing.Size(373, 27);
            this.ddlSupplier.TabIndex = 146;
            this.ddlSupplier.Enter += new System.EventHandler(this.ddlSupplier_Enter);
            this.ddlSupplier.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlSupplier_KeyUp);
            this.ddlSupplier.Validated += new System.EventHandler(this.ddlSupplier_Validated);
            // 
            // txtGrossAmount
            // 
            this.txtGrossAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossAmount.Location = new System.Drawing.Point(1112, 527);
            this.txtGrossAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrossAmount.MaxLength = 50;
            this.txtGrossAmount.Name = "txtGrossAmount";
            this.txtGrossAmount.Size = new System.Drawing.Size(405, 27);
            this.txtGrossAmount.TabIndex = 145;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(1303, 643);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(331, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 21);
            this.label11.TabIndex = 142;
            this.label11.Text = "Godown :";
            // 
            // ddlGodown
            // 
            this.ddlGodown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGodown.FormattingEnabled = true;
            this.ddlGodown.Location = new System.Drawing.Point(415, 41);
            this.ddlGodown.Margin = new System.Windows.Forms.Padding(4);
            this.ddlGodown.Name = "ddlGodown";
            this.ddlGodown.Size = new System.Drawing.Size(345, 27);
            this.ddlGodown.TabIndex = 3;
            this.ddlGodown.Enter += new System.EventHandler(this.ddlGodown_Enter);
            this.ddlGodown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlGodown_KeyUp);
            this.ddlGodown.Validated += new System.EventHandler(this.ddlGodown_Validated);
            // 
            // txtIndentNo
            // 
            this.txtIndentNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndentNo.Location = new System.Drawing.Point(99, 34);
            this.txtIndentNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtIndentNo.MaxLength = 50;
            this.txtIndentNo.Name = "txtIndentNo";
            this.txtIndentNo.Size = new System.Drawing.Size(231, 27);
            this.txtIndentNo.TabIndex = 2;
            this.txtIndentNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIndentNo_KeyUp);
            // 
            // StockDt
            // 
            this.StockDt.CustomFormat = "dd/MM/yyyy";
            this.StockDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StockDt.Location = new System.Drawing.Point(99, 7);
            this.StockDt.Name = "StockDt";
            this.StockDt.Size = new System.Drawing.Size(129, 22);
            this.StockDt.TabIndex = 0;
            this.StockDt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StockDt_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1273, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 21);
            this.label10.TabIndex = 138;
            this.label10.Text = "Active :";
            // 
            // txtHdActiveYN
            // 
            this.txtHdActiveYN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHdActiveYN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHdActiveYN.Location = new System.Drawing.Point(1277, 41);
            this.txtHdActiveYN.Margin = new System.Windows.Forms.Padding(4);
            this.txtHdActiveYN.MaxLength = 1;
            this.txtHdActiveYN.Name = "txtHdActiveYN";
            this.txtHdActiveYN.Size = new System.Drawing.Size(29, 27);
            this.txtHdActiveYN.TabIndex = 4;
            this.txtHdActiveYN.Text = "Y";
            this.txtHdActiveYN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHdActiveYN_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(331, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 21);
            this.label8.TabIndex = 136;
            this.label8.Text = "Branch :";
            // 
            // btnSubSave
            // 
            this.btnSubSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSubSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubSave.Location = new System.Drawing.Point(1547, 122);
            this.btnSubSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubSave.Name = "btnSubSave";
            this.btnSubSave.Size = new System.Drawing.Size(84, 32);
            this.btnSubSave.TabIndex = 11;
            this.btnSubSave.Text = "Save";
            this.btnSubSave.UseVisualStyleBackColor = false;
            this.btnSubSave.Click += new System.EventHandler(this.btnSubSave_Click);
            this.btnSubSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnSubSave_KeyUp);
            // 
            // grdDtl
            // 
            this.grdDtl.AllowUserToAddRows = false;
            this.grdDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdDtl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCd,
            this.Item,
            this.UnitCd,
            this.Unit,
            this.Qty,
            this.Rate,
            this.Amount,
            this.ItTaxPer,
            this.ItTaxVal,
            this.ExpiryDt,
            this.DActiveYN,
            this.Edit,
            this.Delete,
            this.code});
            this.grdDtl.Location = new System.Drawing.Point(8, 166);
            this.grdDtl.Name = "grdDtl";
            this.grdDtl.RowTemplate.Height = 24;
            this.grdDtl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDtl.Size = new System.Drawing.Size(1621, 306);
            this.grdDtl.TabIndex = 135;
            this.grdDtl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDtl_CellContentClick);
            // 
            // ItemCd
            // 
            this.ItemCd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ItemCd.HeaderText = "ItemCd";
            this.ItemCd.Name = "ItemCd";
            this.ItemCd.ReadOnly = true;
            this.ItemCd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemCd.Visible = false;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Item.Width = 370;
            // 
            // UnitCd
            // 
            this.UnitCd.HeaderText = "UnitCd";
            this.UnitCd.Name = "UnitCd";
            this.UnitCd.ReadOnly = true;
            this.UnitCd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitCd.Visible = false;
            this.UnitCd.Width = 50;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Unit.Width = 130;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Qty.Width = 110;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.Width = 115;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 120;
            // 
            // ItTaxPer
            // 
            this.ItTaxPer.HeaderText = "Tax (%)";
            this.ItTaxPer.Name = "ItTaxPer";
            this.ItTaxPer.Width = 50;
            // 
            // ItTaxVal
            // 
            this.ItTaxVal.HeaderText = "Tax Val";
            this.ItTaxVal.Name = "ItTaxVal";
            this.ItTaxVal.Width = 80;
            // 
            // ExpiryDt
            // 
            this.ExpiryDt.HeaderText = "Expiry Dt.";
            this.ExpiryDt.Name = "ExpiryDt";
            // 
            // DActiveYN
            // 
            this.DActiveYN.HeaderText = "ActiveYN";
            this.DActiveYN.Name = "DActiveYN";
            this.DActiveYN.ReadOnly = true;
            this.DActiveYN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 50;
            // 
            // code
            // 
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.code.Visible = false;
            // 
            // btnSubAdd
            // 
            this.btnSubAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSubAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubAdd.Location = new System.Drawing.Point(1547, 83);
            this.btnSubAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Size = new System.Drawing.Size(84, 32);
            this.btnSubAdd.TabIndex = 5;
            this.btnSubAdd.Text = "Add";
            this.btnSubAdd.UseVisualStyleBackColor = false;
            this.btnSubAdd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnSubAdd_KeyUp);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(0, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1639, 5);
            this.label6.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(0, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1640, 5);
            this.label2.TabIndex = 132;
            // 
            // ddlUnit
            // 
            this.ddlUnit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUnit.FormattingEnabled = true;
            this.ddlUnit.Location = new System.Drawing.Point(559, 125);
            this.ddlUnit.Margin = new System.Windows.Forms.Padding(4);
            this.ddlUnit.Name = "ddlUnit";
            this.ddlUnit.Size = new System.Drawing.Size(169, 27);
            this.ddlUnit.TabIndex = 7;
            this.ddlUnit.Enter += new System.EventHandler(this.ddlUnit_Enter);
            this.ddlUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlUnit_KeyUp);
            this.ddlUnit.Validated += new System.EventHandler(this.ddlUnit_Validated);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(728, 125);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.MaxLength = 50;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(141, 27);
            this.txtQty.TabIndex = 8;
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(727, 101);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 21);
            this.label15.TabIndex = 130;
            this.label15.Text = "Qty :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(557, 101);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 21);
            this.label9.TabIndex = 127;
            this.label9.Text = "Unit :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 124;
            this.label5.Text = "Indent No :";
            // 
            // ddlItem
            // 
            this.ddlItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlItem.FormattingEnabled = true;
            this.ddlItem.Location = new System.Drawing.Point(11, 125);
            this.ddlItem.Margin = new System.Windows.Forms.Padding(4);
            this.ddlItem.Name = "ddlItem";
            this.ddlItem.Size = new System.Drawing.Size(548, 27);
            this.ddlItem.TabIndex = 6;
            this.ddlItem.Enter += new System.EventHandler(this.ddlItem_Enter);
            this.ddlItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlItem_KeyUp);
            this.ddlItem.Validated += new System.EventHandler(this.ddlItem_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 123;
            this.label3.Text = "Item :";
            // 
            // ddlBranch
            // 
            this.ddlBranch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBranch.FormattingEnabled = true;
            this.ddlBranch.Location = new System.Drawing.Point(415, 9);
            this.ddlBranch.Margin = new System.Windows.Forms.Padding(4);
            this.ddlBranch.Name = "ddlBranch";
            this.ddlBranch.Size = new System.Drawing.Size(345, 27);
            this.ddlBranch.TabIndex = 1;
            this.ddlBranch.Enter += new System.EventHandler(this.ddlBranch_Enter);
            this.ddlBranch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlBranch_KeyUp);
            this.ddlBranch.Validated += new System.EventHandler(this.ddlBranch_Validated);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(1411, 643);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 32);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(1519, 643);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 32);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            // 
            // txtActive
            // 
            this.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActive.Location = new System.Drawing.Point(1424, 125);
            this.txtActive.Margin = new System.Windows.Forms.Padding(4);
            this.txtActive.MaxLength = 1;
            this.txtActive.Name = "txtActive";
            this.txtActive.Size = new System.Drawing.Size(100, 27);
            this.txtActive.TabIndex = 10;
            this.txtActive.Text = "Y";
            this.txtActive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtActive_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1421, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 21);
            this.label7.TabIndex = 119;
            this.label7.Text = "Active :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 109;
            this.label4.Text = "Date :";
            // 
            // txtHidCode
            // 
            this.txtHidCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHidCode.Location = new System.Drawing.Point(1255, 199);
            this.txtHidCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtHidCode.MaxLength = 20;
            this.txtHidCode.Name = "txtHidCode";
            this.txtHidCode.Size = new System.Drawing.Size(238, 27);
            this.txtHidCode.TabIndex = 163;
            this.txtHidCode.Visible = false;
            // 
            // txtGrdRowIndex
            // 
            this.txtGrdRowIndex.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrdRowIndex.Location = new System.Drawing.Point(1008, 199);
            this.txtGrdRowIndex.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrdRowIndex.MaxLength = 20;
            this.txtGrdRowIndex.Name = "txtGrdRowIndex";
            this.txtGrdRowIndex.Size = new System.Drawing.Size(239, 27);
            this.txtGrdRowIndex.TabIndex = 162;
            this.txtGrdRowIndex.Visible = false;
            // 
            // pnlTabControlSearch
            // 
            this.pnlTabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlSearch.Controls.Add(this.txtSearchText);
            this.pnlTabControlSearch.Controls.Add(this.grdSearch);
            this.pnlTabControlSearch.Location = new System.Drawing.Point(1617, 201);
            this.pnlTabControlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlSearch.Name = "pnlTabControlSearch";
            this.pnlTabControlSearch.Size = new System.Drawing.Size(284, 342);
            this.pnlTabControlSearch.TabIndex = 164;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(41, 14);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchText.MaxLength = 20;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(556, 27);
            this.txtSearchText.TabIndex = 1;
            // 
            // grdSearch
            // 
            this.grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearch.Location = new System.Drawing.Point(41, 52);
            this.grdSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.RowTemplate.Height = 24;
            this.grdSearch.Size = new System.Drawing.Size(597, 322);
            this.grdSearch.TabIndex = 0;
            // 
            // frmPurchaseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 962);
            this.Controls.Add(this.txtHidCode);
            this.Controls.Add(this.txtGrdRowIndex);
            this.Controls.Add(this.pnlTabControlAdd);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.pnlTabControlSearch);
            this.Name = "frmPurchaseBill";
            this.Text = "frmPurchaseBill";
            this.Load += new System.EventHandler(this.frmPurchaseBill_Load);
            this.Controls.SetChildIndex(this.pnlTabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblTag, 0);
            this.Controls.SetChildIndex(this.pnlTabControlAdd, 0);
            this.Controls.SetChildIndex(this.txtGrdRowIndex, 0);
            this.Controls.SetChildIndex(this.txtHidCode, 0);
            this.pnlTabControlAdd.ResumeLayout(false);
            this.pnlTabControlAdd.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTaxTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).EndInit();
            this.pnlTabControlSearch.ResumeLayout(false);
            this.pnlTabControlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTag;
        public System.Windows.Forms.Panel pnlTabControlAdd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grdTaxTerm;
        private System.Windows.Forms.TextBox txtTotItTax;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.TextBox txtTotAmount;
        private System.Windows.Forms.TextBox txtTaxTotal;
        private System.Windows.Forms.TextBox txtItTaxPer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtItTaxVal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddlTaxTerm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox ddlSupplier;
        private System.Windows.Forms.TextBox txtGrossAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlGodown;
        private System.Windows.Forms.TextBox txtIndentNo;
        private System.Windows.Forms.DateTimePicker StockDt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHdActiveYN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSubSave;
        private System.Windows.Forms.DataGridView grdDtl;
        private System.Windows.Forms.Button btnSubAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlUnit;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlBranch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHidCode;
        private System.Windows.Forms.TextBox txtGrdRowIndex;
        public System.Windows.Forms.Panel pnlTabControlSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddOrSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn trnTaxVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxAmount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox ddlBillType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItTaxPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItTaxVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DActiveYN;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker DtExp;
    }
}