using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model
{
    public class KhachHangTheoNgay
    {
        public DateTime Ngay { get; set; }
        public int Count { get; set; }
    }

    public class KhachHangTheoThang
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int Count { get; set; }
    }

    public class KhachHangTheoNam
    {
        public int Nam { get; set; }
        public int Count { get; set; }
    }
}
