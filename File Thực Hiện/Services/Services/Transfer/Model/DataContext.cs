using System.Data.Entity;

namespace Transfer.Model
{
    public class DataContext : DbContext
    {
        public DbSet<GiaoDichChuyenTien> GiaoDichChuyenTiens { get; set; }
    }
}
