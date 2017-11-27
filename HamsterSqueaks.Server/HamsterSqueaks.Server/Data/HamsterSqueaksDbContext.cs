using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HamsterSqueaks.Server.Models;

namespace HamsterSqueaks.Server.Data
{
    /// <summary>
    /// DbContext for HamsterSqueaks. Defines the database and its tables, and is the entry point for communicating with the database.
    /// </summary>
    public class HamsterSqueaksDbContext : IdentityDbContext<HamsterSqueaksUser>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">
        /// Options on how the DB context shouls work. 
        /// Do not modify this, but instead override DbContext.OnConfigure or a DbContextOptionsBuilder
        /// </param>
        public HamsterSqueaksDbContext(DbContextOptions<HamsterSqueaksDbContext> options)
            : base(options)
        {
        }

        #region DataModels
        /// <summary>
        /// Model representing a blog post written by one or more authors.
        /// </summary>
        public DbSet<BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Model representing an author on hamstersqueaks.
        /// </summary>
        public DbSet<Author> Authors { get; set; } 
        #endregion

        /// <summary>
        /// Modies Entities, their relationships, and their DB Mapping.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
