namespace SPAPracticeManagement.Appointments
{
    partial class AppointmentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentList));
            this.pnlTab = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.group_purpose = new System.Windows.Forms.GroupBox();
            this.radio_all = new System.Windows.Forms.RadioButton();
            this.radio_service = new System.Windows.Forms.RadioButton();
            this.radio_package = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlServiceType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelAppointment = new System.Windows.Forms.Button();
            this.txtToDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdClientAccount = new System.Windows.Forms.DataGridView();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AppointmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTab.SuspendLayout();
            this.group_purpose.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTab
            // 
            this.pnlTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTab.Controls.Add(this.label3);
            this.pnlTab.Controls.Add(this.group_purpose);
            this.pnlTab.Controls.Add(this.panel7);
            this.pnlTab.Controls.Add(this.ddlServiceType);
            this.pnlTab.Controls.Add(this.label7);
            this.pnlTab.Controls.Add(this.btnCancelAppointment);
            this.pnlTab.Controls.Add(this.txtToDate);
            this.pnlTab.Controls.Add(this.txtFromDate);
            this.pnlTab.Controls.Add(this.btnClear);
            this.pnlTab.Controls.Add(this.btnSearch);
            this.pnlTab.Controls.Add(this.label5);
            this.pnlTab.Controls.Add(this.label6);
            this.pnlTab.Controls.Add(this.txtClientName);
            this.pnlTab.Controls.Add(this.label4);
            this.pnlTab.Controls.Add(this.grdClientAccount);
            this.pnlTab.Location = new System.Drawing.Point(159, 138);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(622, 372);
            this.pnlTab.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.Location = new System.Drawing.Point(5, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 137;
            this.label3.Text = "Selection Type :";
            // 
            // group_purpose
            // 
            this.group_purpose.Controls.Add(this.radio_all);
            this.group_purpose.Controls.Add(this.radio_service);
            this.group_purpose.Controls.Add(this.radio_package);
            this.group_purpose.Location = new System.Drawing.Point(121, 39);
            this.group_purpose.Name = "group_purpose";
            this.group_purpose.Size = new System.Drawing.Size(270, 33);
            this.group_purpose.TabIndex = 138;
            this.group_purpose.TabStop = false;
            // 
            // radio_all
            // 
            this.radio_all.AutoSize = true;
            this.radio_all.Checked = true;
            this.radio_all.Location = new System.Drawing.Point(8, 9);
            this.radio_all.Name = "radio_all";
            this.radio_all.Size = new System.Drawing.Size(57, 17);
            this.radio_all.TabIndex = 124;
            this.radio_all.TabStop = true;
            this.radio_all.Text = "By All :";
            this.radio_all.UseVisualStyleBackColor = true;
            this.radio_all.CheckedChanged += new System.EventHandler(this.radio_all_CheckedChanged);
            // 
            // radio_service
            // 
            this.radio_service.AutoSize = true;
            this.radio_service.Location = new System.Drawing.Point(81, 9);
            this.radio_service.Name = "radio_service";
            this.radio_service.Size = new System.Drawing.Size(79, 17);
            this.radio_service.TabIndex = 123;
            this.radio_service.Text = "By Service:";
            this.radio_service.UseVisualStyleBackColor = true;
            this.radio_service.CheckedChanged += new System.EventHandler(this.radio_service_CheckedChanged);
            // 
            // radio_package
            // 
            this.radio_package.AutoSize = true;
            this.radio_package.Location = new System.Drawing.Point(177, 9);
            this.radio_package.Name = "radio_package";
            this.radio_package.Size = new System.Drawing.Size(86, 17);
            this.radio_package.TabIndex = 122;
            this.radio_package.Text = "By Package:";
            this.radio_package.UseVisualStyleBackColor = true;
            this.radio_package.CheckedChanged += new System.EventHandler(this.radio_package_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(6, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(610, 29);
            this.panel7.TabIndex = 123;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(23, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "Search Appointment";
            // 
            // ddlServiceType
            // 
            this.ddlServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlServiceType.DropDownWidth = 151;
            this.ddlServiceType.FormattingEnabled = true;
            this.ddlServiceType.Location = new System.Drawing.Point(121, 80);
            this.ddlServiceType.Name = "ddlServiceType";
            this.ddlServiceType.Size = new System.Drawing.Size(268, 21);
            this.ddlServiceType.TabIndex = 122;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 121;
            this.label7.Text = "Service Type :";
            // 
            // btnCancelAppointment
            // 
            this.btnCancelAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnCancelAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAppointment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAppointment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelAppointment.Location = new System.Drawing.Point(465, 136);
            this.btnCancelAppointment.Name = "btnCancelAppointment";
            this.btnCancelAppointment.Size = new System.Drawing.Size(147, 26);
            this.btnCancelAppointment.TabIndex = 120;
            this.btnCancelAppointment.Text = "Cancel Appointment";
            this.btnCancelAppointment.UseVisualStyleBackColor = false;
            this.btnCancelAppointment.Click += new System.EventHandler(this.btnCancelAppointment_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.Checked = false;
            this.txtToDate.CustomFormat = "dd/MMM/yyyy";
            this.txtToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtToDate.Location = new System.Drawing.Point(495, 75);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ShowCheckBox = true;
            this.txtToDate.Size = new System.Drawing.Size(117, 23);
            this.txtToDate.TabIndex = 119;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Checked = false;
            this.txtFromDate.CustomFormat = "dd/MMM/yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFromDate.Location = new System.Drawing.Point(495, 44);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ShowCheckBox = true;
            this.txtFromDate.Size = new System.Drawing.Size(117, 23);
            this.txtFromDate.TabIndex = 118;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(203, 136);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 26);
            this.btnClear.TabIndex = 117;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(121, 136);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 116;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(427, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 115;
            this.label5.Text = "To Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(412, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 114;
            this.label6.Text = "From Date :";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(121, 107);
            this.txtClientName.MaxLength = 50;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(268, 23);
            this.txtClientName.TabIndex = 113;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 112;
            this.label4.Text = "Client Name :";
            // 
            // grdClientAccount
            // 
            this.grdClientAccount.AllowDrop = true;
            this.grdClientAccount.AllowUserToAddRows = false;
            this.grdClientAccount.AllowUserToDeleteRows = false;
            this.grdClientAccount.AllowUserToOrderColumns = true;
            this.grdClientAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdClientAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdClientAccount.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdClientAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdClientAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Email,
            this.Mobile,
            this.Select,
            this.AppointmentId,
            this.PatientName,
            this.ServiceType,
            this.CaseHistory,
            this.AppointmentTime,
            this.Paid,
            this.Due,
            this.Status,
            this.Print});
            this.grdClientAccount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdClientAccount.Location = new System.Drawing.Point(3, 202);
            this.grdClientAccount.MultiSelect = false;
            this.grdClientAccount.Name = "grdClientAccount";
            this.grdClientAccount.RowHeadersVisible = false;
            this.grdClientAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdClientAccount.Size = new System.Drawing.Size(616, 166);
            this.grdClientAccount.TabIndex = 111;
            this.grdClientAccount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdClientAccount_CellContentClick);
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Visible = false;
            // 
            // Mobile
            // 
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            this.Mobile.Visible = false;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 43;
            // 
            // AppointmentId
            // 
            this.AppointmentId.DataPropertyName = "AppointmentId";
            this.AppointmentId.HeaderText = "Appointment Id";
            this.AppointmentId.Name = "AppointmentId";
            this.AppointmentId.Visible = false;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "ClientName";
            this.PatientName.HeaderText = "Client Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // ServiceType
            // 
            this.ServiceType.DataPropertyName = "Service";
            this.ServiceType.HeaderText = "ServiceType";
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.ReadOnly = true;
            // 
            // CaseHistory
            // 
            this.CaseHistory.DataPropertyName = "CaseHistory";
            this.CaseHistory.HeaderText = "Case History";
            this.CaseHistory.Name = "CaseHistory";
            this.CaseHistory.ReadOnly = true;
            this.CaseHistory.Visible = false;
            // 
            // AppointmentTime
            // 
            this.AppointmentTime.DataPropertyName = "AppointmentTime";
            this.AppointmentTime.HeaderText = "Appointment Time";
            this.AppointmentTime.Name = "AppointmentTime";
            this.AppointmentTime.ReadOnly = true;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "TotalPaid";
            this.Paid.HeaderText = "Paid (Rs)";
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            // 
            // Due
            // 
            this.Due.DataPropertyName = "Discount";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Due.DefaultCellStyle = dataGridViewCellStyle1;
            this.Due.HeaderText = "Discount (Rs)";
            this.Due.Name = "Due";
            this.Due.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Print
            // 
            this.Print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Print.HeaderText = "Print";
            this.Print.Image = ((System.Drawing.Image)(resources.GetObject("Print.Image")));
            this.Print.Name = "Print";
            this.Print.Width = 34;
            // 
            // AppointmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.pnlTab);
            this.Name = "AppointmentList";
            this.Text = "Appointment List";
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlTab.ResumeLayout(false);
            this.pnlTab.PerformLayout();
            this.group_purpose.ResumeLayout(false);
            this.group_purpose.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.DataGridView grdClientAccount;
        private System.Windows.Forms.ComboBox ddlServiceType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelAppointment;
        private System.Windows.Forms.DateTimePicker txtToDate;
        private System.Windows.Forms.DateTimePicker txtFromDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox group_purpose;
        private System.Windows.Forms.RadioButton radio_all;
        private System.Windows.Forms.RadioButton radio_service;
        private System.Windows.Forms.RadioButton radio_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn Print;

    }
}