using CoreWebApp.Data.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Data.BaseOperation
{
   public class CoreWebAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CoreWebAppDbContext(DbContextOptions<CoreWebAppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }
}
