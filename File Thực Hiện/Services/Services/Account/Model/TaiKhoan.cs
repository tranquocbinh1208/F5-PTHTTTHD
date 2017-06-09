using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Model
{
    public class TaiKhoan
    {
        [Key]
        [Required]
        public string MaSoTaiKhoan { get; set; }
        [Required]
        public string MaKH { get; set; }
        [Required]
        public decimal SoDuThuc { get; set; }
        [Required]
        public decimal SoDuKhaDung { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public DateTime NgayHetHan { get; set; }
        [Required]
        public TrangThaiTaiKhoan TrangThai { get; set; }
    }
}