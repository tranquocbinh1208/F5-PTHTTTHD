using Common;
using System;

namespace Account.Model
{
    public class TaiKhoan
    {
        public string MaSoTaiKhoan { get; set; }
        public string MaKH { get; set; }
        public decimal SoDuThuc { get; set; }
        public decimal SoDuKhaDung { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }
        public TrangThaiTaiKhoan TrangThai { get; set; }
    }
}