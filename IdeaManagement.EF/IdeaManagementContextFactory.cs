using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
namespace IdeaManagement.EF
{
    public class IdeaManagementContextFactory //: IDesignTimeDbContextFactory<IdeaManagementDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

       

        public IdeaManagementContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }
        public IdeaManagementDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<IdeaManagementDbContext> options = new DbContextOptionsBuilder<IdeaManagementDbContext>();

            _configureDbContext(options);

            return new IdeaManagementDbContext(options.Options);
        }
        
        //public IdeaManagementDbContext CreateDbContext(string[] args = null)
        //{
        //    var options = new DbContextOptionsBuilder<IdeaManagementDbContext>();
        //    options.UseSqlServer("Server=localhost;Initial Catalog=Panel;Integrated Security=False;User Id=sa;Password=yourStrong(!)Password;MultipleActiveResultSets=True");
        //    return new IdeaManagementDbContext(options.Options);
        //}
    }
}
