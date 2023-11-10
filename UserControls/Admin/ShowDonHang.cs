
using QL_XuatKhauGao.DTO;
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
using ZXing;
using OfficeOpenXml;
using System.IO;
using System.Drawing.Printing;

namespace QL_XuatKhauGao.UserControls.Admin
{
    public partial class ShowDonHang : UserControl
    {
        DataProvider sql = new DataProvider();
        DataGridView dataGridView = new DataGridView();
        List<Product_Print> list = new List<Product_Print>();
        public ShowDonHang()
        {
            InitializeComponent();
            uiDataGridView1.RowTemplate.Height = 40;
            uiDataGridView1.AllowUserToAddRows = false;

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControlOrder_Load(object sender, EventArgs e)
        {


            using (SqlConnection connect = sql.sqlConnection())
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("ShowAllHoaDon", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow item in dataTable.Rows)
                    {

                        string ngayOrder = ((DateTime)item["NgayOrder"]).ToString("dd/MM/yyyy");
                        string ngayNhanHang = ((DateTime)item["NgayNhanHangdukien"]).ToString("dd/MM/yyyy");

                        uiDataGridView1.Rows.Add(
                            item["MaHoaDon"],
                            ngayOrder,
                            ngayNhanHang,
                            item["TenNguoiNhan"],
                            item["DiaChiDen"],
                            string.Format("{0:#,##0}", item["GiaTriHangHoa"]),

                            string.Format("{0:#,##0}", item["TongTienHoaDon"]));

                    }
                    double totalHoaDon = 0;
                    double totalGiaTri = 0;
                    double totalThue = 0;


                    foreach (DataRow row in dataTable.Rows)
                    {
                        totalHoaDon += Convert.ToDouble(row["TongTienHoaDon"]);
                        totalGiaTri += Convert.ToDouble(row["GiaTriHangHoa"]);

                    }
                    totalThue = totalHoaDon - totalGiaTri;
                    uiTextBox1.Text = string.Format("{0:#,##0}", totalGiaTri);
                    uiTextBox2.Text = string.Format("{0:#,##0}", totalThue);
                    uiTextBox3.Text = string.Format("{0:#,##0}", totalHoaDon);

                }
            }

        }
        private string GetTenHinhThucThanhToanById(int idHinhThucThanhToan)
        {
            // Thực hiện một truy vấn SQL khác để lấy tên hình thức thanh toán dựa trên idHinhThucThanhToan
            // Chú ý: Đây là một ví dụ, bạn cần thay đổi truy vấn để phù hợp với cơ sở dữ liệu của bạn.
            using (SqlConnection connection = sql.sqlConnection())
            {
                connection.Open();
                string query = "SELECT TenHinhThuc FROM HinhThucThanhToan WHERE IdHinhThuc = @IdHinhThuc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdHinhThuc", idHinhThucThanhToan);
                    return command.ExecuteScalar()?.ToString();
                }
            }
        }
        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = uiDataGridView1.Rows[e.RowIndex];

            string maHoaDon = row.Cells[0].Value.ToString();

            using (SqlConnection connection = sql.sqlConnection())
            {
                connection.Open();
                string query = "SELECT KH.idkhachhang, KH.diachi, KH.tenkhachhang, KH.sdtKH, " +
               "HD.MaHoaDon, HD.NgayNhanHangdukien, HD.IdHinhThucThanhToan, " +
               "LC.SoLC, LC.ngayMo_LC, LC.ngayDong_LC AS NgayDongLC, " +
               "VC.diaDiemXuatPhat, VC.diaDiemDen AS NoiVanChuyen " +
               "FROM HoaDon AS HD " +
               "INNER JOIN khachhang AS KH ON HD.MaKhachHang = KH.idkhachhang " +
               "LEFT JOIN ChiTietLC AS LC ON HD.MaHoaDon = LC.idHoaDon " +
               "LEFT JOIN VanChuyen AS VC ON HD.MaHoaDon = VC.idHoaDon " +
               "WHERE HD.MaHoaDon = @MaHoaDon";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            uiTextBox4.Text = reader["idkhachhang"].ToString();
                            uiTextBox5.Text = reader["diachi"].ToString();
                            uiTextBox6.Text = reader["tenkhachhang"].ToString();
                            uiTextBox7.Text = reader["sdtKH"].ToString();

                            int idHinhThucThanhToan = (int)reader["IdHinhThucThanhToan"];
                            string tenHinhThucThanhToan = GetTenHinhThucThanhToanById(idHinhThucThanhToan);
                            //uiComboBox1.Items.Add(tenHinhThucThanhToan);
                            uiTextBox8.Text = tenHinhThucThanhToan;

                            uiTextBox11.Text = reader["MaHoaDon"].ToString();
                            uiTextBox12.Text = reader["NgayNhanHangdukien"].ToString();

                            uiTextBox13.Text = reader["SoLC"].ToString();
                            uiTextBox14.Text = reader["ngayMo_LC"].ToString();
                            uiTextBox15.Text = reader["NgayDongLC"].ToString();
                            uiTextBox9.Text = reader["NoiVanChuyen"].ToString();
                        }
                    }
                }
            }

        }
        public void GenerateQRCode(string sdtKhachHang, string tenKhachHang, string noiVanChuyen, double tongTienVAT)
        {
            // Tạo một chuỗi chứa thông tin từ hóa đơn
            string hoadonInfo = $"Phone : {sdtKhachHang},Customer : {tenKhachHang},Address : {noiVanChuyen},Total VAT : {tongTienVAT}";

            // Mã hóa chuỗi UTF-8
            byte[] hoadonBytes = Encoding.UTF8.GetBytes(hoadonInfo);


            // Tạo một đối tượng BarcodeWriter để tạo mã QR
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            // Tạo mã QR từ chuỗi thông tin
            Bitmap qrCodeBitmap = barcodeWriter.Write(hoadonInfo);

            // Thiết lập kích thước mới cho pictureBox1
            pictureBox1.Width = 300;  // Thay 'newWidth' bằng giá trị chiều rộng mới
            pictureBox1.Height = 230;  // Thay 'newHeight' bằng giá trị chiều cao mới

            // Hiển thị ảnh mã QR với kích thước mới trong pictureBox1
            pictureBox1.Image = new Bitmap(qrCodeBitmap, 300, 230);
        }

        private void uiDataGridView1_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void uiLabel9_Click(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            //list.Clear();
            //using (SqlConnection connection = sql.sqlConnection())
            //{
            //    connection.Open();

            //    string query = "SELECT SP.TenSanPham, CHD.SoLuong, CHD.DonGia, CHD.TongTien " +
            //                   "FROM ChiTietHoaDon AS CHD " +
            //                   "INNER JOIN SanPham AS SP ON CHD.MaSanPham = SP.MaSanPham " +
            //                   "WHERE CHD.MaHoaDon = @MaHoaDon";

            //    using (SqlCommand cmd = new SqlCommand(query, connection))
            //    {
            //        string check = uiTextBox11.Text;
            //        cmd.Parameters.AddWithValue("@MaHoaDon", check);
            //        Product_Print sp;
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                sp = new Product_Print();

            //                sp.tenSanpham = reader["TenSanPham"].ToString();
            //                sp.soluong = Convert.ToInt32(reader["SoLuong"].ToString());
            //                sp.dongia = Convert.ToDouble(reader["DonGia"].ToString());
            //                sp.tongtien = Convert.ToDouble(reader["TongTien"].ToString());
            //                list.Add(sp);

            //            }
            //        }
            //    }
            //    connection.Close();
            //}
            //PrintDocument printDocument = new PrintDocument();
            //printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

            //PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = printDocument;


            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {


            Graphics g = e.Graphics;

            // Khởi tạo các font và bút vẽ
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            // Vẽ tiêu đề hóa đơn
            string title = "HÓA ĐƠN";
            g.DrawString(title, titleFont, brush, 100, 100);

            // Vẽ thông tin hóa đơn
            string maHoaDon = "Mã hóa đơn: " + uiTextBox11.Text;
            g.DrawString(maHoaDon, regularFont, brush, 100, 150);

            string tenKhachHang = "Tên khách hàng: " + uiTextBox6.Text;
            g.DrawString(tenKhachHang, regularFont, brush, 100, 170);

            string sdtKhachHang = "SĐT khách hàng: " + uiTextBox7.Text;
            g.DrawString(sdtKhachHang, regularFont, brush, 100, 190);

            string noiVanChuyen = "Nơi vận chuyển: " + uiTextBox9.Text;
            g.DrawString(noiVanChuyen, regularFont, brush, 100, 210);

            //string ngayDat = "Ngày đặt: " + ngayDatLabel.Text;
            //g.DrawString(ngayDat, regularFont, brush, 100, 230);

            // Vẽ danh sách sản phẩm
            int startX = 100; // Điểm bắt đầu của danh sách sản phẩm
            int startY = 260; // Điểm bắt đầu của danh sách sản phẩm
            int lineHeight = 20; // Chiều cao của mỗi dòng

            // Vẽ tiêu đề danh sách sản phẩm
            string productHeader = "Sản phẩm\tSố lượng\t\tĐơn giá\t\t\tTổng tiền";
            g.DrawString(productHeader, regularFont, brush, startX, startY);

            startY += lineHeight;


            double tongtien = 0;
            // Vẽ từng sản phẩm trong danh sách
            foreach (Product_Print item in list)
            {
                string tenSanPham = item.tenSanpham;
                string soLuong = item.soluong.ToString();
                string donGia = item.dongia.ToString();
                string tong = item.tongtien.ToString();
                tongtien += Convert.ToDouble(tong);
                string productInfo = $"{tenSanPham}\t{soLuong}\t\t\t{donGia}\t\t\t{tong}";
                g.DrawString(productInfo, regularFont, brush, startX, startY);

                startY += lineHeight;
            }


            //Vẽ tổng tiền và tổng tiền có thuế(điều chỉnh tùy theo vị trí của bạn)
            string tongTien = "Tổng tiền: " + tongtien;
            g.DrawString(tongTien, regularFont, brush, 100, startY + 20);

            string tongTienCoThue = "Tổng tiền có thuế: " + tongtien;
            g.DrawString(tongTienCoThue, regularFont, brush, 100, startY + 40);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string diaChiVanChuyen = "";
            double tongTienHoaDon = 0;
            using (SqlConnection connection = sql.sqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SearchHoaDonUser", connection))
                {
                    string mahd = uiTextBox11.Text;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idhoadon", mahd));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            diaChiVanChuyen = reader["diaDiemDen"].ToString();
                            tongTienHoaDon = Convert.ToDouble(reader["TongTienBaoGomThue"]);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn với mã này.");
                        }
                    }
                }
            }


            GenerateQRCode(uiTextBox7.Text, uiTextBox6.Text, diaChiVanChuyen, tongTienHoaDon);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();
            ChiTietHoaDon model = null;
            string mahoadon = uiTextBox11.Text;
            using (SqlConnection connection =sql.sqlConnection())
            {
                connection.Open();
                string queryString = "select TenSanPham,ChiTietHoaDon.SoLuong,ChiTietHoaDon.DonGia,ChiTietHoaDon.TongTien from ChiTietHoaDon ,SanPham where MaHoaDon = '"+ mahoadon+"' and ChiTietHoaDon.MaSanPham = SanPham.MaSanPham";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {               
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new ChiTietHoaDon();
                            model.SoLuong = Convert.ToInt32(reader["SoLuong"].ToString());

                            model.SanPham = new SanPham();
                            model.SanPham.TenSanPham = reader["TenSanPham"].ToString();
                           
                            model.DonGia = Convert.ToDouble(reader["DonGia"].ToString());
                            model.TongTien = Convert.ToDouble(reader["TongTien"].ToString());
                            cthd.Add(model);
                        }
                    }
                }
            }
            float centerX = e.MarginBounds.Width / 2;
            float centerY = e.MarginBounds.Height / 2;

            // Define the title text
            string title = "HÓA ĐƠN THANH TOÁN";

            // Measure the size of the title text
            SizeF textSize = e.Graphics.MeasureString(title, new Font("Arial", 24, FontStyle.Bold));

            // Calculate the position for the title to be centered
            float titleX = centerX - (textSize.Width / 2);
            float titleY = centerY - (textSize.Height / 2);

            // Draw the centered title
            e.Graphics.DrawString(title, new Font("Arial", 24, FontStyle.Bold), Brushes.Black, new PointF(250, 60));
            e.Graphics.DrawString("Số hóa đơn : ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(330, 105));
            e.Graphics.DrawString(uiTextBox11.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(450, 105));

            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));

            e.Graphics.DrawString("Compary Name: " + "GAO NGON NHAT", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
            e.Graphics.DrawString("Client Name: " + uiTextBox6.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Address: " + uiTextBox5.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 250));



            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 325));

            e.Graphics.DrawString("Item Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 345));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(380, 345));
            e.Graphics.DrawString("Unit Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(510, 345));
            e.Graphics.DrawString("Total Price", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, 345));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 360));
            int yPos = 385;

            foreach (ChiTietHoaDon item in cthd)
            {
                e.Graphics.DrawString(item.SanPham.TenSanPham, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, yPos));
                e.Graphics.DrawString(item.SoLuong.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, yPos));
                e.Graphics.DrawString(item.DonGia.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(525, yPos));
                e.Graphics.DrawString(item.TongTien.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(675, yPos));
                yPos += 30;
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, yPos));

            double tongTienHoaDon = 0;
            double tongTienHoaDonVAT = 0;
            using (SqlConnection connection = sql.sqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SearchHoaDonUser", connection))
                {
                    string mahd = uiTextBox11.Text;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idhoadon", mahd));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tongTienHoaDon = Convert.ToDouble(reader["GiaTriHangHoa"]);

                            tongTienHoaDonVAT = Convert.ToDouble(reader["TongTienBaoGomThue"]);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn với mã này.");
                        }
                    }
                }
            }
            e.Graphics.DrawString("Total Amount:      $" + tongTienHoaDon, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 30));
            e.Graphics.DrawString("VAT:                   $" + (tongTienHoaDonVAT-tongTienHoaDon), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 60));
            e.Graphics.DrawString("Total To Pay:      $" + tongTienHoaDonVAT, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, yPos + 90));

            //// reset the variables
            //numberOfItemsPerPage = 0;
            //numberOfItemsPrintedSoFar = 0;

            e.Graphics.DrawString("Người mua hàng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(90, 800));
            e.Graphics.DrawString("Người bán hàng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 800));


            e.Graphics.DrawString("(Kí và ghi rõ họ tên)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(90, 830));
            e.Graphics.DrawString("(Kí và ghi rõ họ tên)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 830));










        }
    }
}
