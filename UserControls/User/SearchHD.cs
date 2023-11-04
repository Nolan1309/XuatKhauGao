using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.FormSearch;
using System.Data.SqlClient;
using QL_XuatKhauGao.Models;

namespace QL_XuatKhauGao.UserControls.User.Form
{
    public partial class SearchHD : UserControl
    {
        Control Content;
        DataProvider db = new DataProvider();
        public SearchHD()
        {
            InitializeComponent();
        }
        public SearchHD(Control control)
        {
            InitializeComponent();
            this.Content = control;
        }

        private void uiPanel6_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel5_Click(object sender, EventArgs e)
        {

        }
        bool SearchSP(int idhoadon, int idkhachhang)
        {
            int rowCount = 0;
            using (SqlConnection connection = db.sqlConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("USP_SearchBill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idhoadon", idhoadon));
                    cmd.Parameters.Add(new SqlParameter("@idkhachhang", idkhachhang));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rowCount++;
                        }
                    }
                }
            }
            if (rowCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBox1.Text.Trim()))
            {
                errorProvider1.SetError(uiTextBox1, "No null !");
                return;
            }
            else
            {
                errorProvider1.SetError(uiTextBox1, string.Empty);
            }
            if (string.IsNullOrEmpty(uiTextBox2.Text.Trim()))
            {
                errorProvider2.SetError(uiTextBox2, "No null !");
                return;
            }
            else
            {
                errorProvider2.SetError(uiTextBox2, string.Empty);
            }
            if (SearchSP(Convert.ToInt32(uiTextBox1.Text), Convert.ToInt32(uiTextBox2.Text)))
            {

                ShowSearchHDK searchHDK = new ShowSearchHDK(uiTextBox1.Text, uiTextBox2.Text);

                searchHDK.ShowDialog();
                Clear();
            }
            else
            {
                MessageBox.Show("Sai mã số phiếu hoặc mã khách hàng");
            }




        }
        public void Clear()
        {
            uiTextBox1.ResetText();
            uiTextBox2.ResetText();

        }
        //// Trong UserControl
        //private Panel GetPanelsFromParentForm(string panelName)
        //{
        //    //List<Panel> foundPanels = new List<Panel>();
        //    Panel foundPanels = new Panel();
        //    // Lấy đối tượng Form chứa UserControl
        //    SeachHDS parentForm = this.ParentForm as SeachHDS;

        //    if (parentForm != null)
        //    {
        //        // Lặp qua tất cả các Controls của Form
        //        foreach (Control control in parentForm.Controls)
        //        {
        //            // Kiểm tra xem Control có phải là Panel và có tên phù hợp
        //            if (control is Panel && control.Name == panelName)
        //            {
        //                foundPanels = (Panel)control;
        //                return foundPanels;
        //                //foundPanels.Add((Panel)control);
        //            }
        //        }
        //    }

        //    return foundPanels;
        //}


        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel3_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel2_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel3_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel4_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
