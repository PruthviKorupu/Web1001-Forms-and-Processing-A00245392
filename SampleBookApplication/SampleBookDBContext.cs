using Microsoft.EntityFrameworkCore;

namespace SampleBookApplication
{
    public class SampleBookDBContext : DbContext
    {
        public SampleBookDBContext(DbContextOptions<SampleBookDBContext> options) : base(options)
        {

        }

        public DbSet<SampleBookApplication.Models.Book> Book { get; set; }
    }
}