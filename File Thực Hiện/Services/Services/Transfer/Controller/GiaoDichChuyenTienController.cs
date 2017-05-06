using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Transfer.Model;

namespace Transfer.Controller
{
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
        public IEnumerable<GiaoDichChuyenTien> LayGiaoDichTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                return db.GiaoDichChuyenTiens.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);
            }
            catch (Exception)
            {
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
                    gd.MaGD = AppUtils.GetTransactionID(DateTime.Now);
                    gd.TrangThai = TrangThaiGiaoDich.DangXuLy;

                    db.GiaoDichChuyenTiens.Add(gd);
                    db.SaveChanges();
                    return gd;
                }
            }
            catch (Exception)
            {
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
            catch (Exception)
            {
            }
            return null;
        }
    }
}
