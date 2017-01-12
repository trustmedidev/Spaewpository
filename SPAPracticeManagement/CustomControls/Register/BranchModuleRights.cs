using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.CustomControls.Register
{
    public partial class BranchModuleRights : UserControl
    {
        public BranchModuleRights()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                using (Brush br = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                  Color.LightYellow, Color.Moccasin, 45))
                {
                    e.Graphics.FillRectangle(br, this.ClientRectangle);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
