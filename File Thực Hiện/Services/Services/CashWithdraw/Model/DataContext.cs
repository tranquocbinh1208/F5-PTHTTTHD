using System.Data.Entity;

namespace CashWithdraw.Model
{
    public class DataContext : DbContext
    {
        public DbSet<GiaoDichRutTien> GiaoDichRutTiens { get; set; }
    }
}
