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
    
    public partial class SanPham
    {
        public int id { get; set; }
        public int DanhMuc_id { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        public Nullable<int> soluong { get; set; }
        public Nullable<double> trongluong { get; set; }
        public double gia { get; set; }
        public string hinhanh { get; set; }
        public Nullable<System.DateTime> ngaytao { get; set; }
        public Nullable<System.DateTime> ngaysua { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
    }
}