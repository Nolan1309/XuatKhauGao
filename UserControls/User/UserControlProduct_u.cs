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
using QL_XuatKhauGao.UserControls.Admin;

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlProduct_u : Sunny.UI.UIUserControl
    {

      
        Control Content;
        public  List<SanPham> dssporder = new List<SanPham>();
        public event Action<SanPham> ProductAddedToCart;
        public UserControlProduct_u()
        {
            InitializeComponent();
        }
        public UserControlProduct_u(List<SanPham> sanPhams)
        {
            InitializeComponent();
            dssporder = sanPhams;
           
        }
        public UserControlProduct_u(Control Content)
        {
            InitializeComponent();
            this.Content = Content;
        }

        void InitCart(List<SanPham> dsSP)
        {
            foreach(SanPham item in dsSP)
            {
                renderCart(item);
            }
        }

        void renderCart(SanPham sp)
        {
            //create panel container 
            Panel panel_container = new Panel();
            panel_container.BackColor = System.Drawing.Color.WhiteSmoke;
            panel_container.Padding = new System.Windows.Forms.Padding(10);
            panel_container.Size = new System.Drawing.Size(207, 268);
            //panel top
            Panel panel_container_top = new Panel();
            panel_container_top.Dock = System.Windows.Forms.DockStyle.Top;
            panel_container_top.Size = new System.Drawing.Size(187, 90);

            PictureBox pic = new PictureBox();
            pic.Dock = System.Windows.Forms.DockStyle.Fill;
            pic.Image = ConvertStringToBitmap.convertToBitmap(sp.hinhanh);
            pic.Size = new System.Drawing.Size(187, 90);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.TabStop = false;
            panel_container_top.Controls.Add(pic);
            panel_container.Controls.Add(panel_container_top);


            //panel bottom
            Panel panel_container_bottom = new Panel();
            panel_container_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_container_bottom.Size = new System.Drawing.Size(187, 158);

            //panel bottom content
            Panel panel_container_bottom_content = new Panel();
            panel_container_bottom_content.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_container_bottom_content.Size = new System.Drawing.Size(187, 118);

            Panel panel_container_bottom_price = new Panel();
            panel_container_bottom_price.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_container_bottom_price.Size = new System.Drawing.Size(187, 42);
            Label lb_price = new Label();
            lb_price.Dock = System.Windows.Forms.DockStyle.Fill;
            lb_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lb_price.Name = "price" + sp.MaSanPham.ToString();
            lb_price.Size = new System.Drawing.Size(187, 42);
            lb_price.Text = "đ " + sp.Gia.ToString();
            lb_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel_container_bottom_price.Controls.Add(lb_price);

            Panel panel_container_bottom_label = new Panel();
            panel_container_bottom_label.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_container_bottom_label.Size = new System.Drawing.Size(187, 76);
            Label lb_name = new Label();
            lb_name.Dock = System.Windows.Forms.DockStyle.Fill;
            lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lb_name.Name = "name" + sp.MaSanPham.ToString();
            lb_name.Size = new System.Drawing.Size(187, 42);
            lb_name.Text = sp.TenSanPham;
            lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel_container_bottom_label.Controls.Add(lb_name);

            panel_container_bottom_content.Controls.Add(panel_container_bottom_price);
            panel_container_bottom_content.Controls.Add(panel_container_bottom_label);
            panel_container_bottom.Controls.Add(panel_container_bottom_content);

            //panel bottom button
            Panel panel_container_bottom_btn = new Panel();
            panel_container_bottom_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_container_bottom_btn.Size = new System.Drawing.Size(187, 40);

            Button btn_buy = new Button();
            btn_buy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            btn_buy.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_buy.ForeColor = System.Drawing.Color.White;
            btn_buy.Size = new System.Drawing.Size(187, 40);
            btn_buy.Text = "Mua ngay";
            btn_buy.Name = sp.MaSanPham.ToString();
            btn_buy.Click += new System.EventHandler(button_Click);
            panel_container_bottom_btn.Controls.Add(btn_buy);
            panel_container_bottom.Controls.Add(panel_container_bottom_btn);


            panel_container.Controls.Add(panel_container_bottom);


            // add control
            flowLayoutPanel3.Controls.Add(panel_container);
        }

        private void UserControlProduct_u_Load(object sender, EventArgs e)
        {
            //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();
            
            

            List<SanPham> dsSP = db.SanPhams.ToList();
            InitCart(dsSP);
            

        }
        private void button_Click(object sender, EventArgs e)
        {         
            Button btn = (Button)sender;
            //DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            Final_XuatKhauGaoEntities1 db = new Final_XuatKhauGaoEntities1();

            int id = int.Parse(btn.Name);
            SanPham sp = db.SanPhams.Where(item => item.MaSanPham == id).FirstOrDefault();

            OrderSanPham orderSanPham = new OrderSanPham(sp, dssporder);

            


            orderSanPham.ShowDialog();
            OrderSanPham orderSan = new OrderSanPham();
            dssporder.AddRange(orderSan.returnds()) ;

            //Form_User cart = new Form_User(dssporder);
            //ProductAddedToCart?.Invoke(sp);
            orderSanPham.Close();
        }
        public void ClearOrderList()
        {          
            dssporder.Clear();
            OrderSanPham orderSan = new OrderSanPham();
            orderSan.ClearAllLists();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (!Form_User.Instance.PnlContainer.Controls.ContainsKey("UserControlProductDetail"))
            //{
            //    UserControlProductDetail un = new UserControlProductDetail();
            //    un.Dock = DockStyle.Fill;
            //    Form_User.Instance.PnlContainer.Controls.Add(un);
            //}
            //Form_User.Instance.PnlContainer.Controls["UserControlProductDetail"].BringToFront();
            //Form_User.Instance.BackButton.Visible = true;
            //Form1 form = new Form1();

            //form.ShowDialog();
            //form.Close();
        }
    }
}
