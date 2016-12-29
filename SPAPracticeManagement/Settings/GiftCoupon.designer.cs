namespace SPAPracticeManagement.Settings
{
    partial class GiftCoupon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiftCoupon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txt_Validity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_CouponName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grdCoupon = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CouponAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txt_CouponId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_UserNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.txt_CouponAmt = new System.Windows.Forms.TextBox();
            this.lbl_CouponAmt = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoupon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(157, 132);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(626, 23);
            this.panel6.TabIndex = 77;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "Gift Coupon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(488, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 142;
            this.label5.Text = "(Days)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(402, 378);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 36);
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
            this.btnSave.Location = new System.Drawing.Point(306, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt_Validity
            // 
            this.txt_Validity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Validity.Location = new System.Drawing.Point(306, 259);
            this.txt_Validity.MaxLength = 7;
            this.txt_Validity.Name = "txt_Validity";
            this.txt_Validity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Validity.Size = new System.Drawing.Size(179, 23);
            this.txt_Validity.TabIndex = 12;
            this.txt_Validity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Validity.TextChanged += new System.EventHandler(this.txt_Validity_TextChanged);
            this.txt_Validity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Validity_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(233, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 138;
            this.label6.Text = "* Validity :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txt_CouponName
            // 
            this.txt_CouponName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CouponName.Location = new System.Drawing.Point(305, 201);
            this.txt_CouponName.MaxLength = 50;
            this.txt_CouponName.Name = "txt_CouponName";
            this.txt_CouponName.Size = new System.Drawing.Size(179, 23);
            this.txt_CouponName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(194, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 136;
            this.label4.Text = "* Coupon Name :";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(159, 424);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(624, 25);
            this.panel5.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gift Coupon List";
            // 
            // grdCoupon
            // 
            this.grdCoupon.AllowUserToAddRows = false;
            this.grdCoupon.AllowUserToDeleteRows = false;
            this.grdCoupon.AllowUserToOrderColumns = true;
            this.grdCoupon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCoupon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCoupon.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdCoupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCoupon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DrServiceId,
            this.RateType,
            this.CouponAmount,
            this.Amount,
            this.StartingDate,
            this.NoOfUser,
            this.IsActive,
            this.Edit,
            this.Delete});
            this.grdCoupon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdCoupon.Location = new System.Drawing.Point(160, 455);
            this.grdCoupon.MultiSelect = false;
            this.grdCoupon.Name = "grdCoupon";
            this.grdCoupon.RowHeadersVisible = false;
            this.grdCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCoupon.Size = new System.Drawing.Size(622, 52);
            this.grdCoupon.TabIndex = 148;
            this.grdCoupon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCoupon_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // DrServiceId
            // 
            this.DrServiceId.DataPropertyName = "Coupon_Id";
            this.DrServiceId.HeaderText = "CouponId";
            this.DrServiceId.Name = "DrServiceId";
            this.DrServiceId.Visible = false;
            // 
            // RateType
            // 
            this.RateType.DataPropertyName = "Coupan_Name";
            this.RateType.HeaderText = "Coupan Name";
            this.RateType.Name = "RateType";
            // 
            // CouponAmount
            // 
            this.CouponAmount.DataPropertyName = "coupon_amt";
            this.CouponAmount.HeaderText = "Coupon Amount";
            this.CouponAmount.Name = "CouponAmount";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Coupan_Validity";
            this.Amount.HeaderText = "CoupanValidity";
            this.Amount.Name = "Amount";
            // 
            // StartingDate
            // 
            this.StartingDate.DataPropertyName = "Coupan_SDateVld";
            this.StartingDate.HeaderText = "StartingDate";
            this.StartingDate.Name = "StartingDate";
            // 
            // NoOfUser
            // 
            this.NoOfUser.DataPropertyName = "Coupan_NoOfUser";
            this.NoOfUser.HeaderText = "NoOfUse";
            this.NoOfUser.Name = "NoOfUser";
            // 
            // IsActive
            // 
            this.IsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.Name = "IsActive";
            this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsActive.Width = 70;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.Width = 31;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 44;
            // 
            // txt_CouponId
            // 
            this.txt_CouponId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CouponId.Location = new System.Drawing.Point(305, 174);
            this.txt_CouponId.MaxLength = 50;
            this.txt_CouponId.Name = "txt_CouponId";
            this.txt_CouponId.Size = new System.Drawing.Size(179, 23);
            this.txt_CouponId.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(216, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 149;
            this.label8.Text = "* Coupon Id :";
            // 
            // txt_UserNo
            // 
            this.txt_UserNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserNo.Location = new System.Drawing.Point(307, 316);
            this.txt_UserNo.MaxLength = 50;
            this.txt_UserNo.Name = "txt_UserNo";
            this.txt_UserNo.Size = new System.Drawing.Size(179, 23);
            this.txt_UserNo.TabIndex = 14;
            this.txt_UserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_UserNo.TextChanged += new System.EventHandler(this.txt_UserNo_TextChanged);
            this.txt_UserNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_UserNo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(218, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 16);
            this.label9.TabIndex = 151;
            this.label9.Text = "* No Of Use :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(199, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 153;
            this.label10.Text = "* Starting Date :";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(306, 288);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(180, 20);
            this.dateTimePicker3.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(237, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 16);
            this.label11.TabIndex = 157;
            this.label11.Text = "Is Active :";
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.Checked = true;
            this.chk_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Active.Location = new System.Drawing.Point(310, 351);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(15, 14);
            this.chk_Active.TabIndex = 15;
            this.chk_Active.UseVisualStyleBackColor = true;
            // 
            // txt_CouponAmt
            // 
            this.txt_CouponAmt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CouponAmt.Location = new System.Drawing.Point(305, 230);
            this.txt_CouponAmt.MaxLength = 50;
            this.txt_CouponAmt.Name = "txt_CouponAmt";
            this.txt_CouponAmt.Size = new System.Drawing.Size(179, 23);
            this.txt_CouponAmt.TabIndex = 11;
            this.txt_CouponAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_CouponAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CouponAmt_KeyPress);
            // 
            // lbl_CouponAmt
            // 
            this.lbl_CouponAmt.AutoSize = true;
            this.lbl_CouponAmt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_CouponAmt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CouponAmt.Location = new System.Drawing.Point(183, 233);
            this.lbl_CouponAmt.Name = "lbl_CouponAmt";
            this.lbl_CouponAmt.Size = new System.Drawing.Size(120, 16);
            this.lbl_CouponAmt.TabIndex = 159;
            this.lbl_CouponAmt.Text = "* Coupon Amount :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(488, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 16);
            this.label12.TabIndex = 160;
            this.label12.Text = "(Rs)";
            // 
            // GiftCoupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 515);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_CouponAmt);
            this.Controls.Add(this.lbl_CouponAmt);
            this.Controls.Add(this.chk_Active);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_UserNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_CouponId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grdCoupon);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txt_Validity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_CouponName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel6);
            this.Name = "GiftCoupon";
            this.Text = "Gift Coupon";
            this.Load += new System.EventHandler(this.AddRate_Load);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txt_CouponName, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txt_Validity, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.grdCoupon, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txt_CouponId, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txt_UserNo, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.dateTimePicker3, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.chk_Active, 0);
            this.Controls.SetChildIndex(this.lbl_CouponAmt, 0);
            this.Controls.SetChildIndex(this.txt_CouponAmt, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoupon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt_Validity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_CouponName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdCoupon;
        private System.Windows.Forms.TextBox txt_CouponId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_UserNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.TextBox txt_CouponAmt;
        private System.Windows.Forms.Label lbl_CouponAmt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CouponAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}