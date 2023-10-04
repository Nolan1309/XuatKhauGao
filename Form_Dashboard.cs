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


using QL_XuatKhauGao.UserControls ;

using QL_XuatKhauGao.Helpers;
namespace QL_XuatKhauGao
{
    public partial class Form_Dashboard : Sunny.UI.UIForm
    {
        DangNhap user;
        /*        UserControlCreateProduct controlCreate;
                UserControlListProduct controlList;*/

       /* private Boolean showPanelPro = false;*/
        public Form_Dashboard()
        {
            InitializeComponent();
        }
        public Form_Dashboard(DangNhap _user)
        {
            InitializeComponent();
            this.user = _user;
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            btn_getInfo.Text = user.email;
            UserControlMain control = new UserControlMain();
            MainControlClass.showControl(control, container_pd);
            /*controlCreate = new UserControlCreateProduct();
            controlList = new UserControlListProduct();*/
        }


       /* private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            showPanelPro = !showPanelPro;
            tooglePanel();
        }
        private void tooglePanel()
        {
            if (showPanelPro)
                panel_pro.Height = 272;
            else
                panel_pro.Height = 0;
        }
*/
        private void uiSymbolButton8_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = "";
            Properties.Settings.Default.password = "";
            Properties.Settings.Default.Save();

            Form_Login form_login = new Form_Login();
            this.Hide();
            form_login.ShowDialog();
            this.Close();
        }
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            UserControlListProduct control = new UserControlListProduct(container_pd);
            MainControlClass.showControl(control, container_pd);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            UserControlMain control = new UserControlMain();
            MainControlClass.showControl(control, container_pd);
        }

        private void uiSymbolButton7_Click(object sender, EventArgs e)
        {
            UserControlCustomer control = new UserControlCustomer();
            MainControlClass.showControl(control, container_pd);
        }

        private void uiSymbolButton8_Click_1(object sender, EventArgs e)
        {
            UserControlOrder control = new UserControlOrder();
            MainControlClass.showControl(control, container_pd);
        }

        private void btn_getInfo_Click(object sender, EventArgs e)
        {
            UserControlLGInfo control = new UserControlLGInfo(user);
            MainControlClass.showControl(control, container_pd);
        }
    }
}
