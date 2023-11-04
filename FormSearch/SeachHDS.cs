using QL_XuatKhauGao.Helpers;
using QL_XuatKhauGao.UserControls.User.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_XuatKhauGao
{
    public partial class SeachHDS : Form
    {
        public SeachHDS()
        {
            InitializeComponent();
            SearchHD control = new SearchHD(showSearchPanel);
            MainControlClass.showControl(control, showSearchPanel);
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            SearchHD control = new SearchHD(showSearchPanel);
            MainControlClass.showControl(control, showSearchPanel);
        }
    }
}
