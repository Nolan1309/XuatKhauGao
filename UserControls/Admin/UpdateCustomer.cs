using QL_XuatKhauGao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_XuatKhauGao.UserControls.Admin
{
    public partial class UpdateCustomer : Form
    {

        DataProvider db = new DataProvider();

        public string makhachhang { get; set; }
        public UpdateCustomer(string makhach)
        {
            InitializeComponent();
            this.makhachhang = makhach;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = db.sqlConnection())
            {
                connection.Open();

                string sql = "UPDATE khachhang " +
                             "SET tenkhachhang = @NewTenKhachHang, sdtKH = @NewSdtKH, diachi = @NewDiachi, email = @NewEmail " +
                             "WHERE idkhachhang = @IDKhachHang";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NewTenKhachHang", uiTextBox1.Text);
                    command.Parameters.AddWithValue("@NewSdtKH", uiTextBox2.Text);
                    command.Parameters.AddWithValue("@NewDiachi", uiTextBox3.Text);
                    command.Parameters.AddWithValue("@NewEmail", uiTextBox4.Text);
                    command.Parameters.AddWithValue("@IDKhachHang", makhachhang);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thông tin đã được cập nhật thành công!", "Thông báo");
                        this.Close();
                    }
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
