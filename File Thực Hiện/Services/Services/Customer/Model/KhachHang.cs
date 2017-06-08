using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Model
{
    public class KhachHang
    {
        [Key]
        [Required]
        public string MaKH { get; set; }
        [Required]
        public string HoTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public bool GioiTinh { get; set; }
        [Required]
        public string SDT { get; set; }
        [Required]
        public string CMND { get; set; }
        [Required]
        public DateTime NgayCapCMND { get; set; }
        [Required]
        public string NoiCapCMND { get; set; }
        [Required]
        public string DiaChi { get; set; }
        public string Email { get; set; }
        [Required]
        public string HinhChuKy { get; set; }
        [Required]
        public string MaNV { get; set; }
        [Required]
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        [Required]
        public TrangThaiKhachHang TrangThai { get; set; }
    }
}
