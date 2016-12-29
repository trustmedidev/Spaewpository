using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace SPAPracticeManagement
{
    public class CommonCL
    {
        
        #region GotFocus

        public static void ComboBoxGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as ComboBox).Focus();

            }
        }
        public static void TextBoxGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as TextBox).Focus();

            }
        }
        public static void DataGridGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as DataGrid).Focus();

            }
        }
        public static void DataGridViewGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as DataGridView).Focus();

            }
        }
        public static void DTPickerGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as DateTimePicker).Focus();

            }
        }
        public static void RichTextBoxGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as RichTextBox).Focus();

            }
        }
        public static void ButtonGotFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as Button).Focus();

            }
        }

        public static void ListViewFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (sender as ListView).Focus();

            }
        }
        #endregion


        public static void PanelControlGotFocus(object sender, Panel FalsePanel1)
        {
           
                //(sender as Panel).Focus();

                (sender as Panel).Width = 1753;
                (sender as Panel).Height = 656;

                (sender as Panel).Top = 155;
                (sender as Panel).Left = 160;

                (sender as Panel).Visible = true;
                (sender as Panel).BringToFront();
                (sender as Panel).Enabled = true;

                FalsePanel1.Visible = false;
               

            
        }

        public static void OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            string senderText = (sender as TextBox).Text;
            string senderName = (sender as TextBox).Name;
            string[] splitByDecimal = senderText.Split('.');
            int cursorPosition = (sender as TextBox).SelectionStart;

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if (e.KeyChar == '.'
                && senderText.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar)
                && senderText.IndexOf('.') < cursorPosition
                && splitByDecimal.Length > 1
                && splitByDecimal[1].Length == 2)
            {
                e.Handled = true;
            }
        }
        public static void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            string senderText = (sender as TextBox).Text;
            string senderName = (sender as TextBox).Name;

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                )
            {
                e.Handled = true;
            }

        }

        public static void textBoxYNValidation(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'y' || e.KeyChar == 'Y' || e.KeyChar == 'n' || e.KeyChar == 'N' || (e.KeyChar == (char)Keys.Back))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        public static void textBoxSearchValidation(object sender, DataView dv)
        {
            if ((sender as TextBox).Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = "ALLFIELD like '%" + (sender as TextBox).Text.Replace("'", "`").ToString() + "%'";
            }
        }

        public static void cmbValidated(ComboBox ComboBox, Boolean falag)
        {

            if (ComboBox.SelectedValue == null || ComboBox.Text == "")
            {
                if (falag == true)
                {
                    ComboBox.Focus();
                    ComboBox.DroppedDown = true;
                    return;
                }
            }
            else
            {
                ComboBox.DroppedDown = false;
                falag = true;
            }
        }
    }
}
