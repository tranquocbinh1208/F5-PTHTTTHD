using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recharge.Model
{
    public class GiaoDichGuiTien
    {
        [Key]
        [Required]
        public String MaGD { get; set; }
        [Required]
        public string HoTenNguoiGoi { get; set; }
        [Required]
        public string CMND { get; set; }
        [Required]
        public DateTime NgayCapCMND { get; set; }
        [Required]
        public string NoiCapCMND { get; set; }
        [Required]
        public string Diachi { get; set; }
        public string SDT { get; set; }
        [Required]
        public decimal SoTien { get; set; }
        [Required]
        public string NoiDung { get; set; }
        [Required]
        public string MaKHNhan { get; set; }
        [Required]
        public string MaNV { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        [Required]
        public TrangThaiGiaoDich TrangThai { get; set; }
    }
}