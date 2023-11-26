using C___.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using C___.DTOs.User;

namespace C___.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<User> users { get; set; }

        public DbSet<Post> posts { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
            .Entity<Post>()
            .HasIndex(u => u.Title)
            .IsUnique();
            //modelBuilder.Entity<IdentityUser>()
            //.Property(u => u.UserName)
            //.HasColumnType("nvarchar(256) COLLATE Cyrillic_General_CI_AS");
            //modelBuilder.Entity<IdentityUser>()
            //.Property(u => u.Email)
            //.HasColumnType("nvarchar(256) COLLATE Cyrillic_General_CI_AS");
            //modelBuilder.Entity<UserPostRequest>()
            //.Property(u => u.Password)
            //.HasColumnType("nvarchar(256) COLLATE Cyrillic_General_CI_AS");



        }
    }
}
