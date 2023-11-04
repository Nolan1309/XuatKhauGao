using QL_XuatKhauGao.DTO;
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_XuatKhauGao.UserControls.Admin
{
    public partial class OrderSanPham : Form
    {
        //Control content;
        public static List<SanPham> addlist = new List<SanPham>();
        List<SanPham> listorder = new List<SanPham>();
        SanPham sp;
        public OrderSanPham()
        {
            InitializeComponent();
        }
        public OrderSanPham(SanPham sp, List<SanPham> list)
        {
            InitializeComponent();
            this.sp = sp;
            this.listorder = list;
        }
        public void ClearAllLists()
        {
            addlist.Clear();
            listorder.Clear();

        }

        private void OrderSanPham_Load(object sender, EventArgs e)
        {
            btn_de.Enabled = false;
            pictureBox1.Image = ConvertStringToBitmap.convertToBitmap(sp.hinhanh);
            lb_name.Text = sp.TenSanPham;
            lb_price.Text = "Giá: đ " + sp.Gia.ToString();
            lb_quantity.Text = "Hàng còn sẵn: " + sp.Soluong.ToString();
            lb_desc.Text = "Mô tả: " + sp.MoTa;
        }

        private void btn_de_Click_1(object sender, EventArgs e)
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

        private void btn_in_Click_1(object sender, EventArgs e)
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

        private void uiButton1_Click(object sender, EventArgs e)
        {
            sp.Soluong = Convert.ToInt32(tb_value.Text);
            RenCart shopping = new RenCart();
            shopping.ThemSanPham(sp);
            addlist = shopping.LayDanhSachSanPham();
            this.Close();
        }
        public List<SanPham> returnds()
        {
            return addlist;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            sp.Soluong = Convert.ToInt32(tb_value.Text);

            RenCart shopping = new RenCart();
            shopping.ThemSanPham(sp);

            OrderBill form_order = new OrderBill(shopping.LayDanhSachSanPham(), listorder);
            this.Visible = false;
            form_order.FormClosed += (s, args) => { this.Visible = true;
                this.ClearAllLists();
            };
            form_order.ShowDialog();

        }
    }
}
