using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Models
{ 
    public class AngularAppContext : IdentityDbContext<User>
    {
        public AngularAppContext(DbContextOptions<AngularAppContext> options)
           : base(options)
        {
        }

        public DbSet<AngularApp.Models.Account> Accounts { get; set; }
    }
}
