using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_XuatKhauGao.Models;
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.UserControls.Admin;

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlProductDetail : UserControl
    {
      
       
        List<SanPham> listorder = new List<SanPham>();
        public SanPham sp;
        public UserControlProductDetail()
        {
            InitializeComponent();
        }
        public UserControlProductDetail(SanPham sp)
        {
            InitializeComponent();
            this.sp = sp;
        }

     
        private void UserControlProductDetail_Load(object sender, EventArgs e)
        {
            btn_de.Enabled = false;
            pictureBox1.Image = ConvertStringToBitmap.convertToBitmap(sp.hinhanh);
            lb_name.Text = sp.TenSanPham;
            lb_price.Text = "Giá: đ " + sp.Gia.ToString();
            lb_quantity.Text = "Hàng còn sẵn: " + sp.Soluong.ToString();
            lb_desc.Text = "Mô tả: " + sp.MoTa;
        }


        private void btn_de_Click(object sender, EventArgs e)
        {
            int value = int.Parse(tb_value.Text);
            if (value <= sp.Soluong)
            {
                btn_in.Enabled = true;
                if (value <= 2)
                {
                    btn_de.Enabled = false;
                }
                else
                {
                    btn_de.Enabled = true;
                }
            }
            tb_value.Text = (int.Parse(tb_value.Text) - 1).ToString();

        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            int value = int.Parse(tb_value.Text);
            if (value >= 1)
            {
                btn_de.Enabled = true;
                if (value >= sp.Soluong - 1)
                {
                    btn_in.Enabled = false;
                }
                else
                {
                    btn_in.Enabled = true;

                }
            }
            tb_value.Text = (int.Parse(tb_value.Text) + 1).ToString();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            sp.Soluong = Convert.ToInt32(tb_value.Text);
            //OrderBill form_order = new OrderBill(new List<SanPham>(){
            //    sp
            //});
            //form_order.ShowDialog();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            //sp.Soluong = Convert.ToInt32(tb_value.Text);
            //listorder.Add(sp);
            ////UserControlProduct_u userControlProduct_U = new UserControlProduct_u(listorder);
            ////userControlProduct_U.Show();
            ////this.Controls.Clear();
            //UserControlProduct_u control = new UserControlProduct_u(listorder,Form_User.Instance.PnlContainer);
            ////MainControlClass.showControl(control, Form_User.Instance.PnlContainer);
            ////if (!Form1.Instance.PnlContainer.Controls.ContainsKey("UCNext"))
            ////{
            ////    UCNext un = new UCNext();
            ////    un.Dock = DockStyle.Fill;
            ////    Form1.Instance.PnlContainer.Controls.Add(un);
            ////}
            //control.Show();
            //control.Dock = DockStyle.Fill;
            //control.BringToFront();
            //control.Focus();
            //Form_User.Instance.PnlContainer.Controls.Add(control);
            //Form_User.Instance.PnlContainer.Controls["UserControlProduct_u"].BringToFront();
            //content.Controls.Clear();
            //control.Dock = DockStyle.Fill;

            //content.Controls.Add(control);
        }
    }
}
