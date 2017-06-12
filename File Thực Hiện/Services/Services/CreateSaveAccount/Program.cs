using Common;
using CreateSaveAccount.Model;
using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace CreateSaveAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var currentDate = DateTime.Today.AddYears(-1);
                    while (currentDate <= DateTime.Today)
                    {
                        var rand = new Random();
                        var countPerDay = rand.Next(1, 20);
                        for (int i = 0; i < countPerDay; i++)
                        {
                            var item = new GiaoDichLapSoTietKiem
                            {
                                KyHan = 6,
                                LaiSuat = (float)5.0,
                                MaKH = $"KH{i}",
                                MaNV = $"NV{i}",
                                SoTien = 100000,
                                MaGD = AppUtils.GetTransactionID(LoaiGiaoDich.LapSoTietKiem, currentDate) + i.ToString(),
                                TrangThai = TrangThaiGiaoDich.DangXuLy,
                                NgayTao = currentDate
                            };

                            db.GiaoDichLapSoTietKiems.Add(item);
                            db.SaveChanges();
                        }

                        currentDate = currentDate.AddDays(1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string baseAddress = $"http://localhost:{ConfigurationManager.AppSettings["port"] ?? "9001"}/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Transfer service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}