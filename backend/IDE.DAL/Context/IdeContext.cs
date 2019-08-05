using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IDE.DAL.Context
{
    public sealed class IdeContext : DbContext
    {
        public IdeContext(DbContextOptions<IdeContext> options) : base(options) { }

        public DbSet<Build> Builds { get; private set; }
        public DbSet<LastSuccessfulBuild> LastSuccessfulBuilds { get; private set; }
        public DbSet<Project> Projects { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<ProjectMember> ProjectMembers { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();

            modelBuilder.Seed();
        }
    }
}
