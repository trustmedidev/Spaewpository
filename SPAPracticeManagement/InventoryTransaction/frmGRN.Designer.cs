﻿namespace SPAPracticeManagement.InventoryTransaction
{
    partial class frmGRN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGRN));
            this.lblTag = new System.Windows.Forms.Label();
            this.pnlTabControlAdd = new System.Windows.Forms.Panel();
            this.txtTotQty = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlUser = new System.Windows.Forms.ComboBox();
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
            this.lblTag.TabIndex = 151;
            // 
            // pnlTabControlAdd
            // 
            this.pnlTabControlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlAdd.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTabControlAdd.Controls.Add(this.txtTotQty);
            this.pnlTabControlAdd.Controls.Add(this.btnSave);
            this.pnlTabControlAdd.Controls.Add(this.label11);
            this.pnlTabControlAdd.Controls.Add(this.ddlUser);
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
            this.pnlTabControlAdd.Location = new System.Drawing.Point(216, 201);
            this.pnlTabControlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlAdd.Name = "pnlTabControlAdd";
            this.pnlTabControlAdd.Size = new System.Drawing.Size(1092, 1072);
            this.pnlTabControlAdd.TabIndex = 152;
            // 
            // txtTotQty
            // 
            this.txtTotQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotQty.Location = new System.Drawing.Point(666, 606);
            this.txtTotQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotQty.MaxLength = 50;
            this.txtTotQty.Name = "txtTotQty";
            this.txtTotQty.Size = new System.Drawing.Size(199, 27);
            this.txtTotQty.TabIndex = 145;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(758, 646);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(351, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 21);
            this.label11.TabIndex = 142;
            this.label11.Text = "Requsition from (User) :";
            // 
            // ddlUser
            // 
            this.ddlUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUser.FormattingEnabled = true;
            this.ddlUser.Location = new System.Drawing.Point(569, 41);
            this.ddlUser.Margin = new System.Windows.Forms.Padding(4);
            this.ddlUser.Name = "ddlUser";
            this.ddlUser.Size = new System.Drawing.Size(397, 27);
            this.ddlUser.TabIndex = 3;
            // 
            // txtIndentNo
            // 
            this.txtIndentNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndentNo.Location = new System.Drawing.Point(106, 34);
            this.txtIndentNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtIndentNo.MaxLength = 50;
            this.txtIndentNo.Name = "txtIndentNo";
            this.txtIndentNo.Size = new System.Drawing.Size(231, 27);
            this.txtIndentNo.TabIndex = 2;
            // 
            // StockDt
            // 
            this.StockDt.CustomFormat = "dd/MM/yyyy";
            this.StockDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StockDt.Location = new System.Drawing.Point(106, 7);
            this.StockDt.Name = "StockDt";
            this.StockDt.Size = new System.Drawing.Size(129, 22);
            this.StockDt.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(973, 43);
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
            this.txtHdActiveYN.Location = new System.Drawing.Point(1042, 41);
            this.txtHdActiveYN.Margin = new System.Windows.Forms.Padding(4);
            this.txtHdActiveYN.MaxLength = 1;
            this.txtHdActiveYN.Name = "txtHdActiveYN";
            this.txtHdActiveYN.Size = new System.Drawing.Size(23, 27);
            this.txtHdActiveYN.TabIndex = 4;
            this.txtHdActiveYN.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(351, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 21);
            this.label8.TabIndex = 136;
            this.label8.Text = "Requsition from (Branch ):";
            // 
            // btnSubSave
            // 
            this.btnSubSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSubSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubSave.Location = new System.Drawing.Point(968, 114);
            this.btnSubSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubSave.Name = "btnSubSave";
            this.btnSubSave.Size = new System.Drawing.Size(100, 32);
            this.btnSubSave.TabIndex = 11;
            this.btnSubSave.Text = "Save";
            this.btnSubSave.UseVisualStyleBackColor = false;
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
            this.DActiveYN,
            this.Edit,
            this.Delete,
            this.code});
            this.grdDtl.Location = new System.Drawing.Point(8, 164);
            this.grdDtl.Name = "grdDtl";
            this.grdDtl.RowTemplate.Height = 24;
            this.grdDtl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdDtl.Size = new System.Drawing.Size(1060, 431);
            this.grdDtl.TabIndex = 135;
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
            this.Item.Width = 415;
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
            this.Unit.Width = 200;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Qty.Width = 200;
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
            this.btnSubAdd.Location = new System.Drawing.Point(968, 83);
            this.btnSubAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Size = new System.Drawing.Size(100, 32);
            this.btnSubAdd.TabIndex = 5;
            this.btnSubAdd.Text = "Add";
            this.btnSubAdd.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.label6.Location = new System.Drawing.Point(0, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1079, 5);
            this.label6.TabIndex = 133;
            this.label6.Text = "label6";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(0, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1081, 5);
            this.label2.TabIndex = 132;
            this.label2.Text = "label2";
            // 
            // ddlUnit
            // 
            this.ddlUnit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUnit.FormattingEnabled = true;
            this.ddlUnit.Location = new System.Drawing.Point(467, 117);
            this.ddlUnit.Margin = new System.Windows.Forms.Padding(4);
            this.ddlUnit.Name = "ddlUnit";
            this.ddlUnit.Size = new System.Drawing.Size(199, 27);
            this.ddlUnit.TabIndex = 7;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(666, 117);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.MaxLength = 50;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(198, 27);
            this.txtQty.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(665, 89);
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
            this.label9.Location = new System.Drawing.Point(465, 89);
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
            this.ddlItem.Location = new System.Drawing.Point(12, 117);
            this.ddlItem.Margin = new System.Windows.Forms.Padding(4);
            this.ddlItem.Name = "ddlItem";
            this.ddlItem.Size = new System.Drawing.Size(455, 27);
            this.ddlItem.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 89);
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
            this.ddlBranch.Location = new System.Drawing.Point(569, 9);
            this.ddlBranch.Margin = new System.Windows.Forms.Padding(4);
            this.ddlBranch.Name = "ddlBranch";
            this.ddlBranch.Size = new System.Drawing.Size(397, 27);
            this.ddlBranch.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(865, 646);
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
            this.btnClear.Location = new System.Drawing.Point(973, 646);
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
            this.txtActive.Location = new System.Drawing.Point(864, 117);
            this.txtActive.Margin = new System.Windows.Forms.Padding(4);
            this.txtActive.MaxLength = 1;
            this.txtActive.Name = "txtActive";
            this.txtActive.Size = new System.Drawing.Size(100, 27);
            this.txtActive.TabIndex = 10;
            this.txtActive.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(861, 89);
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
            this.txtHidCode.Location = new System.Drawing.Point(1369, 236);
            this.txtHidCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtHidCode.MaxLength = 20;
            this.txtHidCode.Name = "txtHidCode";
            this.txtHidCode.Size = new System.Drawing.Size(238, 27);
            this.txtHidCode.TabIndex = 155;
            this.txtHidCode.Visible = false;
            // 
            // txtGrdRowIndex
            // 
            this.txtGrdRowIndex.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrdRowIndex.Location = new System.Drawing.Point(1369, 201);
            this.txtGrdRowIndex.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrdRowIndex.MaxLength = 20;
            this.txtGrdRowIndex.Name = "txtGrdRowIndex";
            this.txtGrdRowIndex.Size = new System.Drawing.Size(239, 27);
            this.txtGrdRowIndex.TabIndex = 154;
            this.txtGrdRowIndex.Visible = false;
            // 
            // pnlTabControlSearch
            // 
            this.pnlTabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlSearch.Controls.Add(this.txtSearchText);
            this.pnlTabControlSearch.Controls.Add(this.grdSearch);
            this.pnlTabControlSearch.Location = new System.Drawing.Point(1340, 273);
            this.pnlTabControlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlSearch.Name = "pnlTabControlSearch";
            this.pnlTabControlSearch.Size = new System.Drawing.Size(284, 935);
            this.pnlTabControlSearch.TabIndex = 153;
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
            // frmGRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 906);
            this.Controls.Add(this.txtHidCode);
            this.Controls.Add(this.txtGrdRowIndex);
            this.Controls.Add(this.pnlTabControlSearch);
            this.Controls.Add(this.pnlTabControlAdd);
            this.Controls.Add(this.lblTag);
            this.Name = "frmGRN";
            this.Text = "GRN";
            this.Load += new System.EventHandler(this.frmGRN_Load);
            this.Controls.SetChildIndex(this.lblTag, 0);
            this.Controls.SetChildIndex(this.pnlTabControlAdd, 0);
            this.Controls.SetChildIndex(this.pnlTabControlSearch, 0);
            this.Controls.SetChildIndex(this.txtGrdRowIndex, 0);
            this.Controls.SetChildIndex(this.txtHidCode, 0);
            this.pnlTabControlAdd.ResumeLayout(false);
            this.pnlTabControlAdd.PerformLayout();
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
        private System.Windows.Forms.TextBox txtTotQty;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlUser;
        private System.Windows.Forms.TextBox txtIndentNo;
        private System.Windows.Forms.DateTimePicker StockDt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHdActiveYN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSubSave;
        private System.Windows.Forms.DataGridView grdDtl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DActiveYN;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
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
    }
}