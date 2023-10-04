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

        List<DanhMuc> danhMuc;
        private void UserControlCreateProduct_Load(object sender, EventArgs e)
        {
            DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            danhMuc = db.DanhMucs.ToList();
            for (int i = 0; i < danhMuc.Count; i++)
            {
                if(danhMuc[i].ten == sanpham.DanhMuc.ten)
                {
                    tb_proCategory.Items.Add(danhMuc[i].ten);
                    tb_proCategory.SelectedIndex = i;
                }
                else
                {
                    tb_proCategory.Items.Add(danhMuc[i].ten);

                }
            }

            tb_proName.Text = sanpham.ten; 
            tb_proDesc.Text = sanpham.mota; 
            tb_proPrice.Text = sanpham.gia.ToString(); 
            tb_proQuantity.Text = sanpham.soluong.ToString();
            tb_proWeight.Text = sanpham.trongluong.ToString(); 
                byte[] imageBytes = Convert.FromBase64String(sanpham.hinhanh);
            MemoryStream ms1 = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms1.Write(imageBytes, 0, imageBytes.Length);

            Bitmap output1 = new Bitmap(ms1, false);
            ms1.Dispose();
            pictureBox1.Image = output1;

        }

        Anh anh = new Anh();
        private async void uiButton1_Click(object sender, EventArgs e)
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

                /*byte[] imageBytes = Convert.FromBase64String(result.img);
                MemoryStream ms1 = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);

                Bitmap output1 = new Bitmap(ms1, false);
                ms1.Dispose();
                pictureBox2.Image = output1;*/

            }

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
                DanhMuc dm = danhMuc.Find(t => t.ten == tb_proCategory.SelectedItem.ToString());
                SanPham sp = db.SanPhams.Where(item => item.id == sanpham.id).FirstOrDefault();
                sp.ten = tb_proName.Text;
                sp.gia = double.Parse(tb_proPrice.Text);
                sp.trongluong = double.Parse(tb_proWeight.Text);
                sp.hinhanh = sanpham.hinhanh; // error
                sp.mota = tb_proDesc.Text;
                sp.soluong = int.Parse(tb_proQuantity.Text);
                sp.DanhMuc_id = dm.id;
                sp.ngaytao = sp.ngaytao;
                sp.hinhanh = anh.img != null ? anh.img : sanpham.hinhanh;
                db.SaveChanges();
                /*UserControlListProduct control = new UserControlListProduct();
                MainControlClass.showControl(control, Content);*/
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
