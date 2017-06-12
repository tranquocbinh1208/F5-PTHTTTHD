using Common;
using CreateSaveAccount.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CreateSaveAccount.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GiaoDichLapSoTietKiemController : ApiController
    {
        private DataContext db = new DataContext();
        /// <summary>
        /// Hàm api lấy tất cả giao dịch lập sổ tiết kiệm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichLapSoTietKiem> LayTatCaGiaoDich()
        {
            try
            {
                return db.GiaoDichLapSoTietKiems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy giao dịch lập sổ tiết kiệm theo mã giao dịch
        /// </summary>
        /// <param name="maGD"></param>
        /// <returns></returns>
        [HttpGet]
        public GiaoDichLapSoTietKiem LayGiaoDichTheoMaGD(string maGD)
        {
            try
            {
                return db.GiaoDichLapSoTietKiems.Where(a => a.MaGD == maGD).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api lấy các giao dịch lập sổ tiết kiệm theo từ khóa
        /// </summary>
        /// <param name="tuKhoa">từ khóa</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichLapSoTietKiem> LayGiaoDichTheoTuKhoa(string tuKhoa)
        {
            try
            {
                return db.GiaoDichLapSoTietKiems.Where(a =>
                    (a.SoTien + a.NgayTao.ToString(AppUtils.DateFormat_yyyy_mm_dd_hh_mm_ss))
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
        /// Hàm api lấy các giao dịch lập sổ tiết kiệm theo khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">ngày bắt đầu</param>
        /// <param name="denNgay">ngày kết thúc</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GiaoDichLapSoTietKiem> LayGiaoDichTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return db.GiaoDichLapSoTietKiems.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Hàm api thêm một giao dịch lập sổ tiết kiệm
        /// </summary>
        /// <param name="gd">giao dịch lập sổ tiết kiệm</param>
        /// <returns></returns>
        [HttpPut]
        public GiaoDichLapSoTietKiem ThemGiaoDich(GiaoDichLapSoTietKiem gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    gd.MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.ChuyenTien, DateTime.Now);
                    gd.TrangThai = TrangThaiGiaoDich.DangXuLy;
                    gd.NgayTao = DateTime.Now;

                    db.GiaoDichLapSoTietKiems.Add(gd);
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
        /// Hàm api hủy một giao dịch lập sổ tiết kiệm
        /// </summary>
        /// <param name="gd">giao dịch lập sổ tiết kiệm</param>
        /// <returns></returns>
        [HttpPost]
        public GiaoDichLapSoTietKiem HuyGiaoDich(GiaoDichLapSoTietKiem gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    var giaoDich = db.GiaoDichLapSoTietKiems.Where(a => a.MaGD == gd.MaGD).FirstOrDefault();
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
                    var count = db.GiaoDichLapSoTietKiems.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();
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
                    var count = db.GiaoDichLapSoTietKiems.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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
                    var count = db.GiaoDichLapSoTietKiems.Where(a => DbFunctions.TruncateTime(a.NgayTao) == currentDate.Date).Count();

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
