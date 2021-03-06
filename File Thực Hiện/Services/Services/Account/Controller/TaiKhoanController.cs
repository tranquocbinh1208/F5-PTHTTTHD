﻿using Account.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Account.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaiKhoanController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpGet]
        public IEnumerable<TaiKhoan> LayTatCaTaiKhoan()
        {
            try
            {
                return db.TaiKhoans;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public TaiKhoan LayTaiKhoanTheoSoTaiKhoan(string soTK)
        {
            try
            {
                return db.TaiKhoans.Where(a => a.MaSoTaiKhoan.ToUpper() == soTK.ToUpper().Trim()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public TaiKhoan LayTaiKhoanTheoMaKH(string MaKH)
        {
            try
            {
                return db.TaiKhoans.Where(a => a.MaKH.ToUpper() == MaKH.ToUpper().Trim()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpPost]
        public TaiKhoan CapNhatTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                var tk = db.TaiKhoans.Where(a => a.MaSoTaiKhoan.ToUpper().Trim() == taiKhoan.MaSoTaiKhoan.ToUpper().Trim()).FirstOrDefault();
                if (tk != null)
                {
                    tk.SoDuKhaDung = taiKhoan.SoDuKhaDung;
                    tk.SoDuThuc = taiKhoan.SoDuThuc;
                    db.SaveChanges();
                    return tk;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
