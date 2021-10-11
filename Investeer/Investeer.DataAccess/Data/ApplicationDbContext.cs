using Investeer.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Investeer.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<Status> Status { get; set; }
        public DbSet<PropertyName> PropertyName { get; set; }
        public DbSet<PropertyDetail> PropertyDetail { get; set; }
        //public DbSet<PropertyImage> PropertyImage { get; set; }

    }
}
