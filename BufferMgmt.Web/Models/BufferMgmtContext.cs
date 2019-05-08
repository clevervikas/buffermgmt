using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace BufferMgmt.Web.Models
{
    public class BufferMgmtContext : DbContext
    {
        public BufferMgmtContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Branch> Branches { get; set; }
    }
}
