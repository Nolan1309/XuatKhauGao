using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_XuatKhauGao.Models;
using System.Data.SqlClient;

namespace QL_XuatKhauGao.UserControls.User
{
    public partial class LoadAccountINFO : UserControl
    {
        Dangnhap user;
        DataProvider db = new DataProvider();
        public LoadAccountINFO()
        {
            InitializeComponent();
        }
        public LoadAccountINFO(Dangnhap user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void LoadAccountINFO_Load(object sender, EventArgs e)
        {
            uiTextBox1.Enabled = false;
            uiTextBox2.Enabled = false;
            uiTextBox3.Enabled = false;
            LoadAccount();
        }
        void LoadAccount()
        {
            using (SqlConnection connection = db.sqlConnection())
            {
                connection.Open();
                string sql = "select tendangnhap,matkhau,tenQuyen from Dangnhap inner join PhanQuyen on Dangnhap.Idphanquyen= PhanQuyen.id and tendangnhap= '"+user.tendangnhap+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();
                if (dt.Rows.Count > 0)
                {
                    uiTextBox1.Text = dt.Rows[0]["tendangnhap"].ToString();
                    uiTextBox2.Text = dt.Rows[0]["matkhau"].ToString();
                    uiTextBox3.Text = dt.Rows[0]["tenQuyen"].ToString();
                }
                else
                {

                }
            }
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            if (txt_pass_old.Text =="" || string.IsNullOrWhiteSpace(txt_pass_new.Text)|| string.IsNullOrWhiteSpace(txt_passs_confirm.Text))
            {

                MessageBox.Show("Dữ liệu không được để trống !", "Thông báo");

            }
            else
            {
                if (txt_pass_new.Text == txt_passs_confirm.Text)
                {
                    using (SqlConnection connection = db.sqlConnection())
                    {
                        string sql = "update Dangnhap set matkhau = @matkhau where tendangnhap = @tendangnhap";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.AddWithValue("@matkhau", txt_pass_new.Text);
                        cmd.Parameters.AddWithValue("@tendangnhap", user.tendangnhap);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã đổi thành công!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Không có dòng nào bị ảnh hưởng. Có thể truy vấn không chạy thành công.", "Lỗi");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp !", "Thông báo");

                }


            }
            txt_pass_old.ResetText();
            txt_pass_new.ResetText();
            txt_passs_confirm.ResetText();

            LoadAccount();
         
        }
    }
}
