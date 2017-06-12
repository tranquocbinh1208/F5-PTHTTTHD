using Common;
using Recharge.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Recharge.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GiaoDichGuiTienController : ApiController
    {
        private DataContext db = new DataContext();
        /// <summary>
        /// Hàm api lấy tất cả giao dịch gửi tiền
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayTatCaGiaoDich()
        {
            try
            {
                return db.GiaoDichGuiTiens;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy một giao dịch gửi tiền theo mã giao dịch
        /// </summary>
        /// <param name="maGD">mã giao dịch</param>
        /// <returns></returns>
        [HttpGet]
        public GiaoDichGuiTien LayGiaoDichTheoMaGD(string maGD)
        {
            try
            {
                return db.GiaoDichGuiTiens.Where(a => a.MaGD == maGD).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy các giao dịch gửi tiền theo một từ khóa
        /// </summary>
        /// <param name="tuKhoa">từ khóa</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayGiaoDichTheoTuKhoa(string tuKhoa)
        {
            try
            {
                return db.GiaoDichGuiTiens.Where(a =>
                    (a.HoTenNguoiGoi + a.CMND + a.SDT + a.Diachi + a.SoTien + a.NoiDung)
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
        public IEnumerable<GiaoDichGuiTien> LayGiaoDichTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return db.GiaoDichGuiTiens.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api thêm một giao dịch gửi tiền
        /// </summary>
        /// <param name="gd">giao dịch gửi tiền</param>
        /// <returns></returns>
        [HttpPut]
        public GiaoDichGuiTien ThemGiaoDich(GiaoDichGuiTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    gd.MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.GuiTien, DateTime.Now);
                    gd.TrangThai = TrangThaiGiaoDich.DangXuLy;
                    gd.NgayTao = DateTime.Now;

                    db.GiaoDichGuiTiens.Add(gd);
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
        /// Hàm api hủy một giao dịch gửi tiền
        /// </summary>
        /// <param name="gd">giao dịch gửi tiền</param>
        /// <returns></returns>
        [HttpPost]
        public GiaoDichGuiTien HuyGiaoDich(GiaoDichGuiTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    var giaoDich = db.GiaoDichGuiTiens.Where(a => a.MaGD == gd.MaGD).FirstOrDefault();
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
                    var count = db.GiaoDichGuiTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();
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
                    var count = db.GiaoDichGuiTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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
                    var count = db.GiaoDichGuiTiens.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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