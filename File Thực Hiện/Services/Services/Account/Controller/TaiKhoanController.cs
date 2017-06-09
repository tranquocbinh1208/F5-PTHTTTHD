using Account.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Account.Controller
{
    class TaiKhoanController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpGet]
        public IEnumerable<TaiKhoan> LayTatCaTaiKhoan()
        {
            try
            {
                return db.TaiKhoans;
            }
            catch (Exception)
            {
            }
            return null;
        }

        [HttpGet]
        public TaiKhoan LayTaiKhoanTheoMaKH(string MaKH)
        {
            try
            {
                return db.TaiKhoans.Where(a => a.MaKH.ToLower() == MaKH.ToLower().Trim()).FirstOrDefault();
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
