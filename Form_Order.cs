using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_XuatKhauGao.Models;
using QL_XuatKhauGao.Helpers;

namespace QL_XuatKhauGao
{
    public partial class Form_Order : Form
    {
        khachhang user;
        List<SanPham> products;
        List<ChiTietHoaDon> order_detail = new List<ChiTietHoaDon>();
        HoaDon order = new HoaDon();
        public Form_Order()
        {
            InitializeComponent();
        }

        public Form_Order(List<SanPham> products)
        {
            InitializeComponent();
            this.products = products;
        }
        public Form_Order(khachhang user, List<SanPham> products)
        {
            InitializeComponent();
            this.user = user;
            this.products = products;
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Order_Load(object sender, EventArgs e)
        {
            //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

            db.Configuration.LazyLoadingEnabled = false;
            Dangnhap auth = db.Dangnhaps.Where(item => item.tendangnhap == Properties.Settings.Default.username).FirstOrDefault();
            user = db.khachhangs.Where(item => item.idLogin == auth.Idphanquyen).FirstOrDefault();
            if (products != null)
            {
                double total = 0;
                Bitmap image = null;
                foreach (SanPham item in products)
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    image = ConvertStringToBitmap.convertToBitmap(item.hinhanh);
                    ct.MaSanPham = item.MaSanPham;
                    ct.DonGia = item.Gia;
                    ct.SoLuong = item.Soluong;
                    ct.TongTien = item.Gia * Convert.ToDouble(item.Soluong);
                    total += Convert.ToDouble(ct.TongTien);
                    order_detail.Add(ct);
                    container_grid.Rows.Add(new object[] { image, item?.TenSanPham, item?.Gia.ToString(), item?.Soluong.ToString(), ct.TongTien });
                }
                lb_totalPrice.Text = "Tổng tiền hàng:      " + total.ToString();
                order.TongTien = total;
                order.NgayOrder = DateTime.Now;
                order.MaKhachHang = user.idkhachhang;
                order.Manhanvien = 1;
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

                db.HoaDons.Add(order);
                db.SaveChanges();
                foreach(ChiTietHoaDon item in order_detail)
                {
                    item.MaHoaDon = order.MaHoaDon;
                    db.ChiTietHoaDons.Add(item);
                }
                db.SaveChanges();
                MessageBox.Show("Đặt hàng thành công", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
