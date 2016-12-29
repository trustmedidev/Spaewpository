namespace SPAPracticeManagement.PackageBookings
{
    partial class PackageBooking
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageBooking));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Service = new System.Windows.Forms.Label();
            this.ddl_package = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.btn_CheckAvail = new System.Windows.Forms.Button();
            this.txtDOB = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.grdPatientAccount = new System.Windows.Forms.DataGridView();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_packageList = new System.Windows.Forms.Label();
            this.chklst_PackageItem = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ddl_validity = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_packageid = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(453, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 138;
            this.label2.Text = "Advance :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 134;
            this.label1.Text = "Amount Received :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.PaleVioletRed;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 22);
            this.panel2.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Book Appointment";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(156, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(628, 22);
            this.panel3.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(19, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Package Booking  :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label_Service
            // 
            this.label_Service.AutoSize = true;
            this.label_Service.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Service.Location = new System.Drawing.Point(165, 253);
            this.label_Service.Name = "label_Service";
            this.label_Service.Size = new System.Drawing.Size(115, 16);
            this.label_Service.TabIndex = 142;
            this.label_Service.Text = "* Select Package :";
            // 
            // ddl_package
            // 
            this.ddl_package.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_package.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_package.FormattingEnabled = true;
            this.ddl_package.Items.AddRange(new object[] {
            "Select Month",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.ddl_package.Location = new System.Drawing.Point(284, 250);
            this.ddl_package.Name = "ddl_package";
            this.ddl_package.Size = new System.Drawing.Size(205, 24);
            this.ddl_package.TabIndex = 143;
            this.ddl_package.SelectedIndexChanged += new System.EventHandler(this.ddl_package_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 144;
            this.label4.Text = "* Select Client :";
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.Location = new System.Drawing.Point(284, 177);
            this.txtClientName.MaxLength = 150;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(205, 23);
            this.txtClientName.TabIndex = 145;
            this.txtClientName.TextChanged += new System.EventHandler(this.txtClientName_TextChanged_1);
            // 
            // btn_CheckAvail
            // 
            this.btn_CheckAvail.BackColor = System.Drawing.Color.White;
            this.btn_CheckAvail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CheckAvail.BackgroundImage")));
            this.btn_CheckAvail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CheckAvail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CheckAvail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CheckAvail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_CheckAvail.Location = new System.Drawing.Point(493, 172);
            this.btn_CheckAvail.Name = "btn_CheckAvail";
            this.btn_CheckAvail.Size = new System.Drawing.Size(32, 32);
            this.btn_CheckAvail.TabIndex = 156;
            this.btn_CheckAvail.UseVisualStyleBackColor = false;
            this.btn_CheckAvail.Click += new System.EventHandler(this.btn_CheckAvail_Click);
            // 
            // txtDOB
            // 
            this.txtDOB.CustomFormat = "MM/dd/yyyy";
            this.txtDOB.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDOB.Location = new System.Drawing.Point(288, 416);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(207, 23);
            this.txtDOB.TabIndex = 159;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(223, 421);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 158;
            this.label12.Text = "* Date :";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(509, 439);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 26);
            this.btnClear.TabIndex = 164;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.Location = new System.Drawing.Point(403, 439);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(88, 26);
            this.btnContinue.TabIndex = 163;
            this.btnContinue.Text = "Save";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(153, 475);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(631, 22);
            this.panel6.TabIndex = 166;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 18);
            this.label10.TabIndex = 4;
            this.label10.Text = "Booking Package List :";
            // 
            // grdPatientAccount
            // 
            this.grdPatientAccount.AllowUserToAddRows = false;
            this.grdPatientAccount.AllowUserToDeleteRows = false;
            this.grdPatientAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPatientAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPatientAccount.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdPatientAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdPatientAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatientName,
            this.ServiceType,
            this.CaseHistory,
            this.AppointmentTime,
            this.Discount,
            this.Paid});
            this.grdPatientAccount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPatientAccount.Location = new System.Drawing.Point(155, 501);
            this.grdPatientAccount.Name = "grdPatientAccount";
            this.grdPatientAccount.ReadOnly = true;
            this.grdPatientAccount.RowHeadersVisible = false;
            this.grdPatientAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPatientAccount.Size = new System.Drawing.Size(626, 130);
            this.grdPatientAccount.TabIndex = 167;
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
            this.ServiceType.DataPropertyName = "PackageID";
            this.ServiceType.HeaderText = "Package ID";
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.ReadOnly = true;
            // 
            // CaseHistory
            // 
            this.CaseHistory.DataPropertyName = "PackageName";
            this.CaseHistory.HeaderText = "Package Name";
            this.CaseHistory.Name = "CaseHistory";
            this.CaseHistory.ReadOnly = true;
            // 
            // AppointmentTime
            // 
            this.AppointmentTime.DataPropertyName = "ServiceName";
            this.AppointmentTime.HeaderText = "Service Name";
            this.AppointmentTime.Name = "AppointmentTime";
            this.AppointmentTime.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "PkgBookingDate";
            this.Discount.HeaderText = "Booking Date";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "ValidityDate";
            this.Paid.HeaderText = "Validity Date";
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            // 
            // lbl_packageList
            // 
            this.lbl_packageList.AutoSize = true;
            this.lbl_packageList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_packageList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_packageList.Location = new System.Drawing.Point(186, 285);
            this.lbl_packageList.Name = "lbl_packageList";
            this.lbl_packageList.Size = new System.Drawing.Size(94, 16);
            this.lbl_packageList.TabIndex = 174;
            this.lbl_packageList.Text = "* Service List :";
            // 
            // chklst_PackageItem
            // 
            this.chklst_PackageItem.FormattingEnabled = true;
            this.chklst_PackageItem.Location = new System.Drawing.Point(284, 285);
            this.chklst_PackageItem.Name = "chklst_PackageItem";
            this.chklst_PackageItem.Size = new System.Drawing.Size(205, 94);
            this.chklst_PackageItem.TabIndex = 173;
            this.chklst_PackageItem.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklst_PackageItem_ItemCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(154, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 16);
            this.label8.TabIndex = 178;
            this.label8.Text = "* Valid Month Upto :";
            // 
            // ddl_validity
            // 
            this.ddl_validity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_validity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_validity.FormattingEnabled = true;
            this.ddl_validity.Items.AddRange(new object[] {
            "Select Month",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.ddl_validity.Location = new System.Drawing.Point(284, 388);
            this.ddl_validity.Name = "ddl_validity";
            this.ddl_validity.Size = new System.Drawing.Size(205, 24);
            this.ddl_validity.TabIndex = 179;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(178, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 180;
            this.label15.Text = "* Package ID :";
            // 
            // txt_packageid
            // 
            this.txt_packageid.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_packageid.Location = new System.Drawing.Point(284, 212);
            this.txt_packageid.MaxLength = 150;
            this.txt_packageid.Name = "txt_packageid";
            this.txt_packageid.ReadOnly = true;
            this.txt_packageid.Size = new System.Drawing.Size(205, 23);
            this.txt_packageid.TabIndex = 181;
            // 
            // PackageBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.Controls.Add(this.txt_packageid);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ddl_validity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_packageList);
            this.Controls.Add(this.chklst_PackageItem);
            this.Controls.Add(this.grdPatientAccount);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtDOB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_CheckAvail);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddl_package);
            this.Controls.Add(this.label_Service);
            this.Controls.Add(this.panel3);
            this.Name = "PackageBooking";
            this.Text = "Package Booking";
            this.Load += new System.EventHandler(this.BookAppointment_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label_Service, 0);
            this.Controls.SetChildIndex(this.ddl_package, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtClientName, 0);
            this.Controls.SetChildIndex(this.btn_CheckAvail, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtDOB, 0);
            this.Controls.SetChildIndex(this.btnContinue, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.grdPatientAccount, 0);
            this.Controls.SetChildIndex(this.chklst_PackageItem, 0);
            this.Controls.SetChildIndex(this.lbl_packageList, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.ddl_validity, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txt_packageid, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Service;
        private System.Windows.Forms.ComboBox ddl_package;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button btn_CheckAvail;
        private System.Windows.Forms.DateTimePicker txtDOB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView grdPatientAccount;
        private System.Windows.Forms.Label lbl_packageList;
        private System.Windows.Forms.CheckedListBox chklst_PackageItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddl_validity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_packageid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
    }
}
