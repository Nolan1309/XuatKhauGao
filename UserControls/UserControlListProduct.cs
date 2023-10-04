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
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.Models;

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlListProduct : UserControl
    {

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
            DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            List<SanPham> dsSP = db.SanPhams.ToList();

            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            container_grid.Columns.Add(imageCol);

            foreach (SanPham item in dsSP)
            {
                byte[] imageBytes = Convert.FromBase64String(item.hinhanh);
                MemoryStream ms1 = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms1.Write(imageBytes, 0, imageBytes.Length);

                Bitmap output1 = new Bitmap(ms1, false);
                ms1.Dispose();
                container_grid.Rows.Add(new object[] { item.id.ToString(), item.ten, item.DanhMuc.ten , item.mota, item.gia.ToString(), item.trongluong.ToString(), item.soluong.ToString(), item.ngaytao.ToString(), output1}) ;
            }
        }



        private void container_grid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sanphamSelected.id = int.Parse(container_grid.Rows[e.RowIndex].Cells[0].Value.ToString());
            /*sanphamSelected.ten = container_grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            sanphamSelected.mota = container_grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            sanphamSelected.gia = double.TryParse(container_grid.Rows[e.RowIndex].Cells[3].Value.ToString());
            sanphamSelected.soluong = int.Parse(container_grid.Rows[e.RowIndex].Cells[4].Value.ToString());
            sanphamSelected.trongluong = double.Parse(container_grid.Rows[e.RowIndex].Cells[5].Value.ToString());*/
        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            if(sanphamSelected.id != 0)
            {
                DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                SanPham sp = db.SanPhams.Where(item => item.id == sanphamSelected.id).FirstOrDefault();
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
                
                if (sanphamSelected.id != 0)
                {
                    foreach (DataGridViewRow dgvr in container_grid.Rows)
                    {
                        if (dgvr.Selected == true)
                        {
                            container_grid.Rows.Remove(dgvr);
                        }
                    }
                    DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                    SanPham sp = db.SanPhams.Where(row => row.id == sanphamSelected.id).FirstOrDefault();
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
    }
}
