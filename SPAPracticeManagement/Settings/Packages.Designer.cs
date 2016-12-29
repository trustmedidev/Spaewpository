namespace SPAPracticeManagement.Settings
{
    partial class Packages
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Packages));
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbl_Package = new System.Windows.Forms.Label();
            this.lbl_PackageName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPackage = new System.Windows.Forms.Button();
            this.lbl_PackageID = new System.Windows.Forms.Label();
            this.txt_PackageName = new System.Windows.Forms.TextBox();
            this.txt_PackageId = new System.Windows.Forms.TextBox();
            this.chklst_PackageItem = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Rate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_validity = new System.Windows.Forms.Label();
            this.lbl_packageList = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.gvPackageList = new System.Windows.Forms.DataGridView();
            this.PackageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Validity_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_totalamount = new System.Windows.Forms.Label();
            this.dt_validity = new System.Windows.Forms.DateTimePicker();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkAllActive = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTaxList = new System.Windows.Forms.CheckedListBox();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPackageList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel7.Controls.Add(this.lbl_Package);
            this.panel7.Location = new System.Drawing.Point(155, 133);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(625, 23);
            this.panel7.TabIndex = 119;
            // 
            // lbl_Package
            // 
            this.lbl_Package.AutoSize = true;
            this.lbl_Package.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Package.ForeColor = System.Drawing.Color.White;
            this.lbl_Package.Location = new System.Drawing.Point(4, 5);
            this.lbl_Package.Name = "lbl_Package";
            this.lbl_Package.Size = new System.Drawing.Size(116, 18);
            this.lbl_Package.TabIndex = 4;
            this.lbl_Package.Text = "Package Detail";
            // 
            // lbl_PackageName
            // 
            this.lbl_PackageName.AutoSize = true;
            this.lbl_PackageName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_PackageName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PackageName.Location = new System.Drawing.Point(265, 221);
            this.lbl_PackageName.Name = "lbl_PackageName";
            this.lbl_PackageName.Size = new System.Drawing.Size(113, 16);
            this.lbl_PackageName.TabIndex = 124;
            this.lbl_PackageName.Text = "* Package Name :";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(465, 487);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 26);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPackage
            // 
            this.btnPackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnPackage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPackage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPackage.Location = new System.Drawing.Point(384, 487);
            this.btnPackage.Name = "btnPackage";
            this.btnPackage.Size = new System.Drawing.Size(75, 26);
            this.btnPackage.TabIndex = 20;
            this.btnPackage.Text = "Save";
            this.btnPackage.UseVisualStyleBackColor = false;
            this.btnPackage.Click += new System.EventHandler(this.btnPackage_Click);
            // 
            // lbl_PackageID
            // 
            this.lbl_PackageID.AutoSize = true;
            this.lbl_PackageID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_PackageID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PackageID.Location = new System.Drawing.Point(298, 195);
            this.lbl_PackageID.Name = "lbl_PackageID";
            this.lbl_PackageID.Size = new System.Drawing.Size(80, 16);
            this.lbl_PackageID.TabIndex = 120;
            this.lbl_PackageID.Text = "Package ID :";
            // 
            // txt_PackageName
            // 
            this.txt_PackageName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PackageName.Location = new System.Drawing.Point(382, 221);
            this.txt_PackageName.MaxLength = 50;
            this.txt_PackageName.Name = "txt_PackageName";
            this.txt_PackageName.Size = new System.Drawing.Size(179, 23);
            this.txt_PackageName.TabIndex = 11;
            this.txt_PackageName.TextChanged += new System.EventHandler(this.txt_PackageName_TextChanged);
            // 
            // txt_PackageId
            // 
            this.txt_PackageId.Location = new System.Drawing.Point(382, 191);
            this.txt_PackageId.Name = "txt_PackageId";
            this.txt_PackageId.Size = new System.Drawing.Size(179, 20);
            this.txt_PackageId.TabIndex = 10;
            // 
            // chklst_PackageItem
            // 
            this.chklst_PackageItem.CheckOnClick = true;
            this.chklst_PackageItem.FormattingEnabled = true;
            this.chklst_PackageItem.Location = new System.Drawing.Point(382, 322);
            this.chklst_PackageItem.Name = "chklst_PackageItem";
            this.chklst_PackageItem.Size = new System.Drawing.Size(179, 64);
            this.chklst_PackageItem.TabIndex = 14;
            this.chklst_PackageItem.SelectedIndexChanged += new System.EventHandler(this.chklst_PackageItem_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(565, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 145;
            this.label5.Text = "(Rs.)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txt_Rate
            // 
            this.txt_Rate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Rate.Location = new System.Drawing.Point(382, 253);
            this.txt_Rate.MaxLength = 7;
            this.txt_Rate.Name = "txt_Rate";
            this.txt_Rate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Rate.Size = new System.Drawing.Size(179, 23);
            this.txt_Rate.TabIndex = 12;
            this.txt_Rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Rate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txt_Rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Rate_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 143;
            this.label6.Text = "* Rate :";
            // 
            // lbl_validity
            // 
            this.lbl_validity.AutoSize = true;
            this.lbl_validity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_validity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_validity.Location = new System.Drawing.Point(308, 288);
            this.lbl_validity.Name = "lbl_validity";
            this.lbl_validity.Size = new System.Drawing.Size(70, 16);
            this.lbl_validity.TabIndex = 146;
            this.lbl_validity.Text = "* Validity :";
            // 
            // lbl_packageList
            // 
            this.lbl_packageList.AutoSize = true;
            this.lbl_packageList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_packageList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_packageList.Location = new System.Drawing.Point(280, 322);
            this.lbl_packageList.Name = "lbl_packageList";
            this.lbl_packageList.Size = new System.Drawing.Size(99, 16);
            this.lbl_packageList.TabIndex = 149;
            this.lbl_packageList.Text = "* Package List :";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(155, 528);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(625, 23);
            this.panel6.TabIndex = 151;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 4;
            this.label10.Text = "Package List";
            // 
            // gvPackageList
            // 
            this.gvPackageList.AllowDrop = true;
            this.gvPackageList.AllowUserToAddRows = false;
            this.gvPackageList.AllowUserToDeleteRows = false;
            this.gvPackageList.AllowUserToOrderColumns = true;
            this.gvPackageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPackageList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPackageList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gvPackageList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvPackageList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PackageID,
            this.Select,
            this.PatientName,
            this.DOB,
            this.Address,
            this.StartingDate,
            this.Validity_Date,
            this.isActive,
            this.Edit,
            this.Delete,
            this.ServiceID,
            this.ServiceName});
            this.gvPackageList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvPackageList.Location = new System.Drawing.Point(155, 560);
            this.gvPackageList.MultiSelect = false;
            this.gvPackageList.Name = "gvPackageList";
            this.gvPackageList.RowHeadersVisible = false;
            this.gvPackageList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPackageList.Size = new System.Drawing.Size(627, 125);
            this.gvPackageList.TabIndex = 150;
            this.gvPackageList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPackageList_CellContentClick);
            // 
            // PackageID
            // 
            this.PackageID.DataPropertyName = "Id";
            this.PackageID.HeaderText = "ID";
            this.PackageID.Name = "PackageID";
            this.PackageID.ReadOnly = true;
            this.PackageID.Visible = false;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Visible = false;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "Package_Name";
            this.PatientName.FillWeight = 57.68687F;
            this.PatientName.HeaderText = "Package Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            this.PatientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DOB
            // 
            this.DOB.DataPropertyName = "ServiceName";
            this.DOB.FillWeight = 57.68687F;
            this.DOB.HeaderText = "Package Items";
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            this.DOB.ToolTipText = "Package Items";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Package_Rate";
            this.Address.FillWeight = 57.68687F;
            this.Address.HeaderText = "Rate";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // StartingDate
            // 
            this.StartingDate.DataPropertyName = "Starting_Date";
            this.StartingDate.HeaderText = "Starting Date";
            this.StartingDate.Name = "StartingDate";
            // 
            // Validity_Date
            // 
            this.Validity_Date.DataPropertyName = "Validity_Date";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Validity_Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.Validity_Date.HeaderText = "Validity Date";
            this.Validity_Date.Name = "Validity_Date";
            // 
            // isActive
            // 
            this.isActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isActive.DataPropertyName = "isActive";
            this.isActive.HeaderText = "IsActive";
            this.isActive.Name = "isActive";
            this.isActive.ReadOnly = true;
            this.isActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isActive.Width = 70;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Edit.FillWeight = 194.1385F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.Width = 31;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 259.7403F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete.Width = 44;
            // 
            // ServiceID
            // 
            this.ServiceID.DataPropertyName = "ServiceId";
            this.ServiceID.HeaderText = "ServiceID";
            this.ServiceID.Name = "ServiceID";
            this.ServiceID.Visible = false;
            // 
            // ServiceName
            // 
            this.ServiceName.DataPropertyName = "ServiceName";
            this.ServiceName.HeaderText = "ServiceName";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            this.ServiceName.Visible = false;
            // 
            // lbl_totalamount
            // 
            this.lbl_totalamount.AutoSize = true;
            this.lbl_totalamount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_totalamount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalamount.Location = new System.Drawing.Point(622, 191);
            this.lbl_totalamount.Name = "lbl_totalamount";
            this.lbl_totalamount.Size = new System.Drawing.Size(90, 16);
            this.lbl_totalamount.TabIndex = 152;
            this.lbl_totalamount.Text = "Total Amount:";
            // 
            // dt_validity
            // 
            this.dt_validity.CustomFormat = "dd/MM/yyyy";
            this.dt_validity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_validity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_validity.Location = new System.Drawing.Point(382, 283);
            this.dt_validity.Name = "dt_validity";
            this.dt_validity.Size = new System.Drawing.Size(180, 23);
            this.dt_validity.TabIndex = 13;
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.Checked = true;
            this.chk_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Active.Location = new System.Drawing.Point(714, 221);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(15, 14);
            this.chk_Active.TabIndex = 17;
            this.chk_Active.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(647, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 165;
            this.label11.Text = "Is Active :";
            // 
            // chkAllActive
            // 
            this.chkAllActive.AutoSize = true;
            this.chkAllActive.Location = new System.Drawing.Point(384, 394);
            this.chkAllActive.Name = "chkAllActive";
            this.chkAllActive.Size = new System.Drawing.Size(70, 17);
            this.chkAllActive.TabIndex = 15;
            this.chkAllActive.Text = "All Active";
            this.chkAllActive.UseVisualStyleBackColor = true;
            this.chkAllActive.CheckedChanged += new System.EventHandler(this.chkAllActive_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(301, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 168;
            this.label8.Text = "Select Tax :";
            // 
            // chkTaxList
            // 
            this.chkTaxList.CheckOnClick = true;
            this.chkTaxList.FormattingEnabled = true;
            this.chkTaxList.Location = new System.Drawing.Point(384, 417);
            this.chkTaxList.Name = "chkTaxList";
            this.chkTaxList.Size = new System.Drawing.Size(177, 64);
            this.chkTaxList.TabIndex = 16;
            this.chkTaxList.SelectedIndexChanged += new System.EventHandler(this.chkTaxList_SelectedIndexChanged);
            // 
            // Packages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 690);
            this.Controls.Add(this.chkAllActive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkTaxList);
            this.Controls.Add(this.chk_Active);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dt_validity);
            this.Controls.Add(this.lbl_totalamount);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.gvPackageList);
            this.Controls.Add(this.lbl_packageList);
            this.Controls.Add(this.lbl_validity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Rate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chklst_PackageItem);
            this.Controls.Add(this.txt_PackageId);
            this.Controls.Add(this.txt_PackageName);
            this.Controls.Add(this.lbl_PackageName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPackage);
            this.Controls.Add(this.lbl_PackageID);
            this.Controls.Add(this.panel7);
            this.Name = "Packages";
            this.Text = "Packages";
            this.Load += new System.EventHandler(this.Packages_Load);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.lbl_PackageID, 0);
            this.Controls.SetChildIndex(this.btnPackage, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.lbl_PackageName, 0);
            this.Controls.SetChildIndex(this.txt_PackageName, 0);
            this.Controls.SetChildIndex(this.txt_PackageId, 0);
            this.Controls.SetChildIndex(this.chklst_PackageItem, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txt_Rate, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lbl_validity, 0);
            this.Controls.SetChildIndex(this.lbl_packageList, 0);
            this.Controls.SetChildIndex(this.gvPackageList, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.lbl_totalamount, 0);
            this.Controls.SetChildIndex(this.dt_validity, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.chk_Active, 0);
            this.Controls.SetChildIndex(this.chkTaxList, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.chkAllActive, 0);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPackageList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbl_Package;
        private System.Windows.Forms.Label lbl_PackageName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPackage;
        private System.Windows.Forms.Label lbl_PackageID;
        private System.Windows.Forms.TextBox txt_PackageName;
        private System.Windows.Forms.TextBox txt_PackageId;
        private System.Windows.Forms.CheckedListBox chklst_PackageItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Rate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_validity;
        private System.Windows.Forms.Label lbl_packageList;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView gvPackageList;
        private System.Windows.Forms.Label lbl_totalamount;
        private System.Windows.Forms.DateTimePicker dt_validity;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkAllActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox chkTaxList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Validity_Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActive;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
    }
}