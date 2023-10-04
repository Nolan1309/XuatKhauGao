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

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlProductDetail : UserControl
    {
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
            lb_name.Text = sp.ten;
            lb_price.Text = sp.gia.ToString();
            lb_quantity.Text = "Hàng còn sẵn: " + sp.soluong.ToString();
            lb_desc.Text = sp.mota;
        }

       

        private void btn_de_Click(object sender, EventArgs e)
        {
            int value = int.Parse(tb_value.Text);
            if(value <= sp.soluong)
            {
                btn_in.Enabled = true;
                if(value <= 2)
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
            if(value >= 1)
            {
                btn_de.Enabled = true;
                if (value >= sp.soluong - 1)
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
    }
}
