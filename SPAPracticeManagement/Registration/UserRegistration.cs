using SPAPracticeManagement.Custom_Controls.Register;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPAPracticeManagement.Registration
{
    public partial class UserRegistration : Dashboard
    {
        public UserRegistration()
        {
            AddUser ucBookAppointmenttab = new AddUser();

            ucBookAppointmenttab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                   | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));
            InitializeComponent();
            pnlTab.Controls.Add(ucBookAppointmenttab);

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
    }
}
