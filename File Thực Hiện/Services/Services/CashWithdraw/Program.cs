using CashWithdraw.Model;
using Common;
using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace CashWithdraw
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    using (var db = new DataContext())
            //    {
            //        var currentDate = DateTime.Today.AddYears(-1);
            //        while (currentDate <= DateTime.Today)
            //        {
            //            var rand = new Random();
            //            var countPerDay = rand.Next(1, 20);
            //            for (int i = 0; i < countPerDay; i++)
            //            {
            //                var item = new GiaoDichRutTien
            //                {
            //                    MaKH = $"KH{i}",
            //                    MaNV = $"NV{i}",
            //                    NoiDung = $"Rut tien",
            //                    SoTien = 100000,
            //                    MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.RutTien, currentDate) + i.ToString(),
            //                    TrangThai = TrangThaiGiaoDich.DangXuLy,
            //                    NgayTao = currentDate
            //                };

            //                db.GiaoDichRutTiens.Add(item);
            //                db.SaveChanges();
            //            }

            //            currentDate = currentDate.AddDays(1);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            string baseAddress = $"http://localhost:{ConfigurationManager.AppSettings["port"] ?? "9000"}/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Cashwithdraw service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}
