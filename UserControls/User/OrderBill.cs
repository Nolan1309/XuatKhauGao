using QL_XuatKhauGao.DTO;
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.Models;
using QL_XuatKhauGao.UserControls.FormThongTin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_XuatKhauGao.UserControls.Admin
{
    public partial class OrderBill : Form
    {

        khachhang user;
        List<SanPham> products;
        List<ChiTietHoaDon> order_detail = new List<ChiTietHoaDon>();
        Models.HoaDon order = new Models.HoaDon();
        string makh;
        string mahoadon;
        public OrderBill()
        {
            InitializeComponent();
        }
        public OrderBill(List<SanPham> totalList)
        {
            InitializeComponent();
            this.products = products;
        }
        public OrderBill(List<SanPham> products, List<SanPham> totalList)
        {
            InitializeComponent();
            products.AddRange(totalList);
            this.products = products;
        }
        //public OrderBill(khachhang user, List<SanPham> products)
        //{
        //    InitializeComponent();
        //    this.user = user;
        //    this.products = products;
        //}

        private void OrderBill_Load(object sender, EventArgs e)
        {

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

                    //ct.TongTien = (item.Gia * Convert.ToDouble(item.Soluong)) + (0.2 * (item.Gia * Convert.ToDouble(item.Soluong)));
                    ct.TongTien = ((item.Gia + item.Gia * 0.2) * Convert.ToDouble(item.Soluong));
                    total += Convert.ToDouble(ct.TongTien);
                    order_detail.Add(ct);
                    container_grid.Rows.Add(new object[] { image, item?.TenSanPham, item?.Gia.ToString(), item?.Soluong.ToString(), ct.TongTien });
                }
                lb_totalPrice.Text = "Tổng tiền hàng:      " + total.ToString();
                order.TongTien = total;
                order.NgayOrder = DateTime.Now;
                order.MaKhachHang = user.idkhachhang;
                makh = Convert.ToString(user.idkhachhang);
                order.Manhanvien = 1;
                order.IdHinhThucThanhToan = 1;
               
            }
          
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

                db.HoaDons.Add(order);
                db.SaveChanges();
                foreach (ChiTietHoaDon item in order_detail)
                {
                    item.MaHoaDon = order.MaHoaDon;
                    mahoadon = Convert.ToString(order.MaHoaDon);
                    db.ChiTietHoaDons.Add(item);
                }
                db.SaveChanges();

                UserControlProduct_u userControlProduct_U = new UserControlProduct_u();
                userControlProduct_U.ClearOrderList();


                MessageBox.Show("Đặt hàng thành công", "Thông báo", MessageBoxButtons.OK);
                ThongTinDatHang form = new ThongTinDatHang(mahoadon,makh);
                form.ShowDialog();



                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            ThongTinDatHang form = new ThongTinDatHang();
            form.ShowDialog();
        }
    }
}
