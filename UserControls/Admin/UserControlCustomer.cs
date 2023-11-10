using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using QL_XuatKhauGao.Models;
using QL_XuatKhauGao.UserControls.Admin;

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlCustomer : UserControl
    {
        public string maKhachHang { get; set; }
        DataProvider db = new DataProvider();
        public UserControlCustomer()
        {
            InitializeComponent();
            LoadDATA();
        }
        void LoadDATA()
        {
            using (SqlConnection connection = db.sqlConnection())
            {
                connection.Open();

                string sql = "SELECT idkhachhang, tenkhachhang, diachi, sdtKH , email FROM khachhang";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idkhachhang = reader.GetInt32(reader.GetOrdinal("idkhachhang"));
                            string tenkhachhang = reader.GetString(reader.GetOrdinal("tenkhachhang"));
                            string diachi = reader.IsDBNull(reader.GetOrdinal("diachi")) ? string.Empty : reader.GetString(reader.GetOrdinal("diachi"));
                            string sdtKH = reader.IsDBNull(reader.GetOrdinal("sdtKH")) ? string.Empty : reader.GetString(reader.GetOrdinal("sdtKH"));
                            string email = reader.GetString(reader.GetOrdinal("email"));
                            // Gán dữ liệu vào DataGridView
                            uiDataGridView1.Rows.Add(idkhachhang, tenkhachhang, diachi, sdtKH,email);
                        }
                    }
                }
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string searchName = uiTextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                uiDataGridView1.Rows.Clear();
                using (SqlConnection connection = db.sqlConnection())
                {
                    connection.Open();
                    string sql = "SELECT idkhachhang, tenkhachhang, diachi, sdtKH , email FROM khachhang where tenkhachhang like N'%"+searchName+"%'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idkhachhang = reader.GetInt32(reader.GetOrdinal("idkhachhang"));
                                string tenkhachhang = reader.GetString(reader.GetOrdinal("tenkhachhang"));
                                string diachi = reader.IsDBNull(reader.GetOrdinal("diachi")) ? string.Empty : reader.GetString(reader.GetOrdinal("diachi"));
                                string sdtKH = reader.IsDBNull(reader.GetOrdinal("sdtKH")) ? string.Empty : reader.GetString(reader.GetOrdinal("sdtKH"));
                                string email = reader.GetString(reader.GetOrdinal("email"));
                                // Gán dữ liệu vào DataGridView
                                uiDataGridView1.Rows.Add(idkhachhang, tenkhachhang, diachi, sdtKH,email);
                            }
                        }
                    }
                }
            }
            else
            {
                // Nếu TextBox tìm kiếm trống, hiển thị toàn bộ dữ liệu
                uiDataGridView1.Rows.Clear();
                LoadDATA();
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };
          
          
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming you are importing data from the first worksheet.

                    DataTable dt = new DataTable();

                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        dt.Columns.Add(firstRowCell.Text);
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dt.NewRow();

                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Text;
                        }

                        dt.Rows.Add(newRow);
                    }

                    uiDataGridView1.DataSource = dt; // Display the data in your DataGridView control.
                }
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            ; // Thay thế bằng ID của khách hàng bạn muốn cập nhật.        
            UpdateCustomer form = new UpdateCustomer(maKhachHang);
            form.ShowDialog();

        }

        private void uiDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (uiDataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = uiDataGridView1.SelectedRows[0];

                // Lấy giá trị từ các ô cụ thể trong dòng
                 maKhachHang = selectedRow.Cells[0].Value.ToString();
                

            }
        }
    }
}
