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
    
    public partial class VanChuyen
    {
        public int id { get; set; }
        public int idHoaDon { get; set; }
        public Nullable<System.DateTime> ngayVanChuyen { get; set; }
        public string diaDiemXuatPhat { get; set; }
        public string diaDiemDen { get; set; }
        public Nullable<int> idQuocGia { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual QuocGia QuocGia { get; set; }
    }
}
