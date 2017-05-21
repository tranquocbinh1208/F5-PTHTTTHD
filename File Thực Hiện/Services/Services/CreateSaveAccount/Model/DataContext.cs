using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSaveAccount.Model
{
    public class DataContext : DbContext
    {
        public DbSet<GiaoDichLapSoTietKiem> GiaoDichLapSoTietKiems { get; set; }
    }
}
