namespace SPAPracticeManagement.InventoryMaster
{
    partial class frmBatch
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DtExpiry = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlItem = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtActive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lblTag.TabIndex = 130;
            // 
            // pnlTabControlAdd
            // 
            this.pnlTabControlAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlAdd.Controls.Add(this.txtDescription);
            this.pnlTabControlAdd.Controls.Add(this.label6);
            this.pnlTabControlAdd.Controls.Add(this.DtExpiry);
            this.pnlTabControlAdd.Controls.Add(this.label5);
            this.pnlTabControlAdd.Controls.Add(this.txtRate);
            this.pnlTabControlAdd.Controls.Add(this.label3);
            this.pnlTabControlAdd.Controls.Add(this.ddlItem);
            this.pnlTabControlAdd.Controls.Add(this.btnUpdate);
            this.pnlTabControlAdd.Controls.Add(this.btnClear);
            this.pnlTabControlAdd.Controls.Add(this.btnSave);
            this.pnlTabControlAdd.Controls.Add(this.txtActive);
            this.pnlTabControlAdd.Controls.Add(this.label7);
            this.pnlTabControlAdd.Controls.Add(this.txtBatchNo);
            this.pnlTabControlAdd.Controls.Add(this.label2);
            this.pnlTabControlAdd.Controls.Add(this.label4);
            this.pnlTabControlAdd.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.pnlTabControlAdd.Location = new System.Drawing.Point(243, 201);
            this.pnlTabControlAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlAdd.Name = "pnlTabControlAdd";
            this.pnlTabControlAdd.Size = new System.Drawing.Size(730, 514);
            this.pnlTabControlAdd.TabIndex = 131;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(168, 141);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(356, 27);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 21);
            this.label6.TabIndex = 126;
            this.label6.Text = "Description :";
            // 
            // DtExpiry
            // 
            this.DtExpiry.CustomFormat = "dd/MM/yyyy";
            this.DtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtExpiry.Location = new System.Drawing.Point(169, 176);
            this.DtExpiry.Name = "DtExpiry";
            this.DtExpiry.Size = new System.Drawing.Size(129, 27);
            this.DtExpiry.TabIndex = 4;
            this.DtExpiry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtExpiry_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 21);
            this.label5.TabIndex = 124;
            this.label5.Text = "Expiry Date :";
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(169, 105);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRate.MaxLength = 50;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(356, 27);
            this.txtRate.TabIndex = 2;
            this.txtRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 123;
            this.label3.Text = "Rate :";
            // 
            // ddlItem
            // 
            this.ddlItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlItem.FormattingEnabled = true;
            this.ddlItem.Location = new System.Drawing.Point(168, 28);
            this.ddlItem.Margin = new System.Windows.Forms.Padding(4);
            this.ddlItem.Name = "ddlItem";
            this.ddlItem.Size = new System.Drawing.Size(357, 27);
            this.ddlItem.TabIndex = 0;
            this.ddlItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlItem_KeyUp);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(315, 285);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 32);
            this.btnUpdate.TabIndex = 6;
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
            this.btnClear.Location = new System.Drawing.Point(431, 245);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 32);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(315, 245);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyUp);
            // 
            // txtActive
            // 
            this.txtActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActive.Location = new System.Drawing.Point(485, 176);
            this.txtActive.Margin = new System.Windows.Forms.Padding(4);
            this.txtActive.MaxLength = 1;
            this.txtActive.Name = "txtActive";
            this.txtActive.Size = new System.Drawing.Size(39, 27);
            this.txtActive.TabIndex = 5;
            this.txtActive.Text = "Y";
            this.txtActive.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtActive_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(392, 179);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 21);
            this.label7.TabIndex = 119;
            this.label7.Text = "Active :";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchNo.Location = new System.Drawing.Point(169, 66);
            this.txtBatchNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBatchNo.MaxLength = 50;
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(356, 27);
            this.txtBatchNo.TabIndex = 1;
            this.txtBatchNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBatchNo_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 111;
            this.label2.Text = "Batch No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 109;
            this.label4.Text = "Item :";
            // 
            // pnlTabControlSearch
            // 
            this.pnlTabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabControlSearch.Controls.Add(this.txtSearchText);
            this.pnlTabControlSearch.Controls.Add(this.grdSearch);
            this.pnlTabControlSearch.Location = new System.Drawing.Point(1040, 239);
            this.pnlTabControlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTabControlSearch.Name = "pnlTabControlSearch";
            this.pnlTabControlSearch.Size = new System.Drawing.Size(362, 216);
            this.pnlTabControlSearch.TabIndex = 133;
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
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.RowTemplate.Height = 24;
            this.grdSearch.Size = new System.Drawing.Size(597, 323);
            this.grdSearch.TabIndex = 0;
            this.grdSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellDoubleClick);
            // 
            // txtHidCode
            // 
            this.txtHidCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHidCode.Location = new System.Drawing.Point(1040, 204);
            this.txtHidCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtHidCode.MaxLength = 20;
            this.txtHidCode.Name = "txtHidCode";
            this.txtHidCode.Size = new System.Drawing.Size(239, 27);
            this.txtHidCode.TabIndex = 132;
            this.txtHidCode.Visible = false;
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 755);
            this.Controls.Add(this.pnlTabControlSearch);
            this.Controls.Add(this.txtHidCode);
            this.Controls.Add(this.pnlTabControlAdd);
            this.Controls.Add(this.lblTag);
            this.Name = "frmBatch";
            this.Text = "Batch";
            this.Load += new System.EventHandler(this.frmBatch_Load);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtExpiry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlItem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Panel pnlTabControlSearch;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.TextBox txtHidCode;
    }
}