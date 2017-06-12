using Customer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Common;

namespace Customer.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class KhachHangController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpGet]
        public IEnumerable<KhachHang> LayTatCaKhachHang()
        {
            try
            {
                return db.KhachHangs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public KhachHang LayKhachHangTheoMaKH(string maKH)
        {
            try
            {
                return db.KhachHangs.Where(a => a.MaKH == maKH).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public KhachHang LayKhachHangTheoCMND(string CMND)
        {
            try
            {
                return db.KhachHangs.Where(a => a.CMND == CMND).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public KhachHang[] LayKhachHangTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return db.KhachHangs.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public List<ThongKeTheoNgay> ThongKeKhachHangTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeTheoNgay>();
            try
            {
                var currentDate = tuNgay;
                while (currentDate <= denNgay)
                {
                    var count = db.KhachHangs.Where(a => a.NgayTao.Date == currentDate.Date).Count();
                    var item = new ThongKeTheoNgay
                    {
                        Ngay = currentDate,
                        Count = count
                    };
                    list.Add(item);
                    currentDate = currentDate.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        [HttpGet]
        public List<ThongKeTheoThang> ThongKeKhachHangTheoThang(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeTheoThang>();
            var currentDate = tuNgay;
            try
            {
                while (currentDate <= denNgay)
                {
                    var count = db.KhachHangs.Where(a => a.NgayTao.Date == currentDate.Date).Count();

                    var item = list.Where(a => a.Thang == currentDate.Month && a.Nam == currentDate.Year).FirstOrDefault();
                    if (item == null)
                    {
                        item = new ThongKeTheoThang
                        {
                            Nam = currentDate.Year,
                            Thang = currentDate.Month,
                            Count = count
                        };
                        list.Add(item);
                    }
                    else
                    {
                        item.Count += count;
                    }

                    currentDate = currentDate.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        [HttpGet]
        public List<ThongKeTheoNam> ThongKeKhachHangTheoNam(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeTheoNam>();
            var currentDate = tuNgay;
            try
            {
                while (currentDate <= denNgay)
                {
                    var count = db.KhachHangs.Where(a => a.NgayTao.Date == currentDate.Date).Count();

                    var item = list.Where(a => a.Nam == currentDate.Year).FirstOrDefault();
                    if (item == null)
                    {
                        item = new ThongKeTheoNam
                        {
                            Nam = currentDate.Year,
                            Count = count
                        };
                        list.Add(item);
                    }
                    else
                    {
                        item.Count += count;
                    }

                    currentDate = currentDate.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }
    }
}