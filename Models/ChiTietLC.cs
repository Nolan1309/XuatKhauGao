//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_XuatKhauGao.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietLC
    {
        public int id { get; set; }
        public int idHoaDon { get; set; }
        public string soLC { get; set; }
        public System.DateTime ngayMo_LC { get; set; }
        public Nullable<System.DateTime> ngayDong_LC { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
    }
}
