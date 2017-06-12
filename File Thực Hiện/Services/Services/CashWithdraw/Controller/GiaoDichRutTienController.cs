using CashWithdraw.Model;
using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CashWithdraw.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GiaoDichRutTienController : ApiController
    {
        private DataContext db = new DataContext();
        /// <summary>
        /// Hàm api lấy tất cả giao dịch rút tiền
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichRutTien> LayTatCaGiaoDich()
        {
            try
            {
                return db.GiaoDichRutTiens;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy một giao dịch rút tiền theo mã giao dịch
        /// </summary>
        /// <param name="maGD">mã giao dịch</param>
        /// <returns></returns>
        [HttpGet]
        public GiaoDichRutTien LayGiaoDichTheoMaGD(string maGD)
        {
            try
            {
                return db.GiaoDichRutTiens.Where(a => a.MaGD == maGD).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy các giao dịch rút tiền theo một từ khóa
        /// </summary>
        /// <param name="tuKhoa">từ khóa</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichRutTien> LayGiaoDichTheoTuKhoa(string tuKhoa)
        {
            try
            {
                return db.GiaoDichRutTiens.Where(a =>
                    (a.SoTien + a.NoiDung)
                    .ToLower()
                    .Contains((tuKhoa ?? string.Empty).ToLower())
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy các giao dịch theo một khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">ngày bắt đầu</param>
        /// <param name="denNgay">ngày kết thúc</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichRutTien> LayGiaoDichTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return db.GiaoDichRutTiens.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api thêm một giao dịch rút tiền
        /// </summary>
        /// <param name="gd">giao dịch rút tiền</param>
        /// <returns></returns>
        [HttpPut]
        public GiaoDichRutTien ThemGiaoDich(GiaoDichRutTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    gd.MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.RutTien, DateTime.Now);
                    gd.TrangThai = TrangThaiGiaoDich.DangXuLy;
                    gd.NgayTao = DateTime.Now;

                    db.GiaoDichRutTiens.Add(gd);
                    db.SaveChanges();
                    return gd;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api hủy một giao dịch rút tiền
        /// </summary>
        /// <param name="gd">giao dịch rút tiền</param>
        /// <returns></returns>
        [HttpPost]
        public GiaoDichRutTien HuyGiaoDich(GiaoDichRutTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    var giaoDich = db.GiaoDichRutTiens.Where(a => a.MaGD == gd.MaGD).FirstOrDefault();
                    if (giaoDich != null)
                    {
                        giaoDich.TrangThai = TrangThaiGiaoDich.Huy;
                        db.SaveChanges();
                        return gd;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public List<ThongKeTheoNgay> ThongKeGiaoDichTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeTheoNgay>();
            try
            {
                var currentDate = tuNgay;
                while (currentDate <= denNgay)
                {
                    var count = db.GiaoDichRutTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();
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
        public List<ThongKeTheoThang> ThongKeGiaoDichTheoThang(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeTheoThang>();
            var currentDate = tuNgay;
            try
            {
                while (currentDate <= denNgay)
                {
                    var count = db.GiaoDichRutTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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
        public List<ThongKeTheoNam> ThongKeGiaoDichTheoNam(DateTime tuNgay, DateTime denNgay)
        {
            var list = new List<ThongKeTheoNam>();
            var currentDate = tuNgay;
            try
            {
                while (currentDate <= denNgay)
                {
                    var count = db.GiaoDichRutTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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