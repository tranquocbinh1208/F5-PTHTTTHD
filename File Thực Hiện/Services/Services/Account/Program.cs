using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    using (var db = new DataContext())
            //    {
            //        for (int i = 0; i < 100; i++)
            //        {
            //            var a = new TaiKhoan
            //            {
            //                MaKH = $"KH{i}",
            //                MaSoTaiKhoan = $"TK{i}",
            //                NgayHetHan = DateTime.Today.AddYears(2),
            //                NgayTao = DateTime.Today,
            //                SoDuKhaDung = 5000000,
            //                SoDuThuc = 4900000,
            //                TrangThai = Common.TrangThaiTaiKhoan.DaKichHoat
            //            };

            //            db.TaiKhoans.Add(a);
            //        }
            //        db.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            string baseAddress = $"http://localhost:{ConfigurationManager.AppSettings["port"] ?? "9007"}/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Account service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}