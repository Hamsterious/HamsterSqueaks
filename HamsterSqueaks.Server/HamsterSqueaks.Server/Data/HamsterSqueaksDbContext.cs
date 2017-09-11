using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HamsterSqueaks.Server.Models;

namespace HamsterSqueaks.Server.Data
{
    public class HamsterSqueaksDbContext : IdentityDbContext<HamsterSqueaksUser>
    {
        public HamsterSqueaksDbContext(DbContextOptions<HamsterSqueaksDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
