using Microsoft.EntityFrameworkCore;

using Panel.Models;

namespace Panel.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}