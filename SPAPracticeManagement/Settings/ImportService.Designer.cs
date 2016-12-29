namespace SPAPracticeManagement.Settings
{
    partial class ImportService
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel_Demoformat = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_ImportData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.btn_dialog = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel_Demoformat);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button_ImportData);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_filename);
            this.panel1.Controls.Add(this.btn_dialog);
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 202);
            this.panel1.TabIndex = 4;
            // 
            // linkLabel_Demoformat
            // 
            this.linkLabel_Demoformat.AutoSize = true;
            this.linkLabel_Demoformat.Location = new System.Drawing.Point(120, 95);
            this.linkLabel_Demoformat.Name = "linkLabel_Demoformat";
            this.linkLabel_Demoformat.Size = new System.Drawing.Size(246, 13);
            this.linkLabel_Demoformat.TabIndex = 105;
            this.linkLabel_Demoformat.TabStop = true;
            this.linkLabel_Demoformat.Text = "Demo Excel Format For Service Import(.xls Or .xlsx)";
            this.linkLabel_Demoformat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Demoformat_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(477, 22);
            this.panel3.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Import Service ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(19, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 4;
            // 
            // button_ImportData
            // 
            this.button_ImportData.BackColor = System.Drawing.Color.SteelBlue;
            this.button_ImportData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImportData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ImportData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_ImportData.Location = new System.Drawing.Point(185, 120);
            this.button_ImportData.Name = "button_ImportData";
            this.button_ImportData.Size = new System.Drawing.Size(75, 26);
            this.button_ImportData.TabIndex = 7;
            this.button_ImportData.Text = "Import Data";
            this.button_ImportData.UseVisualStyleBackColor = false;
            this.button_ImportData.Click += new System.EventHandler(this.button_ImportData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Excel File :";
            // 
            // txt_filename
            // 
            this.txt_filename.Location = new System.Drawing.Point(121, 66);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.ReadOnly = true;
            this.txt_filename.Size = new System.Drawing.Size(238, 20);
            this.txt_filename.TabIndex = 5;
            // 
            // btn_dialog
            // 
            this.btn_dialog.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_dialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dialog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_dialog.Location = new System.Drawing.Point(359, 64);
            this.btn_dialog.Name = "btn_dialog";
            this.btn_dialog.Size = new System.Drawing.Size(75, 23);
            this.btn_dialog.TabIndex = 4;
            this.btn_dialog.Text = "Upload";
            this.btn_dialog.UseVisualStyleBackColor = false;
            this.btn_dialog.Click += new System.EventHandler(this.btn_dialog_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(411, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 26);
            this.btnClose.TabIndex = 114;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ImportService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 238);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "ImportService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Rate Service Data From Excel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ImportData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.Button btn_dialog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linkLabel_Demoformat;
    }
}