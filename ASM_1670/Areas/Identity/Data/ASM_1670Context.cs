using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASM_1670.Data
{
    public class ASM_1670Context : IdentityDbContext<IdentityUser>
    {
        public ASM_1670Context(DbContextOptions<ASM_1670Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
              new IdentityRole()
              {
                  Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                  Name = "user",
                  ConcurrencyStamp = "1",
                  NormalizedName = "user"
              },
              new IdentityRole()
              {
                  Id = "fab4fac1-c546-41de-aebc-a14da6895720",
                  Name = "storeOwner",
                  ConcurrencyStamp = "2",
                  NormalizedName = "storeOwner"
              },
              new IdentityRole()
              {
                  Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                  Name = "admin",
                  ConcurrencyStamp = "3",
                  NormalizedName = "admin"
              }
           );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
