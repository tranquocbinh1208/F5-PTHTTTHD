using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSaveAccount.Model
{
    public class GiaoDichLapSoTietKiem
    {
        public string MaGD { get; set; }
        public string MaKH { get; set; }
        public decimal SoTien { get; set; }
        public float LaiSuat { get; set; }
        public int KyHan { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayTao { get; set; }
        public TrangThaiGiaoDich TrangThai { get; set; }
    }
}
