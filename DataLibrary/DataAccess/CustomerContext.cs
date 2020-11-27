using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace EFDataAccessLibrary.DataAccess
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customer { get; set; }        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmaiAddresses { get; set; }

    }
}
