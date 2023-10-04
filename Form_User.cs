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


namespace QL_XuatKhauGao
{
    public partial class Form_User : Sunny.UI.UIForm
    {
        private DangNhap user;

        
        public Form_User()
        {
            InitializeComponent();
        }
        public Form_User(DangNhap user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            btn_getInfo.Text = user.email;
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
            UserControlLGInfo control = new UserControlLGInfo(user);
            MainControlClass.showControl(control, container_pd);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            UserControlProduct_u control = new UserControlProduct_u(container_pd);
            MainControlClass.showControl(control, container_pd);
        }
    }
}
