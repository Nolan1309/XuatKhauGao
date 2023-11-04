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
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.Models;

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlListProduct : UserControl
    {
        DataProvider db1 = new DataProvider();

        public Control Content;
        public UserControlListProduct()
        {
            InitializeComponent();
        }
        public UserControlListProduct(Control content)
        {
            InitializeComponent();
            this.Content = content;
        }


        SanPham sanphamSelected = new SanPham();

        private void UserControlListProduct_Load(object sender, EventArgs e)
        {
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
            //Final_XuatKhauGaoEntities1 db2 = new Final_XuatKhauGaoEntities1();
            ////DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            List<SanPham> dsSP = db.SanPhams.ToList();
            //using (SqlConnection connection = db1.sqlConnection())
            //{
            //    string sql = "select * from SanPham";
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //}

            //List<SanPham> dsSP = db2.SanPhams.ToList();


            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            container_grid.Columns.Add(imageCol);

            foreach (SanPham item in dsSP)
            {
                byte[] imageBytes = Convert.FromBase64String(item.hinhanh ?? "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAA6AEQDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD0qiiigAooooAKKlhtppz+6jZsdSBxUVABRRRQAlFFFAC0UUUAXINNnmVXbbFG3RnOM/StAaWtsMpbm5k9XYKo/Cqsf+kWlrJ1aCUI30J4/wAKHS2e8vTcSshVjsx360AWgmqmaNiirGrA+WjADH51WvNKuBcSvFGDFncDuFVbS0lvHZUONq5JP6Cp7COSG/aOQFWEbZB+lAGfRSUtACUUUUALRRRQBf0mRRdeS/3JRj8RyKm8hP7UmkuIpTGHJAVCd3/1qy1YowZSQwOQR2qf+0Lv/n4k/OgDbguLW2QrFBOoJyf3ZqFiJtS85I5AvlMGLIRzisv7fd/8/En50hv7sgg3EhB96AK9FFFACUUUUALRSUUALSUUUALSUUUALRSUUAFFFFAH/9k=");
                MemoryStream ms1 = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms1.Write(imageBytes, 0, imageBytes.Length);

                Bitmap output1 = new Bitmap(ms1, false);
                ms1.Dispose();
                container_grid.Rows.Add(new object[] { item.MaSanPham.ToString(), item?.TenSanPham, item?.Category?.TenCategory , item?.MoTa, item?.Gia.ToString(), item?.truongluong.ToString(), item?.Soluong.ToString(), item?.ngaytao?.ToString("dd/MM/yyyy").Replace('-', '/'), output1 }) ;
            }
        }



        private void container_grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sanphamSelected.MaSanPham = int.Parse(container_grid.Rows[e.RowIndex].Cells[0].Value.ToString());
            /*sanphamSelected.ten = container_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            sanphamSelected.mota = container_grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            sanphamSelected.gia = double.TryParse(container_grid.Rows[e.RowIndex].Cells[3].Value.ToString());
            sanphamSelected.soluong = int.Parse(container_grid.Rows[e.RowIndex].Cells[4].Value.ToString());
            sanphamSelected.trongluong = double.Parse(container_grid.Rows[e.RowIndex].Cells[5].Value.ToString());*/
        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            if(sanphamSelected.MaSanPham != 0)
            {
                Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
                //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                SanPham sp = db.SanPhams.Where(item => item.MaSanPham == sanphamSelected.MaSanPham).FirstOrDefault();
                UserControlEditProduct control = new UserControlEditProduct(sp, Content);
                MainControlClass.showControl(control, Content);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vào sản phẩm muốn sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void uiSymbolButton6_Click(object sender, EventArgs e)
        {
            UserControlCreateProduct control = new UserControlCreateProduct(Content);
            MainControlClass.showControl(control, Content);
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (sanphamSelected.MaSanPham != 0)
                {
                    foreach (DataGridViewRow dgvr in container_grid.Rows)
                    {
                        if (dgvr.Selected == true)
                        {
                            container_grid.Rows.Remove(dgvr);
                        }
                    }
                    Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
                    //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                    SanPham sp = db.SanPhams.Where(row => row.MaSanPham == sanphamSelected.MaSanPham).FirstOrDefault();
                    db.SanPhams.Remove(sp);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn vào sản phẩm muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridViewCell GetCellWhereTextExistsInGridView(string searchText, DataGridView dataGridView, int columnIndex)
        {
            DataGridViewCell cellWhereTextIsMet = null;

            // For every row in the grid (obviously)
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // I did not test this case, but cell.Value is an object, and objects can be null
                // So check if the cell is null before using .ToString()
                if (row.Cells[columnIndex].Value != null && searchText == row.Cells[columnIndex].Value.ToString())
                {
                    // the searchText is equals to the text in this cell.
                    cellWhereTextIsMet = row.Cells[columnIndex];
                    break;
                }
            }

            return cellWhereTextIsMet;
        }


        private void btn_search_Click(object sender, EventArgs e)
        {
            removeSelectedRows();
            if (tb_search.Text.Length != 0)
            {
                searchDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào ô tìm kiếm!");
            }
        }

        void removeSelectedRows()
        {
            if (container_grid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in container_grid.SelectedRows)
                {
                    row.Selected = false;
                }
            }
        }

        void searchDataGridView()
        {
            string searchValue = tb_search.Text;
            int rowIndex = 1;  //this one is depending on the position of cell or column
                               //string first_row_data=container_grid.Rows[0].Cells[0].Value.ToString() ;

            container_grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                bool valueResulet = true;
                foreach (DataGridViewRow row in container_grid.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToLower().Contains(searchValue.ToLower().Trim()))
                    {
                        rowIndex = row.Index;
                        container_grid.Rows[rowIndex].Selected = true;
                        rowIndex++;
                        valueResulet = false;
                    }
                }
                if (valueResulet != false)
                {
                    MessageBox.Show("Không tìm thấy!");
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void tb_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            removeSelectedRows();
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (tb_search.Text.Length != 0)
                {
                    searchDataGridView();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào ô tìm kiếm!");
                }
            }
        }

        private void tb_search_Leave(object sender, EventArgs e)
        {
            if (tb_search.Text == "")
            {
                tb_search.Text = "Tìm kiếm tên sản phẩm...";
                tb_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(176)))), ((int)(((byte)(190)))));
            }
        }

        private void tb_search_Enter(object sender, EventArgs e)
        {
            if(tb_search.Text == "Tìm kiếm tên sản phẩm...")
            {
                tb_search.Text = "";
                tb_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < container_grid.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = container_grid.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < container_grid.Rows.Count; i++)
                    {
                        for (int j = 0; j < container_grid.Columns.Count; j++)
                        {
                            if (container_grid.Rows[i].Cells[j].Value != null)
                            {
                                if (container_grid.Rows[i].Cells[j].Value.GetType() != typeof(Bitmap))
                                {
                                    /*byte[] imageBytes = Convert.FromBase64String("/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAA6AEQDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD0qiiigAooooAKKlhtppz+6jZsdSBxUVABRRRQAlFFFAC0UUUAXINNnmVXbbFG3RnOM/StAaWtsMpbm5k9XYKo/Cqsf+kWlrJ1aCUI30J4/wAKHS2e8vTcSshVjsx360AWgmqmaNiirGrA+WjADH51WvNKuBcSvFGDFncDuFVbS0lvHZUONq5JP6Cp7COSG/aOQFWEbZB+lAGfRSUtACUUUUALRRRQBf0mRRdeS/3JRj8RyKm8hP7UmkuIpTGHJAVCd3/1qy1YowZSQwOQR2qf+0Lv/n4k/OgDbguLW2QrFBOoJyf3ZqFiJtS85I5AvlMGLIRzisv7fd/8/En50hv7sgg3EhB96AK9FFFACUUUUALRSUUALSUUUALSUUUALRSUUAFFFFAH/9k=");
                                    MemoryStream ms1 = new MemoryStream(imageBytes, 0,
                                      imageBytes.Length);

                                    // Convert byte[] to Image
                                    ms1.Write(imageBytes, 0, imageBytes.Length);

                                    Bitmap output1 = new Bitmap(ms1, false);
                                    ms1.Dispose();

                                    string imgString = @"D:\Tai_lieu_mon_hoc_hk1_2023\NhapMon_CNPM\Do_An\P_XuatKhauGao\QL_XuatKhauGao\Content\Images\timthumb(3).jfif";
                                    Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 2, j + 1];
                                    float Left = (float)((double)oRange.Left);
                                    float Top = (float)((double)oRange.Top);
                                    const float ImageSize = 32;
                                    worksheet.Shapes.AddPicture(imgString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
                                    oRange.RowHeight = ImageSize + 2;
                                    worksheet.Cells[i + 2, j + 1] = container_grid.Rows[i].Cells[j].Value.ToString();*/
                                    worksheet.Cells[i + 2, j + 1] = container_grid.Rows[i].Cells[j].Value.ToString();
                                }
                               
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    /*SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
    }
}
