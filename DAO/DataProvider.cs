using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_XuatKhauGao.Models
{
    public class DataProvider
    {
        string sqlconnect;
        public DataProvider()
        {
            sqlconnect = "Data Source=DESKTOP-MEUMH4V;Initial Catalog=Final_XuatKhauGao;Integrated Security=True";
        }
        public SqlConnection sqlConnection()
        {
            return new SqlConnection(sqlconnect);
        }
    }
}
