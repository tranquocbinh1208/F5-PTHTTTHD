using Customer.Model;
using Microsoft.Owin.Hosting;
using System;
using System.Configuration;
using System.Linq;

namespace Customer
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
            //            var a = new KhachHang
            //            {
            //                CMND = i.ToString(),
            //                DiaChi = $"Số {i}, Đường {i}, Phường {i}, Quận {i}, TP.HCM",
            //                Email = $"{i}@gmail.com",
            //                GioiTinh = i % 2 == 0 ? true : false,
            //                HinhChuKy = $"images\\hinh{i}",
            //                HoTen = $"Khách Hàng {i}",
            //                MaKH = $"KH{i}",
            //                MaNV = $"NV{i}",
            //                NgayCapCMND = DateTime.Today.AddYears(-(i % 2 == 0 ? 1 : 2)),
            //                NgayCapNhat = DateTime.Today,
            //                NgaySinh = DateTime.Today.AddYears(-(i % 2 == 0 ? 18 : 19)),
            //                NgayTao = DateTime.Today,
            //                NoiCapCMND = $"CA Tỉnh {i}",
            //                SDT = i.ToString(),
            //                TrangThai = Common.TrangThaiKhachHang.DaKichHoat
            //            };

            //            db.KhachHangs.Add(a);
            //        }
            //        db.SaveChanges();

            //        Console.WriteLine(db.KhachHangs.Count().ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            string baseAddress = $"http://localhost:{ConfigurationManager.AppSettings["port"] ?? "9006"}/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Customer service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}
