using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBcontext : IdentityDbContext<AppUser>
    {
        public ApplicationDBcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Holding> Holdings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Holding>(x => x.HasKey(p => new { p.AppUserID, p.StockID }));

            builder.Entity<Holding>()
             .HasOne(u => u.AppUser)
             .WithMany(u => u.Holdings)
             .HasForeignKey(H => H.AppUserID);

            builder.Entity<Holding>()
             .HasOne(u => u.Stock)
             .WithMany(u => u.Holdings)
             .HasForeignKey(h => h.StockID);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}