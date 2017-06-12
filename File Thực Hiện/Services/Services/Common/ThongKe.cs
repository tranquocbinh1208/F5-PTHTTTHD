using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ThongKeTheoNgay
    {
        public DateTime Ngay { get; set; }
        public int Count { get; set; }
    }

    public class ThongKeTheoThang
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int Count { get; set; }
    }

    public class ThongKeTheoNam
    {
        public int Nam { get; set; }
        public int Count { get; set; }
    }
}
