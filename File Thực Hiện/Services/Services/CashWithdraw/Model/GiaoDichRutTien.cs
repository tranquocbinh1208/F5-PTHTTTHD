using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CashWithdraw.Model
{
    public class GiaoDichRutTien
    {
        [Key]
        [Required]
        public string MaGD { get; set; }
        [Required]
        public string MaKH { get; set; }
        [Required]
        public decimal SoTien { get; set; }
        [Required]
        public string NoiDung { get; set; }
        [Required]
        public string MaNV { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public TrangThaiGiaoDich TrangThai { get; set; }
    }
}
