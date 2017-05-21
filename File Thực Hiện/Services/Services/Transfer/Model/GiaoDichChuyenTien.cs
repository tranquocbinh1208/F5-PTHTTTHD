using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Transfer.Model
{
    public class GiaoDichChuyenTien
    {
        [Key]
        [Required]
        public string MaGD { get; set; }
        [Required]
        public string MaKHGui { get; set; }
        [Required]
        public string MaKHNhan { get; set; }
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
