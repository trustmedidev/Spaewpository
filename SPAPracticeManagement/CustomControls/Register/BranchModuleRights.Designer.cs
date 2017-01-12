namespace SPAPracticeManagement.CustomControls.Register
{
    partial class BranchModuleRights
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TbCtrlBranchModuleRight = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdBranch = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdModule = new System.Windows.Forms.DataGridView();
            this.ModuleNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowModule = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BranchNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Allow = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.TbCtrlBranchModuleRight.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranch)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TbCtrlBranchModuleRight);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 784);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TbCtrlBranchModuleRight
            // 
            this.TbCtrlBranchModuleRight.Controls.Add(this.tabPage1);
            this.TbCtrlBranchModuleRight.Controls.Add(this.tabPage2);
            this.TbCtrlBranchModuleRight.Location = new System.Drawing.Point(18, 56);
            this.TbCtrlBranchModuleRight.Name = "TbCtrlBranchModuleRight";
            this.TbCtrlBranchModuleRight.SelectedIndex = 0;
            this.TbCtrlBranchModuleRight.Size = new System.Drawing.Size(1078, 653);
            this.TbCtrlBranchModuleRight.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1070, 624);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Branch Rights";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1070, 624);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Module Rights";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.grdBranch);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1061, 612);
            this.panel2.TabIndex = 0;
            // 
            // grdBranch
            // 
            this.grdBranch.AllowUserToAddRows = false;
            this.grdBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BranchNm,
            this.Allow});
            this.grdBranch.Location = new System.Drawing.Point(346, 2);
            this.grdBranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdBranch.Name = "grdBranch";
            this.grdBranch.RowHeadersVisible = false;
            this.grdBranch.RowTemplate.Height = 24;
            this.grdBranch.Size = new System.Drawing.Size(603, 520);
            this.grdBranch.TabIndex = 137;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdModule);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1058, 609);
            this.panel3.TabIndex = 0;
            // 
            // grdModule
            // 
            this.grdModule.AllowUserToAddRows = false;
            this.grdModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModuleNm,
            this.AllowModule});
            this.grdModule.Location = new System.Drawing.Point(8, 7);
            this.grdModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdModule.Name = "grdModule";
            this.grdModule.RowHeadersVisible = false;
            this.grdModule.RowTemplate.Height = 24;
            this.grdModule.Size = new System.Drawing.Size(1042, 520);
            this.grdModule.TabIndex = 138;
            // 
            // ModuleNm
            // 
            this.ModuleNm.HeaderText = "Module Name";
            this.ModuleNm.Name = "ModuleNm";
            this.ModuleNm.ReadOnly = true;
            this.ModuleNm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModuleNm.Width = 800;
            // 
            // AllowModule
            // 
            this.AllowModule.HeaderText = "Allow";
            this.AllowModule.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.AllowModule.Name = "AllowModule";
            this.AllowModule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowModule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BranchNm
            // 
            this.BranchNm.HeaderText = "Branch Name";
            this.BranchNm.Name = "BranchNm";
            this.BranchNm.ReadOnly = true;
            this.BranchNm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BranchNm.Width = 500;
            // 
            // Allow
            // 
            this.Allow.HeaderText = "Allow";
            this.Allow.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.Allow.Name = "Allow";
            this.Allow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Allow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User});
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(304, 520);
            this.dataGridView1.TabIndex = 138;
            // 
            // User
            // 
            this.User.HeaderText = "User Name";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User.Width = 300;
            // 
            // BranchModuleRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "BranchModuleRights";
            this.Size = new System.Drawing.Size(1198, 787);
            this.panel1.ResumeLayout(false);
            this.TbCtrlBranchModuleRight.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBranch)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl TbCtrlBranchModuleRight;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grdBranch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView grdModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleNm;
        private System.Windows.Forms.DataGridViewComboBoxColumn AllowModule;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchNm;
        private System.Windows.Forms.DataGridViewComboBoxColumn Allow;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
    }
}
