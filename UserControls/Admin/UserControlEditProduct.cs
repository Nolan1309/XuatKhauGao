using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_XuatKhauGao.Data;
using QL_XuatKhauGao.Models;
using QL_XuatKhauGao.UserControls;
using QL_XuatKhauGao.Helpers;

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlEditProduct : UserControl
    {

        SanPham sanpham;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "MLqqPEzqSm3GNeM784IiyO1mjmgoApd2oiRGPPmw",
            BasePath = "https://dbxuatkhaugao-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        public Control Content;
        public UserControlEditProduct(SanPham sanpham)
        {
            InitializeComponent();
            client = new FirebaseClient(config);
            this.sanpham = sanpham;

        }

        public UserControlEditProduct(SanPham sanpham, Control content)
        {
            InitializeComponent();
            client = new FirebaseClient(config);
            this.Content = content;
            this.sanpham = sanpham;
        }

        List<Category> danhMuc;
        private void UserControlCreateProduct_Load(object sender, EventArgs e)
        {
            //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

            db.Configuration.LazyLoadingEnabled = false;
            danhMuc = db.Categories.ToList();
            for (int i = 0; i < danhMuc.Count; i++)
            {
                if(danhMuc[i].TenCategory == sanpham.Category.TenCategory)
                {
                    tb_proCategory.Items.Add(danhMuc[i].TenCategory);
                    tb_proCategory.SelectedIndex = i;
                }
                else
                {
                    tb_proCategory.Items.Add(danhMuc[i].TenCategory);

                }
            }

            tb_proName.Text = sanpham.TenSanPham; 
            tb_proDesc.Text = sanpham.MoTa; 
            tb_proPrice.Text = sanpham.Gia.ToString(); 
            tb_proQuantity.Text = sanpham.Soluong.ToString();
            tb_proWeight.Text = sanpham.truongluong.ToString(); 
            if(sanpham.hinhanh != null)
            {
                byte[] imageBytes = Convert.FromBase64String(sanpham.hinhanh);
                MemoryStream ms1 = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms1.Write(imageBytes, 0, imageBytes.Length);

                Bitmap output1 = new Bitmap(ms1, false);
                ms1.Dispose();
                pictureBox1.Image = output1;
            }
            else
            {
                pictureBox1.Image = null;
            }

        }

        bool checkValueTextBox(SanPham sanpham)
        {
            bool ignore = true;
            if (sanpham.TenSanPham == "")
            {
                lb_errorProName.Text = "Vui lòng điền vào tên sản phẩm!";
                ignore = false;
            }

            if (sanpham.Gia <= 0)
            {
                if(sanpham.Gia == 0)
                {
                    lb_errorProPricee.Text = "Vui lòng điền vào giá sản phẩm!";
                }
                else
                {
                    lb_errorProPricee.Text = "Giá sản phẩm phải là một số thực và > 0";
                }
                ignore = false;
            }

            if (sanpham.truongluong <= 0)
            {
                if (sanpham.truongluong == 0)
                {
                    lb_errorProWeight.Text = "Vui lòng điền vào trọng lượng sản phẩm!";
                }
                else
                {
                    lb_errorProWeight.Text = "Trọng lượng sản phẩm phải là một số thực và > 0";
                }
                ignore = false;
            }
            if (sanpham.Soluong <= 0)
            {
                if (sanpham.truongluong == 0)
                {
                    lb_errorProQuantity.Text = "Vui lòng điền vào số lượng sản phẩm!";
                }
                else
                {
                    lb_errorProQuantity.Text = "Số lượng sản phẩm phải là một số nguyên và > 0";
                }
                ignore = false; ;
            }
            if (sanpham.MoTa == "")
            {
                lb_errorProDesc.Text = "Vui lòng điền vào mô tả sản phẩm!";
                ignore = false; ;
            }
            return ignore;
        }

        Anh anh = new Anh();

        private void tb_proName_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Name == "tb_proName")
            {
                lb_errorProName.Text = "";
            }
            if (ctr.Name == "tb_proPrice")
            {
                lb_errorProPricee.Text = "";
            }
            if (ctr.Name == "tb_proWeight")
            {
                lb_errorProWeight.Text = "";
            }
            if (ctr.Name == "tb_proQuantity")
            {
                lb_errorProQuantity.Text = "";
            }
            if (ctr.Name == "tb_proDesc")
            {
                lb_errorProDesc.Text = "";
            }
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            try
            {
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

                //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                Category dm = danhMuc.Find(t => t.TenCategory == tb_proCategory.SelectedItem.ToString());
                SanPham sp = db.SanPhams.Where(item => item.MaSanPham == sanpham.MaSanPham).FirstOrDefault();
                sp.TenSanPham = tb_proName.Text;
                sp.Gia = (tb_proPrice.Text != "") ? (double.TryParse(tb_proPrice.Text, out _) ? double.Parse(tb_proPrice.Text) : -1) : 0;
                sp.truongluong = (tb_proWeight.Text != "") ? (double.TryParse(tb_proWeight.Text, out _) ? double.Parse(tb_proWeight.Text) : -1) : 0;
                sp.hinhanh = sanpham.hinhanh; // error
                sp.MoTa = tb_proDesc.Text;
                sp.Soluong = (tb_proQuantity.Text != "") ? (int.TryParse(tb_proQuantity.Text, out _) ? int.Parse(tb_proQuantity.Text) : -1) : 0;
                sp.CategoryID = dm.CategoryID;
                sp.ngaytao = sp.ngaytao;
                sp.hinhanh = anh.img != null ? anh.img : sanpham.hinhanh;
                if (checkValueTextBox(sp))
                {
                    db.SaveChanges();
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb_proCategory.Items.Count; i++)
            {
                if (tb_proCategory.Items[i].ToString() == sanpham.Category.TenCategory)
                {
                    tb_proCategory.SelectedIndex = i;
                }
            }
            tb_proName.Text = sanpham.TenSanPham;
            tb_proDesc.Text = sanpham.MoTa;
            tb_proPrice.Text = sanpham.Gia.ToString();
            tb_proQuantity.Text = sanpham.Soluong.ToString();
            tb_proWeight.Text = sanpham.truongluong.ToString();
            byte[] imageBytes = Convert.FromBase64String(sanpham.hinhanh);
            MemoryStream ms1 = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms1.Write(imageBytes, 0, imageBytes.Length);

            Bitmap output1 = new Bitmap(ms1, false);
            ms1.Dispose();
            pictureBox1.Image = output1;
        }

        private async void tb_proImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Title = "Chọn hình ảnh";
            /*op1.Filter = "Chọn định dạng(*.jpg)|*jpg";*/
            if (op1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(op1.FileName);
                pictureBox1.Image = img.GetThumbnailImage(68, 58, null, new IntPtr());

                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);
                var image = new Anh
                {
                    img = output
                };
                SetResponse response = await client.SetAsync("todos", image);
                anh = response.ResultAs<Anh>();
            }
        }

        private void tb_proName_Click(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Name == "tb_proName")
            {
                lb_errorProName.Text = "";
            }
            if (ctr.Name == "tb_proPrice")
            {
                lb_errorProPricee.Text = "";
            }
            if (ctr.Name == "tb_proWeight")
            {
                lb_errorProWeight.Text = "";
            }
            if (ctr.Name == "tb_proQuantity")
            {
                lb_errorProQuantity.Text = "";
            }
            if (ctr.Name == "tb_proDesc")
            {
                lb_errorProDesc.Text = "";
            }
        }
    }
}
