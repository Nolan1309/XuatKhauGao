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

namespace QL_XuatKhauGao.UserControls
{
    public partial class UserControlCustomer : UserControl
    {

        DataProvider db = new DataProvider();
        public UserControlCustomer()
        {
            InitializeComponent();
        }
    }
}
