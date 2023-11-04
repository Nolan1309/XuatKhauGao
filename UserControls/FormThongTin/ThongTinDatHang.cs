using QL_XuatKhauGao.Models;
using Sunny.UI;
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

namespace QL_XuatKhauGao.UserControls.FormThongTin
{
    public partial class ThongTinDatHang : Form
    {
        string idhd;
        string makh;
        //List<QuocGia> quocGias;
        Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
        DataProvider connec = new DataProvider();
        public ThongTinDatHang()
        {
            InitializeComponent();
        }
        public ThongTinDatHang(string idhoadon, string makhachhang)
        {
            InitializeComponent();
            this.idhd = idhoadon;
            this.makh = makhachhang;
        }
        private void ThongTinDatHang_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = connec.sqlConnection())
            {
                string sql = "select id,TenQuocGia from QuocGia";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                adapter.Dispose();
                cbGiaoden.DataSource = dt;
                cbGiaoden.DisplayMember = "TenQuocGia"; // Hiển thị tên quốc gia
                cbGiaoden.ValueMember = "id";
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string tenkh = btn_tenkh.Text;
            string sdt = btn_sdtkh.Text;
            string email = btn_email.Text;
            string diachi = btn_diachi.Text;

            string mahh = makh;
            string idquocgia = cbGiaoden.SelectedValue.ToString();


            string soLC = btn_solc.Text;
            string ngayMoLC = Convert.ToString(date_openLC.Month) + "/" + Convert.ToString(date_openLC.Day) + "/" + Convert.ToString(date_openLC.Year);
            string ngayLapLC = Convert.ToString(date_createLc.Month) + "/" + Convert.ToString(date_createLc.Day) + "/" + Convert.ToString(date_createLc.Year);
            string ngayHieuLucLC = Convert.ToString(date_useLC.Month) + "/" + Convert.ToString(date_useLC.Day) + "/" + Convert.ToString(date_useLC.Year);
            string ngayDongLC = Convert.ToString(date_closelc.Month) + "/" + Convert.ToString(date_closelc.Day) + "/" + Convert.ToString(date_closelc.Year);



            //var customerToUpdate = db.khachhangs.FirstOrDefault(kh => kh.idkhachhang == Convert.ToInt32(makh));
            int row = 0;
            using (SqlConnection connection = connec.sqlConnection())
            {
                connection.Open();

                string sql = "select * from khachhang where idkhachhang = " + mahh;
                SqlDataAdapter sqlData = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                sqlData.Dispose();
                row = dt.Rows.Count;
                connection.Close();
            }

            if (row != 0)
            {
                using (SqlConnection connection = connec.sqlConnection())
                {
                    connection.Open();
                    string sql = "update khachhang set tenkhachhang = N'" + tenkh + "' , sdtKH = '" + sdt + "', email = '" + email + "',diachi = N'" + diachi + "' where idkhachhang = " + mahh;
                    SqlDataAdapter sqlData = new SqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    sqlData.Fill(dt);
                    sqlData.Dispose();
                    connection.Close();
                }
            }
            string tenQuocGiaString;
            using (SqlConnection connection = connec.sqlConnection())
            {
                string sql = "SELECT TenQuocGia FROM QuocGia WHERE id = @ID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", idquocgia);
                connection.Open();
                object tenQuocGia = command.ExecuteScalar();
                tenQuocGiaString = tenQuocGia.ToString();
                connection.Close();
            }
            // Gán giá trị ngày tháng cho datePicker
            DateTime selectedDate = date_useLC.Value;
            DateTime nextDay = selectedDate.AddDays(1);
            date_useLC.Value = nextDay;
            string ngayVanchuyen = Convert.ToString(date_useLC.Month) + "/" + Convert.ToString(date_useLC.Day) + "/" + Convert.ToString(date_useLC.Year);

            using (SqlConnection connection = connec.sqlConnection())
            {
                connection.Open();

                string sql = "INSERT INTO VanChuyen (idHoaDon, ngayVanChuyen, diaDiemXuatPhat, diaDiemDen, idQuocGia) " +
                             "VALUES (@idHoaDon, @ngayVanChuyen, N'Việt Nam', @diaDiemDen, @idQuocGia)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idHoaDon", idhd);
                    command.Parameters.AddWithValue("@ngayVanChuyen", date_useLC.Value.ToString());

                    command.Parameters.AddWithValue("@diaDiemDen", tenQuocGiaString);
                    command.Parameters.AddWithValue("@idQuocGia", idquocgia);

                    int rowsAffected = command.ExecuteNonQuery();

                }
            }

            using (SqlConnection connection = connec.sqlConnection())
            {
                connection.Open();

                string sql = "INSERT INTO NgayQuyetDinh (idHoaDon, ngayLapLc, ngayHieuLuc) " +
                             "VALUES (@idHoaDon, @ngayLapLc, @ngayHieuLuc)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idHoaDon", idhd);
                    command.Parameters.AddWithValue("@ngayLapLc", ngayLapLC);
                    command.Parameters.AddWithValue("@ngayHieuLuc", ngayHieuLucLC);

                    int rowsAffected = command.ExecuteNonQuery();
                  
                }
            }
            using (SqlConnection connection = connec.sqlConnection())
            {
                connection.Open();

                string sql = "INSERT INTO ChiTietLC (idHoaDon, soLC, ngayMo_LC, ngayDong_LC) " +
                             "VALUES (@idHoaDon, @soLC, @ngayMo_LC, @ngayDong_LC)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idHoaDon", idhd);
                    command.Parameters.AddWithValue("@soLC", soLC);
                    command.Parameters.AddWithValue("@ngayMo_LC", ngayMoLC);
                    command.Parameters.AddWithValue("@ngayDong_LC", ngayDongLC);

                    int rowsAffected = command.ExecuteNonQuery();
                 
                }
                connection.Close();

            }
            using (SqlConnection connection = connec.sqlConnection())
            {
                connection.Open();

                string sql = "UPDATE HoaDon SET IdHinhThucThanhToan = @IdHinhThucThanhToan, NgayNhanHangdukien = @ngaynhanhang WHERE MaHoaDon = @MaHoaDon";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdHinhThucThanhToan", 1);
                    command.Parameters.AddWithValue("@ngaynhanhang", ngayDongLC);

                    command.Parameters.AddWithValue("@MaHoaDon", idhd);

                    int rowsAffected = command.ExecuteNonQuery();
                   
                }
                connection.Close();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
