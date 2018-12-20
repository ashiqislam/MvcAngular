using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApp.Models;

namespace AngularApp.Data
{
    public class Ship_UserContext : IdentityDbContext
    {
        public Ship_UserContext(DbContextOptions<Ship_UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Review { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}