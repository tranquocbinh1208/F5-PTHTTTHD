using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recharge.Model
{
    public class DataContext : DbContext
    {
        public DbSet<GiaoDichGuiTien> GiaoDichGuiTiens { get; set; }
    }
}