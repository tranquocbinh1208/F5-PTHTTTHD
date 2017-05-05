using Recharge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Recharge.Controller
{
    public class GiaoDichGuiTienController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayTatCaGiaoDich()
        {
            try
            {
                return db.GiaoDichGuiTiens;
            }
            catch (Exception)
            {
            }
            return null;
        }
        [HttpGet]
        public GiaoDichGuiTien LayGiaoDichTheoMaGD(string maGD)
        {
            try
            {
                if (!string.IsNullOrEmpty(maGD))
                    return db.GiaoDichGuiTiens.Where(a => a.MaGD == maGD).FirstOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
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
            catch (Exception)
            {
            }
            return null;
        }
        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayGiaoDichTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                if (tuNgay != null && denNgay != null)
                    return db.GiaoDichGuiTiens.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);
            }
            catch (Exception)
            {
            }
            return null;
        }
        [HttpPut]
        public GiaoDichGuiTien ThemGiaoDich(GiaoDichGuiTien gd)
        {
            try
            {
                if (ModelState.IsValid && gd != null)
                {
                    gd.MaGD = AppUtils.GetTransactionID(DateTime.Now);
                    gd.TrangThai = TrangThaiGiaoDich.DangXuLy;

                    db.GiaoDichGuiTiens.Add(gd);
                    db.SaveChanges();
                    return gd;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
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
            catch (Exception)
            {
            }
            return null;
        }
    }
}