namespace SPAPracticeManagement.InventoryTransaction
{
    partial class frmOpeningStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpeningStock));
            this.pnlTabControlAdd = new System.Windows.Forms.Panel();
            this.txtHdActiveYN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSubSave = new System.Windows.Forms.Button();
            this.grdDtl = new System.Windows.Forms.DataGridView();
            this.btnSubAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlIssUnit = new System.Windows.Forms.ComboBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlService = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtActive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ItemCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DActiveYN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTabControlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabControlAdd
            // 
            this.pnlTabControlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlAdd.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTabControlAdd.Controls.Add(this.label10);
            this.pnlTabControlAdd.Controls.Add(this.txtHdActiveYN);
            this.pnlTabControlAdd.Controls.Add(this.label8);
            this.pnlTabControlAdd.Controls.Add(this.btnSubSave);
            this.pnlTabControlAdd.Controls.Add(this.grdDtl);
            this.pnlTabControlAdd.Controls.Add(this.btnSubAdd);
            this.pnlTabControlAdd.Controls.Add(this.label6);
            this.pnlTabControlAdd.Controls.Add(this.label2);
            this.pnlTabControlAdd.Controls.Add(this.ddlIssUnit);
            this.pnlTabControlAdd.Controls.Add(this.txtRate);
            this.pnlTabControlAdd.Controls.Add(this.txtQty);
            this.pnlTabControlAdd.Controls.Add(this.label14);
            this.pnlTabControlAdd.Controls.Add(this.label15);
            this.pnlTabControlAdd.Controls.Add(this.label9);
            this.pnlTabControlAdd.Controls.Add(this.label5);
            this.pnlTabControlAdd.Controls.Add(this.ddlItem);
            this.pnlTabControlAdd.Controls.Add(this.label3);
            this.pnlTabControlAdd.Controls.Add(this.ddlService);
            this.pnlTabControlAdd.Controls.Add(this.btnUpdate);
            this.pnlTabControlAdd.Controls.Add(this.btnClear);
            this.pnlTabControlAdd.Controls.Add(this.btnSave);
            this.pnlTabControlAdd.Controls.Add(this.txtActive);
            this.pnlTabControlAdd.Controls.Add(this.label7);
            this.pnlTabControlAdd.Controls.Add(this.label4);
            this.pnlTabControlAdd.Location = new System.Drawing.Point(213, 171);
            this.pnlTabControlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlAdd.Name = "pnlTabControlAdd";
            this.pnlTabControlAdd.Size = new System.Drawing.Size(1481, 663);
            this.pnlTabControlAdd.TabIndex = 131;
            // 
            // txtHdActiveYN
            // 
            this.txtHdActiveYN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHdActiveYN.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHdActiveYN.Location = new System.Drawing.Point(443, 41);
            this.txtHdActiveYN.Margin = new System.Windows.Forms.Padding(4);
            this.txtHdActiveYN.MaxLength = 1;
            this.txtHdActiveYN.Name = "txtHdActiveYN";
            this.txtHdActiveYN.Size = new System.Drawing.Size(39, 27);
            this.txtHdActiveYN.TabIndex = 137;
            this.txtHdActiveYN.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(341, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 21);
            this.label8.TabIndex = 136;
            this.label8.Text = "Godown :";
            // 
            // btnSubSave
            // 
            this.btnSubSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSubSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubSave.Location = new System.Drawing.Point(1017, 114);
            this.btnSubSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubSave.Name = "btnSubSave";
            this.btnSubSave.Size = new System.Drawing.Size(100, 32);
            this.btnSubSave.TabIndex = 8;
            this.btnSubSave.Text = "Save";
            this.btnSubSave.UseVisualStyleBackColor = false;
            // 
            // grdDtl
            // 
            this.grdDtl.AllowUserToAddRows = false;
            this.grdDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDtl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCd,
            this.Item,
            this.Qty,
            this.UnitCd,
            this.Unit,
            this.Rate,
            this.Edit,
            this.Delete,
            this.code,
            this.DActiveYN});
            this.grdDtl.Location = new System.Drawing.Point(8, 164);
            this.grdDtl.Name = "grdDtl";
            this.grdDtl.RowTemplate.Height = 24;
            this.grdDtl.Size = new System.Drawing.Size(1055, 312);
            this.grdDtl.TabIndex = 135;
            // 
            // btnSubAdd
            // 
            this.btnSubAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSubAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubAdd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubAdd.Location = new System.Drawing.Point(909, 114);
            this.btnSubAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Size = new System.Drawing.Size(100, 32);
            this.btnSubAdd.TabIndex = 7;
            this.btnSubAdd.Text = "Add";
            this.btnSubAdd.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(0, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1194, 5);
            this.label6.TabIndex = 133;
            this.label6.Text = "label6";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(0, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1194, 5);
            this.label2.TabIndex = 132;
            this.label2.Text = "label2";
            // 
            // ddlIssUnit
            // 
            this.ddlIssUnit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlIssUnit.FormattingEnabled = true;
            this.ddlIssUnit.Location = new System.Drawing.Point(413, 114);
            this.ddlIssUnit.Margin = new System.Windows.Forms.Padding(4);
            this.ddlIssUnit.Name = "ddlIssUnit";
            this.ddlIssUnit.Size = new System.Drawing.Size(151, 27);
            this.ddlIssUnit.TabIndex = 3;
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(711, 114);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRate.MaxLength = 50;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(128, 27);
            this.txtRate.TabIndex = 5;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(562, 114);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.MaxLength = 50;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(144, 27);
            this.txtQty.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(714, 89);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 21);
            this.label14.TabIndex = 131;
            this.label14.Text = "Rate :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(581, 89);
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
            this.label9.Location = new System.Drawing.Point(439, 89);
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
            this.label5.Location = new System.Drawing.Point(15, 41);
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
            this.ddlItem.Location = new System.Drawing.Point(17, 114);
            this.ddlItem.Margin = new System.Windows.Forms.Padding(4);
            this.ddlItem.Name = "ddlItem";
            this.ddlItem.Size = new System.Drawing.Size(397, 27);
            this.ddlItem.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 123;
            this.label3.Text = "Item :";
            // 
            // ddlService
            // 
            this.ddlService.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlService.FormattingEnabled = true;
            this.ddlService.Location = new System.Drawing.Point(442, 9);
            this.ddlService.Margin = new System.Windows.Forms.Padding(4);
            this.ddlService.Name = "ddlService";
            this.ddlService.Size = new System.Drawing.Size(397, 27);
            this.ddlService.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(489, 617);
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
            this.btnClear.Location = new System.Drawing.Point(597, 617);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 32);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(382, 617);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtActive
            // 
            this.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActive.Location = new System.Drawing.Point(850, 114);
            this.txtActive.Margin = new System.Windows.Forms.Padding(4);
            this.txtActive.MaxLength = 1;
            this.txtActive.Name = "txtActive";
            this.txtActive.Size = new System.Drawing.Size(39, 27);
            this.txtActive.TabIndex = 6;
            this.txtActive.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(846, 89);
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
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 109;
            this.label4.Text = "Stock Date :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(355, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 21);
            this.label10.TabIndex = 138;
            this.label10.Text = "Active :";
            // 
            // ItemCd
            // 
            this.ItemCd.HeaderText = "ItemCd";
            this.ItemCd.Name = "ItemCd";
            this.ItemCd.Visible = false;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.Width = 365;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 80;
            // 
            // UnitCd
            // 
            this.UnitCd.HeaderText = "UnitCd";
            this.UnitCd.Name = "UnitCd";
            this.UnitCd.Visible = false;
            this.UnitCd.Width = 50;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Width = 80;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 50;
            // 
            // code
            // 
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.Visible = false;
            // 
            // DActiveYN
            // 
            this.DActiveYN.HeaderText = "DActiveYN";
            this.DActiveYN.Name = "DActiveYN";
            this.DActiveYN.Visible = false;
            // 
            // frmOpeningStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1577, 731);
            this.Controls.Add(this.pnlTabControlAdd);
            this.Name = "frmOpeningStock";
            this.Text = "Opening Stock";
            this.Load += new System.EventHandler(this.frmOpeningStock_Load);
            this.Controls.SetChildIndex(this.pnlTabControlAdd, 0);
            this.pnlTabControlAdd.ResumeLayout(false);
            this.pnlTabControlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlTabControlAdd;
        private System.Windows.Forms.TextBox txtHdActiveYN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSubSave;
        private System.Windows.Forms.DataGridView grdDtl;
        private System.Windows.Forms.Button btnSubAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlIssUnit;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlService;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn DActiveYN;
    }
}