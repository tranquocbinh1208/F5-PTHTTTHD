//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SoTietKiem
    {
        public string MaSoTietKiem { get; set; }
        public string MaKH { get; set; }
        public decimal SoTienGoi { get; set; }
        public int KyHan { get; set; }
        public double LaiSuat { get; set; }
        public System.DateTime NgayGoi { get; set; }
        public System.DateTime NgayDaoHan { get; set; }
        public int TrangThai { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}
