using AcudirTestBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace AcudirTestBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
