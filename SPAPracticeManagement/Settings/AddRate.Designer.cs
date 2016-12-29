namespace SPAPracticeManagement.Settings
{
    partial class AddRate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServiceType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grdServiceTypeList = new System.Windows.Forms.DataGridView();
            this.dt_effective = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTaxList = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAllActive = new System.Windows.Forms.CheckBox();
            this.txtTimeExpende = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnImportService = new System.Windows.Forms.Button();
            this.DrServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Effective_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeExpende = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(158, 135);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(620, 29);
            this.panel6.TabIndex = 77;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "Add Service && Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(580, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 142;
            this.label5.Text = "(Rs.)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(490, 418);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 37);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(394, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 36);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(395, 206);
            this.txtRate.MaxLength = 7;
            this.txtRate.Name = "txtRate";
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(179, 23);
            this.txtRate.TabIndex = 11;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(335, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 138;
            this.label6.Text = "* Rate :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtServiceType
            // 
            this.txtServiceType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceType.Location = new System.Drawing.Point(395, 177);
            this.txtServiceType.MaxLength = 50;
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.Size = new System.Drawing.Size(179, 23);
            this.txtServiceType.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 136;
            this.label4.Text = "* Service Name :";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(158, 460);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(622, 29);
            this.panel5.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-1, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Service && Rate List";
            // 
            // grdServiceTypeList
            // 
            this.grdServiceTypeList.AllowUserToAddRows = false;
            this.grdServiceTypeList.AllowUserToDeleteRows = false;
            this.grdServiceTypeList.AllowUserToOrderColumns = true;
            this.grdServiceTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdServiceTypeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdServiceTypeList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdServiceTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServiceTypeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrServiceId,
            this.RateType,
            this.Amount,
            this.Effective_Date,
            this.TimeExpende,
            this.IsActive,
            this.Edit,
            this.Delete});
            this.grdServiceTypeList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdServiceTypeList.Location = new System.Drawing.Point(158, 495);
            this.grdServiceTypeList.MultiSelect = false;
            this.grdServiceTypeList.Name = "grdServiceTypeList";
            this.grdServiceTypeList.RowHeadersVisible = false;
            this.grdServiceTypeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdServiceTypeList.Size = new System.Drawing.Size(624, 97);
            this.grdServiceTypeList.TabIndex = 148;
            this.grdServiceTypeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdServiceTypeList_CellContentClick);
            // 
            // dt_effective
            // 
            this.dt_effective.CustomFormat = "dd/MM/yyyy";
            this.dt_effective.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_effective.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_effective.Location = new System.Drawing.Point(395, 235);
            this.dt_effective.Name = "dt_effective";
            this.dt_effective.Size = new System.Drawing.Size(179, 23);
            this.dt_effective.TabIndex = 12;
            this.dt_effective.ValueChanged += new System.EventHandler(this.dt_effective_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(283, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 16);
            this.label12.TabIndex = 160;
            this.label12.Text = "* Effective Date :";
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.Location = new System.Drawing.Point(396, 375);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(15, 14);
            this.chk_Active.TabIndex = 16;
            this.chk_Active.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(325, 371);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 163;
            this.label11.Text = "Is Active :";
            // 
            // chkTaxList
            // 
            this.chkTaxList.CheckOnClick = true;
            this.chkTaxList.FormattingEnabled = true;
            this.chkTaxList.Location = new System.Drawing.Point(395, 292);
            this.chkTaxList.Name = "chkTaxList";
            this.chkTaxList.Size = new System.Drawing.Size(177, 49);
            this.chkTaxList.TabIndex = 14;
            this.chkTaxList.SelectedIndexChanged += new System.EventHandler(this.chkTaxList_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(312, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 165;
            this.label8.Text = "Select Tax :";
            // 
            // chkAllActive
            // 
            this.chkAllActive.AutoSize = true;
            this.chkAllActive.Location = new System.Drawing.Point(395, 269);
            this.chkAllActive.Name = "chkAllActive";
            this.chkAllActive.Size = new System.Drawing.Size(70, 17);
            this.chkAllActive.TabIndex = 13;
            this.chkAllActive.Text = "All Active";
            this.chkAllActive.UseVisualStyleBackColor = true;
            this.chkAllActive.CheckedChanged += new System.EventHandler(this.chkAllActive_CheckedChanged);
            // 
            // txtTimeExpende
            // 
            this.txtTimeExpende.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeExpende.Location = new System.Drawing.Point(394, 345);
            this.txtTimeExpende.MaxLength = 7;
            this.txtTimeExpende.Name = "txtTimeExpende";
            this.txtTimeExpende.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTimeExpende.Size = new System.Drawing.Size(179, 23);
            this.txtTimeExpende.TabIndex = 15;
            this.txtTimeExpende.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeExpende.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeExpende_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(279, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 16);
            this.label9.TabIndex = 168;
            this.label9.Text = "* Time Expende :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(579, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 16);
            this.label10.TabIndex = 169;
            this.label10.Text = "min";
            // 
            // btnImportService
            // 
            this.btnImportService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnImportService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportService.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportService.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImportService.Location = new System.Drawing.Point(648, 424);
            this.btnImportService.Name = "btnImportService";
            this.btnImportService.Size = new System.Drawing.Size(133, 30);
            this.btnImportService.TabIndex = 22;
            this.btnImportService.Text = "Import Service";
            this.btnImportService.UseVisualStyleBackColor = false;
            this.btnImportService.Click += new System.EventHandler(this.btnImportService_Click);
            // 
            // DrServiceId
            // 
            this.DrServiceId.DataPropertyName = "ServiceId";
            this.DrServiceId.HeaderText = "Service Id";
            this.DrServiceId.Name = "DrServiceId";
            this.DrServiceId.Visible = false;
            // 
            // RateType
            // 
            this.RateType.DataPropertyName = "ServiceName";
            this.RateType.HeaderText = "Service Type";
            this.RateType.Name = "RateType";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Effective_Date
            // 
            this.Effective_Date.DataPropertyName = "Effective_Date";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Effective_Date.DefaultCellStyle = dataGridViewCellStyle1;
            this.Effective_Date.HeaderText = "Effective Date";
            this.Effective_Date.Name = "Effective_Date";
            // 
            // TimeExpende
            // 
            this.TimeExpende.DataPropertyName = "TimeExpende";
            this.TimeExpende.HeaderText = "Time Expende";
            this.TimeExpende.Name = "TimeExpende";
            // 
            // IsActive
            // 
            this.IsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.Name = "IsActive";
            this.IsActive.Width = 51;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.Edit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 31;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.Delete.DefaultCellStyle = dataGridViewCellStyle3;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 44;
            // 
            // AddRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 596);
            this.Controls.Add(this.btnImportService);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTimeExpende);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkAllActive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkTaxList);
            this.Controls.Add(this.chk_Active);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dt_effective);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.grdServiceTypeList);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtServiceType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel6);
            this.Name = "AddRate";
            this.Text = "Rate";
            this.Load += new System.EventHandler(this.AddRate_Load);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtServiceType, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtRate, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.grdServiceTypeList, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.dt_effective, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.chk_Active, 0);
            this.Controls.SetChildIndex(this.chkTaxList, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.chkAllActive, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtTimeExpende, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.btnImportService, 0);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceTypeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtServiceType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView grdServiceTypeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dt_effective;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox chkTaxList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkAllActive;
        private System.Windows.Forms.TextBox txtTimeExpende;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnImportService;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Effective_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeExpende;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}