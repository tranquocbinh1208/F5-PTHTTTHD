using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CreateSaveAccount.Model
{
    public class GiaoDichLapSoTietKiem
    {
        [Key]
        [Required]
        public string MaGD { get; set; }
        [Required]
        public string MaKH { get; set; }
        [Required]
        public decimal SoTien { get; set; }
        [Required]
        public float LaiSuat { get; set; }
        [Required]
        public int KyHan { get; set; }
        [Required]
        public string MaNV { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public TrangThaiGiaoDich TrangThai { get; set; }
    }
}
