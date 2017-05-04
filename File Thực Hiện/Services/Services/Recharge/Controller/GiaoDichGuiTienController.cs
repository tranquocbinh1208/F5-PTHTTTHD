using Recharge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Recharge.Controller
{
    public class GiaoDichGuiTienController : ApiController
    {
        public static List<GiaoDichGuiTien> GiaoDichs = new List<GiaoDichGuiTien>();

        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayTatCaGiaoDich()
        {
            return GiaoDichs;
        }
        [HttpGet]
        public GiaoDichGuiTien LayGiaoDichTheoMaGD(string maGD)
        {
            if (!string.IsNullOrEmpty(maGD))
                return GiaoDichs.Find(a => a.MaGD == maGD);

            return null;
        }
        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayGiaoDichTheoTuKhoa(string tuKhoa)
        {
            return GiaoDichs.Where(a =>
                (a.HoTenNguoiGoi + a.CMND + a.SDT + a.Diachi + a.SoTien + a.NoiDung)
                .ToLower()
                .Contains((tuKhoa ?? string.Empty).ToLower())
            );
        }
        [HttpGet]
        public IEnumerable<GiaoDichGuiTien> LayGiaoDichTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay != null && denNgay != null)
                return GiaoDichs.Where(a => a.NgayTao >= tuNgay && a.NgayTao <= denNgay);

            return null;
        }
        [HttpPut]
        public GiaoDichGuiTien ThemGiaoDich(GiaoDichGuiTien gd)
        {
            if (ModelState.IsValid && gd != null)
            {
                GiaoDichs.Add(gd);
                return gd;
            }

            return null;
        }
        [HttpPost]
        public GiaoDichGuiTien HuyGiaoDich(GiaoDichGuiTien gd)
        {
            if (ModelState.IsValid && gd != null)
            {
                var giaoDich = GiaoDichs.Where(a => a.MaGD == gd.MaGD).FirstOrDefault();
                if (giaoDich != null)
                {
                    giaoDich.TrangThai = TrangThaiGiaoDich.Huy;
                    return gd;
                }
            }

            return null;
        }
    }
}