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
    public partial class Form_Login : Form
    {
        //ADMIN | tk: admin, mk: admin
        //USER | tk: user1, mk: user1
        public Form_Login()
        {
            InitializeComponent();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            if(uiTextBox1.Text.Length == 0 || uiTextBox3.Text.Length == 0)
            {
                mes_error.Text = "Vui lòng kiểm tra lại tên đăng nhập và mật khẩu";
            }
            else
            {
                try
                {
                    //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                    Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
                    Dangnhap user = db.Dangnhaps.Where(item => uiTextBox3.Text == item.tendangnhap && uiTextBox1.Text == item.matkhau).FirstOrDefault();
                    if (user != null)
                    {
                        Properties.Settings.Default.username = user.tendangnhap;
                        Properties.Settings.Default.password = user.matkhau;
                        Properties.Settings.Default.Save();

                        if (user.PhanQuyen.tenQuyen == "Admin")
                        {
                            Form_Dashboard form_admin = new Form_Dashboard(user);
                            this.Hide();
                            form_admin.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            Form_User form_user = new Form_User(user);
                            this.Hide();
                            form_user.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        mes_error.Text = "Vui lòng kiểm tra lại tên đăng nhập và mật khẩu";
                        uiButton3.Focus();
                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Cảnh báo", MessageBoxButtons.OK);
                }

            }
        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
            mes_error.Text = "";
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            string email = Properties.Settings.Default.username;
            string matkhau = Properties.Settings.Default.password;
            if(email != null && matkhau != null)
            {
                Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
                Dangnhap user = db.Dangnhaps.Where(item => email == item.tendangnhap && matkhau == item.matkhau).FirstOrDefault();
                if (user != null)
                {
                    if (user.PhanQuyen.tenQuyen == "Admin")
                    {
                        Form_Dashboard form_admin = new Form_Dashboard(user);
                        this.Hide();
                        form_admin.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        Form_User form_user = new Form_User(user);
                        this.Hide();
                        form_user.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

       

        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            Form_Register form = new Form_Register();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void uiLinkLabel2_Click(object sender, EventArgs e)
        {
            SeachHDS formseach = new SeachHDS();
            this.Hide();
            formseach.ShowDialog();
            this.Close();
        }

        private void mes_error_Click(object sender, EventArgs e)
        {

        }
    }
}
