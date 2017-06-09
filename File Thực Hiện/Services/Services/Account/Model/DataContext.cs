using System.Data.Entity;

namespace Account.Model
{
    public class DataContext : DbContext
    {
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
    }
}
