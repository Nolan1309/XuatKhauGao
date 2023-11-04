using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_XuatKhauGao.Models;

namespace QL_XuatKhauGao.UserControls.User
{
    public partial class LoadAccountINFO : UserControl
    {
        Dangnhap user;
        public LoadAccountINFO()
        {
            InitializeComponent();
        }
        public LoadAccountINFO(Dangnhap user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void LoadAccountINFO_Load(object sender, EventArgs e)
        {
            uiTextBox1.Enabled = false;
            uiTextBox2.Enabled = false;
            uiTextBox3.Enabled = false;

        }
    }
}
