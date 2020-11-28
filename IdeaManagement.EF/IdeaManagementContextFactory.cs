using Microsoft.EntityFrameworkCore;
using System;
namespace IdeaManagement.EF
{
    public class IdeaManagementContextFactory
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

    }
}
