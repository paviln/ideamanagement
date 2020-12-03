using IdeaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaManagement.EF
{
    public class IdeaManagementDbContext : DbContext
    {
        
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public IdeaManagementDbContext(DbContextOptions<IdeaManagementDbContext> options) : base(options) { }
        
      
    }
}

