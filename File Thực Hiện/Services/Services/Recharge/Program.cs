using Common;
using Microsoft.Owin.Hosting;
using Recharge.Model;
using System;
using System.Configuration;

namespace Recharge
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
            //                var item = new GiaoDichGuiTien
            //                {
            //                    NgayCapCMND = DateTime.Today.AddYears(-18),
            //                    NoiCapCMND = $"Công An tỉnh  {i}",
            //                    SDT = i.ToString(),
            //                    CMND = i.ToString(),
            //                    Diachi = "Dia chi 1",
            //                    HoTenNguoiGoi = $"Khách hàng {i}",
            //                    MaKHNhan = $"KH{i+1}",
            //                    MaNV = $"NV{i}",
            //                    NoiDung = $"Chuyển tiền",
            //                    SoTien = 100000,
            //                    MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.GuiTien, currentDate) + i.ToString(),
            //                    TrangThai = TrangThaiGiaoDich.DangXuLy,
            //                    NgayTao = currentDate
            //                };

            //                db.GiaoDichGuiTiens.Add(item);
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

            string baseAddress = $"http://localhost:{ConfigurationManager.AppSettings["port"] ?? "9002"}/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Recharge service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}