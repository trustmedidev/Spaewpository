namespace SPAPracticeManagement.Reports
{
    partial class DailySalesReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dailySalesReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spamanagementDataSet1 = new SPAPracticeManagement.spamanagementDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dailySalesReportTableAdapter = new SPAPracticeManagement.spamanagementDataSet1TableAdapters.DailySalesReportTableAdapter();
            this.chk_allsel = new System.Windows.Forms.CheckBox();
            this.chk_seltype = new System.Windows.Forms.CheckedListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chk_alltherapist = new System.Windows.Forms.CheckBox();
            this.chk_therapist = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_alltax = new System.Windows.Forms.CheckBox();
            this.chk_taxtype = new System.Windows.Forms.CheckedListBox();
            this.chk_allpayment = new System.Windows.Forms.CheckBox();
            this.chk_paymentmode = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dailySalesReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spamanagementDataSet1)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dailySalesReportBindingSource
            // 
            this.dailySalesReportBindingSource.DataMember = "DailySalesReport";
            this.dailySalesReportBindingSource.DataSource = this.spamanagementDataSet1;
            // 
            // spamanagementDataSet1
            // 
            this.spamanagementDataSet1.DataSetName = "spamanagementDataSet1";
            this.spamanagementDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SalesRpt";
            reportDataSource1.Value = this.dailySalesReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SPAPracticeManagement.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(203, 377);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1100, 300);
            this.reportViewer1.TabIndex = 6;
            // 
            // dailySalesReportTableAdapter
            // 
            this.dailySalesReportTableAdapter.ClearBeforeFill = true;
            // 
            // chk_allsel
            // 
            this.chk_allsel.AutoSize = true;
            this.chk_allsel.Location = new System.Drawing.Point(268, 170);
            this.chk_allsel.Name = "chk_allsel";
            this.chk_allsel.Size = new System.Drawing.Size(52, 17);
            this.chk_allsel.TabIndex = 193;
            this.chk_allsel.Text = "By All";
            this.chk_allsel.UseVisualStyleBackColor = true;
            this.chk_allsel.CheckedChanged += new System.EventHandler(this.chk_allsel_CheckedChanged);
            // 
            // chk_seltype
            // 
            this.chk_seltype.CheckOnClick = true;
            this.chk_seltype.FormattingEnabled = true;
            this.chk_seltype.Items.AddRange(new object[] {
            "By Service",
            "By Package"});
            this.chk_seltype.Location = new System.Drawing.Point(265, 189);
            this.chk_seltype.Name = "chk_seltype";
            this.chk_seltype.Size = new System.Drawing.Size(146, 49);
            this.chk_seltype.TabIndex = 194;
            this.chk_seltype.SelectedIndexChanged += new System.EventHandler(this.chk_seltype_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(495, 244);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 16);
            this.label20.TabIndex = 210;
            this.label20.Text = "Therapist :";
            // 
            // chk_alltherapist
            // 
            this.chk_alltherapist.AutoSize = true;
            this.chk_alltherapist.Location = new System.Drawing.Point(577, 247);
            this.chk_alltherapist.Name = "chk_alltherapist";
            this.chk_alltherapist.Size = new System.Drawing.Size(52, 17);
            this.chk_alltherapist.TabIndex = 199;
            this.chk_alltherapist.Text = "By All";
            this.chk_alltherapist.UseVisualStyleBackColor = true;
            this.chk_alltherapist.CheckedChanged += new System.EventHandler(this.chk_alltherapist_CheckedChanged);
            // 
            // chk_therapist
            // 
            this.chk_therapist.CheckOnClick = true;
            this.chk_therapist.FormattingEnabled = true;
            this.chk_therapist.Location = new System.Drawing.Point(575, 265);
            this.chk_therapist.Name = "chk_therapist";
            this.chk_therapist.Size = new System.Drawing.Size(146, 49);
            this.chk_therapist.TabIndex = 200;
            this.chk_therapist.SelectedIndexChanged += new System.EventHandler(this.chk_therapist_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 209;
            this.label4.Text = "Tax Type :";
            // 
            // chk_alltax
            // 
            this.chk_alltax.AutoSize = true;
            this.chk_alltax.Location = new System.Drawing.Point(272, 249);
            this.chk_alltax.Name = "chk_alltax";
            this.chk_alltax.Size = new System.Drawing.Size(52, 17);
            this.chk_alltax.TabIndex = 195;
            this.chk_alltax.Text = "By All";
            this.chk_alltax.UseVisualStyleBackColor = true;
            this.chk_alltax.CheckedChanged += new System.EventHandler(this.chk_alltax_CheckedChanged);
            // 
            // chk_taxtype
            // 
            this.chk_taxtype.CheckOnClick = true;
            this.chk_taxtype.FormattingEnabled = true;
            this.chk_taxtype.Items.AddRange(new object[] {
            "By Taxable",
            "By Non Taxable"});
            this.chk_taxtype.Location = new System.Drawing.Point(269, 267);
            this.chk_taxtype.Name = "chk_taxtype";
            this.chk_taxtype.Size = new System.Drawing.Size(146, 49);
            this.chk_taxtype.TabIndex = 196;
            this.chk_taxtype.SelectedIndexChanged += new System.EventHandler(this.chk_taxtype_SelectedIndexChanged);
            // 
            // chk_allpayment
            // 
            this.chk_allpayment.AutoSize = true;
            this.chk_allpayment.Location = new System.Drawing.Point(575, 171);
            this.chk_allpayment.Name = "chk_allpayment";
            this.chk_allpayment.Size = new System.Drawing.Size(52, 17);
            this.chk_allpayment.TabIndex = 197;
            this.chk_allpayment.Text = "By All";
            this.chk_allpayment.UseVisualStyleBackColor = true;
            this.chk_allpayment.CheckedChanged += new System.EventHandler(this.chk_allpayment_CheckedChanged);
            // 
            // chk_paymentmode
            // 
            this.chk_paymentmode.CheckOnClick = true;
            this.chk_paymentmode.FormattingEnabled = true;
            this.chk_paymentmode.Items.AddRange(new object[] {
            "By Cash",
            "By Card",
            "By Credit"});
            this.chk_paymentmode.Location = new System.Drawing.Point(573, 190);
            this.chk_paymentmode.Name = "chk_paymentmode";
            this.chk_paymentmode.Size = new System.Drawing.Size(150, 49);
            this.chk_paymentmode.TabIndex = 198;
            this.chk_paymentmode.SelectedIndexChanged += new System.EventHandler(this.chk_paymentmode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(466, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 16);
            this.label8.TabIndex = 208;
            this.label8.Text = "Payment Mode :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.Location = new System.Drawing.Point(165, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 207;
            this.label3.Text = "Selection Type :";
            // 
            // txtToDate
            // 
            this.txtToDate.Checked = false;
            this.txtToDate.CustomFormat = "dd/MMM/yyyy";
            this.txtToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtToDate.Location = new System.Drawing.Point(861, 197);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ShowCheckBox = true;
            this.txtToDate.Size = new System.Drawing.Size(117, 23);
            this.txtToDate.TabIndex = 202;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Checked = false;
            this.txtFromDate.CustomFormat = "dd/MMM/yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFromDate.Location = new System.Drawing.Point(861, 168);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ShowCheckBox = true;
            this.txtFromDate.Size = new System.Drawing.Size(117, 23);
            this.txtFromDate.TabIndex = 201;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(349, 333);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 26);
            this.btnClear.TabIndex = 204;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(34)))), ((int)(((byte)(94)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(268, 333);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 203;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(781, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 206;
            this.label5.Text = "To Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(766, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 205;
            this.label6.Text = "From Date :";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(155, 133);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1200, 24);
            this.panel7.TabIndex = 211;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "Daily Sales Report";
            // 
            // DailySalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1350, 690);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.chk_allsel);
            this.Controls.Add(this.chk_seltype);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chk_alltherapist);
            this.Controls.Add(this.chk_therapist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chk_alltax);
            this.Controls.Add(this.chk_taxtype);
            this.Controls.Add(this.chk_allpayment);
            this.Controls.Add(this.chk_paymentmode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.reportViewer1);
            this.Name = "DailySalesReport";
            this.Load += new System.EventHandler(this.DailySalesReport_Load_2);
            this.Controls.SetChildIndex(this.reportViewer1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.txtFromDate, 0);
            this.Controls.SetChildIndex(this.txtToDate, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.chk_paymentmode, 0);
            this.Controls.SetChildIndex(this.chk_allpayment, 0);
            this.Controls.SetChildIndex(this.chk_taxtype, 0);
            this.Controls.SetChildIndex(this.chk_alltax, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.chk_therapist, 0);
            this.Controls.SetChildIndex(this.chk_alltherapist, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.chk_seltype, 0);
            this.Controls.SetChildIndex(this.chk_allsel, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dailySalesReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spamanagementDataSet1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private spamanagementDataSet1 spamanagementDataSet1;
        private System.Windows.Forms.BindingSource dailySalesReportBindingSource;
        private spamanagementDataSet1TableAdapters.DailySalesReportTableAdapter dailySalesReportTableAdapter;
        private System.Windows.Forms.CheckBox chk_allsel;
        private System.Windows.Forms.CheckedListBox chk_seltype;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chk_alltherapist;
        private System.Windows.Forms.CheckedListBox chk_therapist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_alltax;
        private System.Windows.Forms.CheckedListBox chk_taxtype;
        private System.Windows.Forms.CheckBox chk_allpayment;
        private System.Windows.Forms.CheckedListBox chk_paymentmode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtToDate;
        private System.Windows.Forms.DateTimePicker txtFromDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;



    }
}