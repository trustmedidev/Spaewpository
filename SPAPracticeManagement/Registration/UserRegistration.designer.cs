﻿namespace SPAPracticeManagement.Registration
{
    partial class UserRegistration
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
            this.pnlTab = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlTab
            // 
            this.pnlTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTab.Location = new System.Drawing.Point(207, 166);
            this.pnlTab.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(1296, 742);
            this.pnlTab.TabIndex = 24;
            // 
            // UserRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 668);
            this.Controls.Add(this.pnlTab);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserRegistration";
            this.Text = "UserRegistration";
            this.Load += new System.EventHandler(this.UserRegistration_Load);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTab;
    }
}