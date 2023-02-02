using Microsoft.EntityFrameworkCore;
using SampleDemo.Domain;

namespace SampleDemo.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Donar> Donors { get; set; }
    }
}
