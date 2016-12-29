namespace SPAPracticeManagement.InventoryMaster
{
    partial class frmItem
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
            this.lblTag = new System.Windows.Forms.Label();
            this.pnlTabControlAdd = new System.Windows.Forms.Panel();
            this.txtSaleableYN = new System.Windows.Forms.TextBox();
            this.txtPerishableYN = new System.Windows.Forms.TextBox();
            this.ddlSupplior = new System.Windows.Forms.ComboBox();
            this.txtLastPerRate = new System.Windows.Forms.TextBox();
            this.ddlIssUnit = new System.Windows.Forms.ComboBox();
            this.ddlPurUnit = new System.Windows.Forms.ComboBox();
            this.txtDiscVal = new System.Windows.Forms.TextBox();
            this.txtDiscPer = new System.Windows.Forms.TextBox();
            this.txtVatVal = new System.Windows.Forms.TextBox();
            this.txtVatPer = new System.Windows.Forms.TextBox();
            this.txtReorder = new System.Windows.Forms.TextBox();
            this.txtFactor = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlItemSubGrp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlItemMainGrp = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtActive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtShName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTabControlSearch = new System.Windows.Forms.Panel();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtHidCode = new System.Windows.Forms.TextBox();
            this.pnlTabControlAdd.SuspendLayout();
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
            this.lblTag.TabIndex = 128;
            // 
            // pnlTabControlAdd
            // 
            this.pnlTabControlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlAdd.Controls.Add(this.txtSaleableYN);
            this.pnlTabControlAdd.Controls.Add(this.txtPerishableYN);
            this.pnlTabControlAdd.Controls.Add(this.ddlSupplior);
            this.pnlTabControlAdd.Controls.Add(this.txtLastPerRate);
            this.pnlTabControlAdd.Controls.Add(this.ddlIssUnit);
            this.pnlTabControlAdd.Controls.Add(this.ddlPurUnit);
            this.pnlTabControlAdd.Controls.Add(this.txtDiscVal);
            this.pnlTabControlAdd.Controls.Add(this.txtDiscPer);
            this.pnlTabControlAdd.Controls.Add(this.txtVatVal);
            this.pnlTabControlAdd.Controls.Add(this.txtVatPer);
            this.pnlTabControlAdd.Controls.Add(this.txtReorder);
            this.pnlTabControlAdd.Controls.Add(this.txtFactor);
            this.pnlTabControlAdd.Controls.Add(this.txtName);
            this.pnlTabControlAdd.Controls.Add(this.label10);
            this.pnlTabControlAdd.Controls.Add(this.label20);
            this.pnlTabControlAdd.Controls.Add(this.label16);
            this.pnlTabControlAdd.Controls.Add(this.label17);
            this.pnlTabControlAdd.Controls.Add(this.label18);
            this.pnlTabControlAdd.Controls.Add(this.label19);
            this.pnlTabControlAdd.Controls.Add(this.label12);
            this.pnlTabControlAdd.Controls.Add(this.label13);
            this.pnlTabControlAdd.Controls.Add(this.label14);
            this.pnlTabControlAdd.Controls.Add(this.label15);
            this.pnlTabControlAdd.Controls.Add(this.label9);
            this.pnlTabControlAdd.Controls.Add(this.label8);
            this.pnlTabControlAdd.Controls.Add(this.label6);
            this.pnlTabControlAdd.Controls.Add(this.label5);
            this.pnlTabControlAdd.Controls.Add(this.ddlItemSubGrp);
            this.pnlTabControlAdd.Controls.Add(this.label3);
            this.pnlTabControlAdd.Controls.Add(this.ddlItemMainGrp);
            this.pnlTabControlAdd.Controls.Add(this.btnUpdate);
            this.pnlTabControlAdd.Controls.Add(this.btnClear);
            this.pnlTabControlAdd.Controls.Add(this.btnSave);
            this.pnlTabControlAdd.Controls.Add(this.txtActive);
            this.pnlTabControlAdd.Controls.Add(this.label7);
            this.pnlTabControlAdd.Controls.Add(this.txtShName);
            this.pnlTabControlAdd.Controls.Add(this.label4);
            this.pnlTabControlAdd.Location = new System.Drawing.Point(249, 204);
            this.pnlTabControlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlAdd.Name = "pnlTabControlAdd";
            this.pnlTabControlAdd.Size = new System.Drawing.Size(731, 551);
            this.pnlTabControlAdd.TabIndex = 129;
            // 
            // txtSaleableYN
            // 
            this.txtSaleableYN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaleableYN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleableYN.Location = new System.Drawing.Point(495, 406);
            this.txtSaleableYN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSaleableYN.MaxLength = 1;
            this.txtSaleableYN.Name = "txtSaleableYN";
            this.txtSaleableYN.Size = new System.Drawing.Size(39, 27);
            this.txtSaleableYN.TabIndex = 15;
            this.txtSaleableYN.Text = "Y";
            this.txtSaleableYN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSaleableYN_KeyUp);
            // 
            // txtPerishableYN
            // 
            this.txtPerishableYN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPerishableYN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerishableYN.Location = new System.Drawing.Point(212, 404);
            this.txtPerishableYN.Margin = new System.Windows.Forms.Padding(4);
            this.txtPerishableYN.MaxLength = 1;
            this.txtPerishableYN.Name = "txtPerishableYN";
            this.txtPerishableYN.Size = new System.Drawing.Size(39, 27);
            this.txtPerishableYN.TabIndex = 14;
            this.txtPerishableYN.Text = "Y";
            this.txtPerishableYN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPerishableYN_KeyUp);
            // 
            // ddlSupplior
            // 
            this.ddlSupplior.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSupplior.FormattingEnabled = true;
            this.ddlSupplior.Location = new System.Drawing.Point(212, 369);
            this.ddlSupplior.Margin = new System.Windows.Forms.Padding(4);
            this.ddlSupplior.Name = "ddlSupplior";
            this.ddlSupplior.Size = new System.Drawing.Size(397, 27);
            this.ddlSupplior.TabIndex = 13;
            this.ddlSupplior.Enter += new System.EventHandler(this.ddlSupplior_Enter);
            this.ddlSupplior.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlSupplior_KeyUp);
            this.ddlSupplior.Validated += new System.EventHandler(this.ddlSupplior_Validated);
            // 
            // txtLastPerRate
            // 
            this.txtLastPerRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastPerRate.Location = new System.Drawing.Point(212, 334);
            this.txtLastPerRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastPerRate.MaxLength = 50;
            this.txtLastPerRate.Name = "txtLastPerRate";
            this.txtLastPerRate.Size = new System.Drawing.Size(128, 27);
            this.txtLastPerRate.TabIndex = 12;
            this.txtLastPerRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLastPerRate_KeyUp);
            // 
            // ddlIssUnit
            // 
            this.ddlIssUnit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIssUnit.FormattingEnabled = true;
            this.ddlIssUnit.Location = new System.Drawing.Point(212, 194);
            this.ddlIssUnit.Margin = new System.Windows.Forms.Padding(4);
            this.ddlIssUnit.Name = "ddlIssUnit";
            this.ddlIssUnit.Size = new System.Drawing.Size(397, 27);
            this.ddlIssUnit.TabIndex = 5;
            this.ddlIssUnit.Enter += new System.EventHandler(this.txtIssUnit_Enter);
            this.ddlIssUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlIssUnit_KeyUp);
            this.ddlIssUnit.Validated += new System.EventHandler(this.txtIssUnit_Validated);
            // 
            // ddlPurUnit
            // 
            this.ddlPurUnit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPurUnit.FormattingEnabled = true;
            this.ddlPurUnit.Location = new System.Drawing.Point(212, 160);
            this.ddlPurUnit.Margin = new System.Windows.Forms.Padding(4);
            this.ddlPurUnit.Name = "ddlPurUnit";
            this.ddlPurUnit.Size = new System.Drawing.Size(397, 27);
            this.ddlPurUnit.TabIndex = 4;
            this.ddlPurUnit.Enter += new System.EventHandler(this.ddlPurUnit_Enter);
            this.ddlPurUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlPurUnit_KeyUp);
            this.ddlPurUnit.Validated += new System.EventHandler(this.ddlPurUnit_Validated);
            // 
            // txtDiscVal
            // 
            this.txtDiscVal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscVal.Location = new System.Drawing.Point(480, 299);
            this.txtDiscVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscVal.MaxLength = 50;
            this.txtDiscVal.Name = "txtDiscVal";
            this.txtDiscVal.Size = new System.Drawing.Size(128, 27);
            this.txtDiscVal.TabIndex = 11;
            this.txtDiscVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscVal_KeyUp);
            // 
            // txtDiscPer
            // 
            this.txtDiscPer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscPer.Location = new System.Drawing.Point(212, 299);
            this.txtDiscPer.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscPer.MaxLength = 50;
            this.txtDiscPer.Name = "txtDiscPer";
            this.txtDiscPer.Size = new System.Drawing.Size(128, 27);
            this.txtDiscPer.TabIndex = 70;
            this.txtDiscPer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiscPer_KeyUp);
            // 
            // txtVatVal
            // 
            this.txtVatVal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatVal.Location = new System.Drawing.Point(480, 263);
            this.txtVatVal.Margin = new System.Windows.Forms.Padding(4);
            this.txtVatVal.MaxLength = 50;
            this.txtVatVal.Name = "txtVatVal";
            this.txtVatVal.Size = new System.Drawing.Size(128, 27);
            this.txtVatVal.TabIndex = 9;
            this.txtVatVal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVatVal_KeyUp);
            // 
            // txtVatPer
            // 
            this.txtVatPer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatPer.Location = new System.Drawing.Point(212, 263);
            this.txtVatPer.Margin = new System.Windows.Forms.Padding(4);
            this.txtVatPer.MaxLength = 50;
            this.txtVatPer.Name = "txtVatPer";
            this.txtVatPer.Size = new System.Drawing.Size(128, 27);
            this.txtVatPer.TabIndex = 8;
            this.txtVatPer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVatPer_KeyUp);
            // 
            // txtReorder
            // 
            this.txtReorder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReorder.Location = new System.Drawing.Point(480, 229);
            this.txtReorder.Margin = new System.Windows.Forms.Padding(4);
            this.txtReorder.MaxLength = 50;
            this.txtReorder.Name = "txtReorder";
            this.txtReorder.Size = new System.Drawing.Size(128, 27);
            this.txtReorder.TabIndex = 7;
            this.txtReorder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReorder_KeyUp);
            // 
            // txtFactor
            // 
            this.txtFactor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactor.Location = new System.Drawing.Point(212, 231);
            this.txtFactor.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactor.MaxLength = 50;
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(128, 27);
            this.txtFactor.TabIndex = 6;
            this.txtFactor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFactor_KeyUp);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(212, 16);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(396, 27);
            this.txtName.TabIndex = 0;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(355, 302);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 21);
            this.label10.TabIndex = 139;
            this.label10.Text = "Disc Val :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(355, 235);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 21);
            this.label20.TabIndex = 138;
            this.label20.Text = "Reorder Lavel :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(357, 406);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 21);
            this.label16.TabIndex = 137;
            this.label16.Text = "Saleable (Y/N) :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(29, 406);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 21);
            this.label17.TabIndex = 136;
            this.label17.Text = "Perishable (Y/N) :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(29, 369);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(162, 21);
            this.label18.TabIndex = 135;
            this.label18.Text = "Last Purchase Party:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(29, 334);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(164, 21);
            this.label19.TabIndex = 134;
            this.label19.Text = "Last Purchase Rate :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 299);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 21);
            this.label12.TabIndex = 133;
            this.label12.Text = "Disc (%):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(355, 267);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 132;
            this.label13.Text = "Vat Val :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(29, 263);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 21);
            this.label14.TabIndex = 131;
            this.label14.Text = "Vat (%):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(29, 229);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 21);
            this.label15.TabIndex = 130;
            this.label15.Text = "Factor :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 194);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 21);
            this.label9.TabIndex = 127;
            this.label9.Text = "Issue Unit :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 21);
            this.label8.TabIndex = 126;
            this.label8.Text = "Purchase Unit :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 125;
            this.label6.Text = "Short Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 124;
            this.label5.Text = "Item Name :";
            // 
            // ddlItemSubGrp
            // 
            this.ddlItemSubGrp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlItemSubGrp.FormattingEnabled = true;
            this.ddlItemSubGrp.Location = new System.Drawing.Point(212, 126);
            this.ddlItemSubGrp.Margin = new System.Windows.Forms.Padding(4);
            this.ddlItemSubGrp.Name = "ddlItemSubGrp";
            this.ddlItemSubGrp.Size = new System.Drawing.Size(397, 27);
            this.ddlItemSubGrp.TabIndex = 3;
            this.ddlItemSubGrp.Enter += new System.EventHandler(this.ddlItemSubGrp_Enter);
            this.ddlItemSubGrp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlItemSubGrp_KeyUp);
            this.ddlItemSubGrp.Validated += new System.EventHandler(this.ddlItemSubGrp_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 21);
            this.label3.TabIndex = 123;
            this.label3.Text = "Item Sub Group :";
            // 
            // ddlItemMainGrp
            // 
            this.ddlItemMainGrp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlItemMainGrp.FormattingEnabled = true;
            this.ddlItemMainGrp.Location = new System.Drawing.Point(212, 89);
            this.ddlItemMainGrp.Margin = new System.Windows.Forms.Padding(4);
            this.ddlItemMainGrp.Name = "ddlItemMainGrp";
            this.ddlItemMainGrp.Size = new System.Drawing.Size(397, 27);
            this.ddlItemMainGrp.TabIndex = 2;
            this.ddlItemMainGrp.DropDownClosed += new System.EventHandler(this.ddlItemMainGrp_DropDownClosed);
            this.ddlItemMainGrp.Enter += new System.EventHandler(this.ddlItemMainGrp_Enter);
            this.ddlItemMainGrp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlItemMainGrp_KeyUp);
            this.ddlItemMainGrp.Validated += new System.EventHandler(this.ddlItemMainGrp_Validated);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(361, 500);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 32);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnUpdate_KeyUp);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(477, 465);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 32);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnClear_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(361, 465);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyUp);
            // 
            // txtActive
            // 
            this.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActive.Location = new System.Drawing.Point(212, 436);
            this.txtActive.Margin = new System.Windows.Forms.Padding(4);
            this.txtActive.MaxLength = 1;
            this.txtActive.Name = "txtActive";
            this.txtActive.Size = new System.Drawing.Size(39, 27);
            this.txtActive.TabIndex = 16;
            this.txtActive.Text = "Y";
            this.txtActive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtActive_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 439);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 21);
            this.label7.TabIndex = 119;
            this.label7.Text = "Active :";
            // 
            // txtShName
            // 
            this.txtShName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShName.Location = new System.Drawing.Point(212, 53);
            this.txtShName.Margin = new System.Windows.Forms.Padding(4);
            this.txtShName.MaxLength = 50;
            this.txtShName.Name = "txtShName";
            this.txtShName.Size = new System.Drawing.Size(396, 27);
            this.txtShName.TabIndex = 1;
            this.txtShName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShName_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 21);
            this.label4.TabIndex = 109;
            this.label4.Text = "Item Main Group :";
            // 
            // pnlTabControlSearch
            // 
            this.pnlTabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlSearch.Controls.Add(this.txtSearchText);
            this.pnlTabControlSearch.Controls.Add(this.grdSearch);
            this.pnlTabControlSearch.Location = new System.Drawing.Point(997, 240);
            this.pnlTabControlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlSearch.Name = "pnlTabControlSearch";
            this.pnlTabControlSearch.Size = new System.Drawing.Size(363, 447);
            this.pnlTabControlSearch.TabIndex = 131;
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
            this.grdSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellDoubleClick);
            // 
            // txtHidCode
            // 
            this.txtHidCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHidCode.Location = new System.Drawing.Point(997, 206);
            this.txtHidCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtHidCode.MaxLength = 20;
            this.txtHidCode.Name = "txtHidCode";
            this.txtHidCode.Size = new System.Drawing.Size(239, 27);
            this.txtHidCode.TabIndex = 130;
            this.txtHidCode.Visible = false;
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 753);
            this.Controls.Add(this.pnlTabControlSearch);
            this.Controls.Add(this.txtHidCode);
            this.Controls.Add(this.pnlTabControlAdd);
            this.Controls.Add(this.lblTag);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmItem";
            this.Text = "frmItem";
            this.Load += new System.EventHandler(this.frmItem_Load);
            this.Controls.SetChildIndex(this.lblTag, 0);
            this.Controls.SetChildIndex(this.pnlTabControlAdd, 0);
            this.Controls.SetChildIndex(this.txtHidCode, 0);
            this.Controls.SetChildIndex(this.pnlTabControlSearch, 0);
            this.pnlTabControlAdd.ResumeLayout(false);
            this.pnlTabControlAdd.PerformLayout();
            this.pnlTabControlSearch.ResumeLayout(false);
            this.pnlTabControlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTag;
        public System.Windows.Forms.Panel pnlTabControlAdd;
        private System.Windows.Forms.ComboBox ddlItemMainGrp;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel pnlTabControlSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.TextBox txtHidCode;
        private System.Windows.Forms.ComboBox ddlItemSubGrp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaleableYN;
        private System.Windows.Forms.TextBox txtPerishableYN;
        private System.Windows.Forms.ComboBox ddlSupplior;
        private System.Windows.Forms.TextBox txtLastPerRate;
        private System.Windows.Forms.ComboBox ddlIssUnit;
        private System.Windows.Forms.ComboBox ddlPurUnit;
        private System.Windows.Forms.TextBox txtDiscVal;
        private System.Windows.Forms.TextBox txtDiscPer;
        private System.Windows.Forms.TextBox txtVatVal;
        private System.Windows.Forms.TextBox txtVatPer;
        private System.Windows.Forms.TextBox txtReorder;
        private System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label10;
    }
}