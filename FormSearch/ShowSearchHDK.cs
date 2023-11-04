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

namespace QL_XuatKhauGao.FormSearch
{
    public partial class ShowSearchHDK : Form
    {
        DataProvider db = new DataProvider();
        public string IdHoadon { get; set; }
        public string Makhachhang { get; set; }
        public ShowSearchHDK()
        {
            InitializeComponent();
        }
        public ShowSearchHDK(string mahoadon, string makhachhang)
        {
            InitializeComponent();
            this.IdHoadon = mahoadon;
            this.Makhachhang = makhachhang;
            DisplayHoaDon(Convert.ToInt32(IdHoadon));
        }
        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DisplayHoaDon(int idHoaDon)
        {

            using (SqlConnection connection = db.sqlConnection())
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SearchHoaDonUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idhoadon", idHoaDon));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {


                            uiTextBox1.Text = reader["MaHoaDon"].ToString();
                            uiTextBox2.Text = (reader["NgayOrder"]).ToString();
                            uiTextBox3.Text = reader["ngayVanChuyen"].ToString();
                            uiTextBox4.Text = reader["diaDiemXuatPhat"].ToString();
                            uiTextBox5.Text = reader["diaDiemDen"].ToString();
                            uiTextBox6.Text = reader["CustomerName"].ToString();
                            uiTextBox7.Text = reader["PhoneNumber"].ToString();
                            uiTextBox8.Text = reader["soLC"].ToString();
                            uiTextBox9.Text = reader["ngayMo_LC"].ToString();
                            uiTextBox10.Text = reader["ngayDong_LC"].ToString();                       
                            uiTextBox11.Text =    string.Format("{0:#,##0}", reader["GiaTriHangHoa"]);
                            uiTextBox13.Text = string.Format("{0:#,##0}", reader["TongTienBaoGomThue"]);
                            double gtH = Convert.ToDouble(uiTextBox11.Text);
                            double gtSUM = Convert.ToDouble(uiTextBox13.Text);
                            double vat = gtSUM - gtH;
                            uiTextBox12.Text  = string.Format("{0:#,##0}", vat);

                        }

                    }
                }
            }
        }

        private void LoadDataGridView()
        {


            using (SqlConnection connection = db.sqlConnection())
            {
                connection.Open();

                string query = "SELECT SP.TenSanPham, CHD.SoLuong, CHD.DonGia, CHD.TongTien FROM ChiTietHoaDon AS CHD INNER JOIN SanPham AS SP ON CHD.MaSanPham = SP.MaSanPham WHERE CHD.MaHoaDon = 1";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow item in dataTable.Rows)
                    {



                        uiDataGridView1.Rows.Add(
                            item["TenSanPham"],

                            item["SoLuong"],

                            string.Format("{0:#,##0}", item["DonGia"]),
                            string.Format("{0:#,##0}", item["TongTien"]));

                    }
                }
            }
        }

        private void ShowSearchHDK_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            GenerateQRCode(uiTextBox7.Text, uiTextBox6.Text, uiTextBox5.Text, Convert.ToDouble(uiTextBox13.Text));
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
            pictureBox1.Width = 150;  // Thay 'newWidth' bằng giá trị chiều rộng mới
            pictureBox1.Height = 150;  // Thay 'newHeight' bằng giá trị chiều cao mới

            // Hiển thị ảnh mã QR với kích thước mới trong pictureBox1
            pictureBox1.Image = new Bitmap(qrCodeBitmap, 150, 150);
        }
        public void check()
        {
            string diaChiVanChuyen = "";
            double tongTienHoaDon = 0;
            using (SqlConnection connection = db.sqlConnection())
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


            GenerateQRCode(uiTextBox7.Text, uiTextBox6.Text, uiTextBox5.Text,Convert.ToDouble(uiTextBox13.Text) );
        }
    }
}
