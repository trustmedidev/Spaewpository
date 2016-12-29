namespace SPAPracticeManagement
{
    partial class Home
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chartMonthlycollection = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNoclientMonthly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.appoint_panel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlycollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoclientMonthly)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.chartMonthlycollection);
            this.panel5.Controls.Add(this.chartNoclientMonthly);
            this.panel5.Controls.Add(this.appoint_panel);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(159, 138);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(918, 366);
            this.panel5.TabIndex = 6;
            // 
            // chartMonthlycollection
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMonthlycollection.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMonthlycollection.Legends.Add(legend1);
            this.chartMonthlycollection.Location = new System.Drawing.Point(602, 186);
            this.chartMonthlycollection.Name = "chartMonthlycollection";
            this.chartMonthlycollection.Size = new System.Drawing.Size(600, 350);
            this.chartMonthlycollection.TabIndex = 14;
            this.chartMonthlycollection.Text = "chart2";
            this.chartMonthlycollection.Click += new System.EventHandler(this.chartMonthlycollection_Click);
            // 
            // chartNoclientMonthly
            // 
            chartArea2.Name = "ChartArea1";
            this.chartNoclientMonthly.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartNoclientMonthly.Legends.Add(legend2);
            this.chartNoclientMonthly.Location = new System.Drawing.Point(12, 186);
            this.chartNoclientMonthly.Name = "chartNoclientMonthly";
            this.chartNoclientMonthly.Size = new System.Drawing.Size(600, 350);
            this.chartNoclientMonthly.TabIndex = 13;
            this.chartNoclientMonthly.Text = "chart1";
            // 
            // appoint_panel
            // 
            this.appoint_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appoint_panel.AutoScroll = true;
            this.appoint_panel.BackColor = System.Drawing.Color.Transparent;
            this.appoint_panel.Location = new System.Drawing.Point(0, 40);
            this.appoint_panel.Name = "appoint_panel";
            this.appoint_panel.Size = new System.Drawing.Size(800, 120);
            this.appoint_panel.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(20)))), ((int)(((byte)(58)))));
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(917, 34);
            this.panel6.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Today\'s Appointment";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 512);
            this.Controls.Add(this.panel5);
            this.Name = "Home";
            this.Text = "Home";
            this.Controls.SetChildIndex(this.panel5, 0);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlycollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoclientMonthly)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonthlycollection;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNoclientMonthly;
        private System.Windows.Forms.Panel appoint_panel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
    }
}