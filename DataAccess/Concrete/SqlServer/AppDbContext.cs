using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.SqlServer
{
    public class AppDbContext : IdentityDbContext<User>
    {
       protected override void OnConfiguring (DbContextOptionsBuilder builder)
       {
        builder.UseSqlServer("Server=localhost,1433;Initial Catalog=FruitkaProject;Persist Security Info=False;User Id=sa;Password=rena12345;MultipleActiveResultSets=true;");
       
       }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CategorySub> CategorySubs { get; set; }

        protected override  void  OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }

    }
}