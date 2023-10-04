using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QL_XuatKhauGao.Models;

namespace QL_XuatKhauGao
{
    public partial class Form_Register : Form
    {
        //ADMIN | tk: admin, mk: admin
        //USER | tk: user1, mk: user1
        public Form_Register()
        {
            InitializeComponent();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            if (tb_pas.Text.Length == 0 || tb_email.Text.Length == 0 || tb_name.Text.Length == 0)
            {
                mes_error.Text = "Vui lòng điền đầy đủ thông tin";
            }
            else
            {
                try
                {
                    DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                    DangNhap user = db.DangNhaps.Where(item => tb_email.Text.Trim() == item.email).FirstOrDefault();
                    if (user == null)
                    {
                        DangNhap dn = new DangNhap();
                        dn.email = tb_email.Text.Trim();
                        dn.matkhau = tb_pas.Text.Trim();
                        dn.isAdmin = 2;
                        db.DangNhaps.Add(dn);

                        db.SaveChanges();

                        KhachHang kh = new KhachHang() { 
                            ten = tb_name.Text.Trim(),
                            login_id = dn.id
                        };

                        db.KhachHangs.Add(kh);

                        db.SaveChanges();

                        MessageBox.Show("Bạn đã đăng ký tài khoản thành công","Thông báo", MessageBoxButtons.OK);
                        Form_Login form = new Form_Login();
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        mes_error.Text = "Email đã tồn tại";
                        uiButton3.Focus();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Cảnh báo", MessageBoxButtons.OK);
                }

            }
        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
            mes_error.Text = "";
        }

        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            Form_Login form = new Form_Login();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
