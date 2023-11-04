using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_XuatKhauGao.DTO
{
    public class HinhThucThanhToan
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public HinhThucThanhToan(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
