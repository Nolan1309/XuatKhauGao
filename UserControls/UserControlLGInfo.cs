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

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlLGInfo : UserControl
    {
        DangNhap user;
        KhachHang kh;
        public UserControlLGInfo()
        {
            InitializeComponent();
        }

        public UserControlLGInfo(DangNhap user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                KhachHang kh_new = db.KhachHangs.Where(item => item.id == kh.id).FirstOrDefault();
                kh_new.ten = tb_uName.Text.Trim();
                kh_new.sdt = tb_uPhone.Text.Trim();
                kh_new.diachi = tb_uAddress.Text.Trim();
                db.SaveChanges();
                MessageBox.Show("Thông tin đã được lưu", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControlLGInfo_Load(object sender, EventArgs e)
        {
            DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();

            kh = db.KhachHangs.Where(item => item.login_id == user.id).FirstOrDefault();

            tb_uAddress.Text = kh?.diachi?.Trim() ?? "";
            tb_uEmail.Text = user.email.Trim();
            tb_uPhone.Text = kh?.sdt?.ToString().Trim() ?? "";
            tb_uName.Text = kh.ten.Trim();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_uAddress.Text = kh.diachi.Trim();
            tb_uEmail.Text = user.email.Trim();
            tb_uPhone.Text = kh.sdt.ToString().Trim();
            tb_uName.Text = kh.ten.Trim();
            
        }
    }
}
