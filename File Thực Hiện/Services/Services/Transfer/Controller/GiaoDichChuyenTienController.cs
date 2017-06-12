using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Transfer.Model;

namespace Transfer.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GiaoDichChuyenTienController : ApiController
    {
        private DataContext db = new DataContext();
        /// <summary>
        /// Hàm api lấy tất cả giao dịch chuyển tiền
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichChuyenTien> LayTatCaGiaoDich()
        {
            try
            {
                return db.GiaoDichChuyenTiens;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy giao dịch chuyển tiền theo mã giao dịch
        /// </summary>
        /// <param name="maGD"></param>
        /// <returns></returns>
        [HttpGet]
        public GiaoDichChuyenTien LayGiaoDichTheoMaGD(string maGD)
        {
            try
            {
                return db.GiaoDichChuyenTiens.Where(a => a.MaGD == maGD).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy các giao dịch chuyển tiền theo từ khóa
        /// </summary>
        /// <param name="tuKhoa">từ khóa</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichChuyenTien> LayGiaoDichTheoTuKhoa(string tuKhoa)
        {
            try
            {
                return db.GiaoDichChuyenTiens.Where(a =>
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
        /// Hàm api lấy các giao dịch chuyển tiền theo khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">ngày bắt đầu</param>
        /// <param name="denNgay">ngày kết thúc</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichChuyenTien> LayGiaoDichTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return db.GiaoDichChuyenTiens.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api thêm một giao dịch chuyển tiền
        /// </summary>
        /// <param name="gd">giao dịch chuyển tiền</param>
        /// <returns></returns>
        [HttpPut]
        public GiaoDichChuyenTien ThemGiaoDich(GiaoDichChuyenTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    gd.MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.ChuyenTien, DateTime.Now);
                    gd.TrangThai = TrangThaiGiaoDich.DangXuLy;
                    gd.NgayTao = DateTime.Now;

                    db.GiaoDichChuyenTiens.Add(gd);
                    db.SaveChanges();
                    return gd;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api hủy một giao dịch chuyển tiền
        /// </summary>
        /// <param name="gd">giao dịch chuyển tiền</param>
        /// <returns></returns>
        [HttpPost]
        public GiaoDichChuyenTien HuyGiaoDich(GiaoDichChuyenTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    var giaoDich = db.GiaoDichChuyenTiens.Where(a => a.MaGD == gd.MaGD).FirstOrDefault();
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
                    var count = db.GiaoDichChuyenTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();
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
                    var count = db.GiaoDichChuyenTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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
                    var count = db.GiaoDichChuyenTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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
