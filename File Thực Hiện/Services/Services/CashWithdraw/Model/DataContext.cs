using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CashWithdraw.Model
{
    public class DataContext : DbContext
    {
        public DbSet<GiaoDichRutTien> GiaoDichRutTiens { get; set; }
    }
}
