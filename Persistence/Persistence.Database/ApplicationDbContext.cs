using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Persistence.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            ModelConfig(builder);
        }

        protected void ModelConfig(ModelBuilder modelBuilder) 
        {
            new UserConfiguration(modelBuilder.Entity<User>());
            new PostConfiguration(modelBuilder.Entity<Post>());
            new CommentConfiguration(modelBuilder.Entity<Comment>());
            new StatusConfiguration(modelBuilder.Entity<Status>());
        }
    }
}
