using QL_XuatKhauGao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_XuatKhauGao.DTO
{
    public class RenCart
    {
        private List<SanPham> gioHang = new List<SanPham>();

        public void ThemSanPham(SanPham sp)
        {
            gioHang.Add(sp);
        }
        public RenCart()
        {

        }
        public List<SanPham> LayDanhSachSanPham()
        {
            return gioHang;
        }
    
    }
}
