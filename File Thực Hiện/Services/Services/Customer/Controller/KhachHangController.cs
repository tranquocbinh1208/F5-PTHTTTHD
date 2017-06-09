using Customer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
            }
            return null;
        }
    }
}
