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
using QL_XuatKhauGao.UserControls;
using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.UserControls.User;
using QL_XuatKhauGao.UserControls.Admin;

namespace QL_XuatKhauGao
{
    public partial class Form_User : Form
    {
        public Dangnhap user;
        //public List<SanPham> dscart = new List<SanPham>();
        static Form_User userproduct;
        public static Form_User Instance
        {
            get
            {
                if (userproduct == null)
                {
                    userproduct = new Form_User();
                }
                return userproduct;
            }
        }
        public Form_User()
        {
            InitializeComponent();
            //UserControlProduct_u control = new UserControlProduct_u();
            //control.ProductAddedToCart += HandleProductAddedToCart;
        }
        //private void HandleProductAddedToCart(SanPham product)
        //{
        //    // Thêm sản phẩm vào danh sách giỏ hàng (dscart)
        //    dscart.Add(product);
        //}
        //public Form_User(List<SanPham> sp)
        //{
        //    InitializeComponent();
        //    this.dscart = sp;
        //}
        public Form_User(Dangnhap user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            btn_getInfo.Text = user.tendangnhap;
            UserControlProduct_u control = new UserControlProduct_u(container_pd);
            MainControlClass.showControl(control, container_pd);
        }



        private void btn_logout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = "";
            Properties.Settings.Default.password = "";
            Properties.Settings.Default.Save();

            Form_Login form_login = new Form_Login();
            this.Hide();
            form_login.ShowDialog();
            this.Close();
        }

        private void btn_getInfo_Click(object sender, EventArgs e)
        {
            if (user.Idphanquyen == 2)
            {
                //UserControlLGInfo control = new UserControlLGInfo(user);
                LoadAccountINFO control1 = new LoadAccountINFO(user);
                MainControlClass.showControl(control1, container_pd);
                //MainControlClass.showControl(control, container_pd);
            }
            else
            {
                UserControlLGInfo control = new UserControlLGInfo(user);
                MainControlClass.showControl(control, container_pd);
            }

        }

        public Sunny.UI.UISymbolButton BackButton
        {
            get { return btnBack; }
            set { btnBack = value; }
        }

        public Panel PnlContainer
        {
            get { return container_pd; }
            set { container_pd = value; }
        }
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            UserControlProduct_u control = new UserControlProduct_u(container_pd);

            MainControlClass.showControl(control, container_pd);
        }

        private void uiNavMenu1_MenuItemClick(TreeNode node, Sunny.UI.NavMenuItem item, int pageIndex)
        {

        }

        private void uiSymbolButton8_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            //if(dscart != null)
            //{
            //    OrderBill form_order = new OrderBill(dscart);
            //    this.Visible = false;
            //    form_order.FormClosed += (s, args) => {
            //        this.Visible = true;
            //        dscart.Clear();
            //    };
            //    form_order.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Thông báo", "Không có đơn hàng!");
            //}
        }
    }
}
