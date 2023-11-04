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
        string ten = null;
        Dangnhap user;
        khachhang kh;
      
        public UserControlLGInfo()
        {
            InitializeComponent();
            uiLabel6.Visible = true;
            tb_uAddress.Visible = true;
            tb_uEmail.Enabled = true;
        }

        public UserControlLGInfo(Dangnhap user)
        {
            InitializeComponent();
            this.ten = user.tendangnhap;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

                khachhang kh_new = db.khachhangs.Where(item => item.idkhachhang == kh.idkhachhang).FirstOrDefault();
                kh_new.tenkhachhang = tb_uName.Text.Trim();
                kh_new.sdtKH = tb_uPhone.Text.Trim();
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
          
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
            Dangnhap dn = db.Dangnhaps.FirstOrDefault(item => item.tendangnhap == ten);

            //tb_uAddress.Text = dn?.tendangnhap?.Trim() ?? "";
            tb_uPhone.Text = dn?.Idphanquyen?.ToString().Trim() ?? "";
            tb_uName.Text = dn?.tendangnhap?.Trim() ?? "";
            tb_uEmail.Text = dn?.matkhau?.ToString().Trim() ?? "";

            //kh = db.khachhangs.Where(item => item.idLogin == user.Idphanquyen).FirstOrDefault();
            //tb_uAddress.Text = kh?.diachi?.Trim() ?? "";        
            //tb_uPhone.Text = kh?.sdtKH?.ToString().Trim() ?? "";
            //tb_uName.Text = kh.tenkhachhang.Trim();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //tb_uAddress.Text = kh.diachi.Trim();
            //tb_uEmail.Text = kh.tenkhachhang.Trim();
            //tb_uPhone.Text = kh.sdtKH?.ToString().Trim();
            //tb_uName.Text = kh.tenkhachhang.Trim();
            //UserControlLGInfo hi = new UserControlLGInfo();
            //hi.Hide();

            this.Hide();

            // Mở UserController mới
            UserControlProduct_u newUserController = new UserControlProduct_u();
            newUserController.Show(); // Hoặc newUserController.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
