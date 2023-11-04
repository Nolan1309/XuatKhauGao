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
                    //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                    Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

                    Dangnhap user = db.Dangnhaps.Where(item => tb_email.Text.Trim() == item.tendangnhap).FirstOrDefault();
                    if (user == null)
                    {
                        Dangnhap dn = new Dangnhap();
                        dn.tendangnhap = tb_email.Text.Trim();
                        dn.matkhau = tb_pas.Text.Trim();
                        dn.Idphanquyen = 2;
                        db.Dangnhaps.Add(dn);

                        db.SaveChanges();

                        khachhang kh = new khachhang() { 
                            tenkhachhang = tb_name.Text.Trim(),
                            idLogin = dn.Idphanquyen
                        };

                        db.khachhangs.Add(kh);

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
