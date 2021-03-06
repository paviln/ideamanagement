﻿using EskobInnovation.IdeaManagement.API.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EskobInnovation.IdeaManagement.API.Data
{
  public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
  {
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    public DbSet<Idea> Ideas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<IdeaComment> IdeaComments { get; set; }
    public DbSet<FileData> FileDatas { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }
  }
}
