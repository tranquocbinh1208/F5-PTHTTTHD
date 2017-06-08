using System.Data.Entity;

namespace Customer.Model
{
    class DataContext : DbContext
    {
        public DbSet<KhachHang> KhachHangs { get; set; }
    }
}
