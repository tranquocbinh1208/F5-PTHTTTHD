using Microsoft.Owin.Hosting;
using System;

namespace Recharge
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Recharge service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}