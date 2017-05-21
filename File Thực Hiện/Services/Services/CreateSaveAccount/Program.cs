using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSaveAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = $"http://localhost:{ConfigurationManager.AppSettings["port"] ?? "9003"}/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Transfer service was started at {baseAddress} \nPress any key to stop");
                Console.ReadLine();
            }
        }
    }
}