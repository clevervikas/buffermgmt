using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace BufferMgmt.DAL.Entities
{
    public class BufferMgmtContext : DbContext
    {
        public BufferMgmtContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MaterialCode> MaterialCodes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<MaterialDetail> MaterialDetails { get; set; }

    }
}
