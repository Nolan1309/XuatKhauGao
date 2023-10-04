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

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlProduct_u : Sunny.UI.UIUserControl
    {

        Control Content;

        public UserControlProduct_u()
        {
            InitializeComponent();
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
            Panel panel_container = new Panel();
            panel_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            panel_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panel_container.Margin = new System.Windows.Forms.Padding(8);
            panel_container.Padding = new System.Windows.Forms.Padding(8);
            panel_container.Size = new System.Drawing.Size(155, 214);

            //Panel Top
            Panel panel_containerTop = new Panel();
            panel_containerTop.Dock = System.Windows.Forms.DockStyle.Top;
            panel_containerTop.Size = new System.Drawing.Size(139, 67);

            PictureBox pic = new PictureBox();
            pic.Dock = System.Windows.Forms.DockStyle.Fill;
            pic.Image = ConvertStringToBitmap.convertToBitmap(sp.hinhanh);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.TabStop = false;
            panel_containerTop.Controls.Add(pic);
            panel_container.Controls.Add(panel_containerTop);

            //Panel Bottom
            Panel panel_containerBottom = new Panel();
            panel_containerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_containerBottom.Size = new System.Drawing.Size(139, 38);

            Button btn = new Button();
            btn.AutoSize = true;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            btn.Dock = System.Windows.Forms.DockStyle.Fill;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Text = "Mua";
            btn.Name = sp.id.ToString();
            btn.Click += new System.EventHandler(button_Click);

            btn.UseVisualStyleBackColor = false;
            panel_containerBottom.Controls.Add(btn);
            panel_container.Controls.Add(panel_containerBottom);



            //Panel Center
            Panel panel_containerCenter = new Panel();
            panel_containerCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            /*panel_containerCenter.BackColor = System.Drawing.Color.Red;*/

            /*Panel panel_containerCenterBot = new Panel();
            panel_containerCenterBot.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_containerCenterBot.BackColor = System.Drawing.Color.Blue;

            panel_containerCenter.Controls.Add(panel_containerCenterBot);


            Panel panel_containerCenterTop = new Panel();
            panel_containerCenterTop.Dock = System.Windows.Forms.DockStyle.Top;
            panel_containerCenterTop.BackColor = System.Drawing.Color.Red;

            panel_containerCenter.Controls.Add(panel_containerCenterTop);
*/

            Label lb_price = new Label();
            lb_price.Text = sp.gia.ToString();
            lb_price.AutoSize = true;
            panel_containerCenter.Controls.Add(lb_price);

            panel_containerCenter.Controls.Add(lb_price);
            panel_container.Controls.Add(panel_containerCenter);


            
            // add control
            flowLayoutPanel3.Controls.Add(panel_container);
        }

        private void UserControlProduct_u_Load(object sender, EventArgs e)
        {
            DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            List<SanPham> dsSP = db.SanPhams.ToList();
            InitCart(dsSP);

        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DB_QLXuatKhauGaoEntities db = new DB_QLXuatKhauGaoEntities();
            int id = int.Parse(btn.Name);
            SanPham sp = db.SanPhams.Where(item => item.id == id).FirstOrDefault();

            UserControlProductDetail control = new UserControlProductDetail(sp);
            MainControlClass.showControl(control, Content);
        }


    }
}
