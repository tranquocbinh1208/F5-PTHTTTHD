using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Model
{
    public enum TrangThaiGiaoDich
    {
        DangXuLy = 0,
        ThanhCong = 1,
        ThatBai = 2,
        Huy = 3
    }

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
