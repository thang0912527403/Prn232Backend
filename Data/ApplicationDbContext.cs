using Microsoft.EntityFrameworkCore;
using Prn232Project.Models;
using System.Diagnostics;

namespace Prn232Project.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRoles>()
                .HasOne<Users>(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRoles>()
                .HasOne<Roles>(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)                
                .WithMany(u => u.RefreshTokens)      
                .HasForeignKey(rt => rt.UserId)       
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
