using System.Data.Entity;

namespace Recharge.Model
{
    public class DataContext : DbContext
    {
        public DbSet<GiaoDichGuiTien> GiaoDichGuiTiens { get; set; }
    }
}