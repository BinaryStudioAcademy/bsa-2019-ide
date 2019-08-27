using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;

namespace IDE.DAL.Context
{
    public sealed class IdeContext : DbContext
    {
        private static bool _isDatabaseUpdatedChecked = false;

        public IdeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Build> Builds { get; private set; }
        public DbSet<Project> Projects { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<ProjectMember> ProjectMembers { get; private set; }
        public DbSet<Image> Images { get; private set; }
        public DbSet<RefreshToken> RefreshTokens { get; private set; }
        public DbSet<GitCredential> GitCredentials { get; private set; }
        public DbSet<FavouriteProjects> FavouriteProjects { get; private set; }
        public DbSet<VerificationToken> VerificationTokens { get; private set; }
        public DbSet<Notification> Notifications { get; private set; }
        public DbSet<EditorSetting> EditorSettings { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
        }

        public void InitializeDatabase()
        {
            if (_isDatabaseUpdatedChecked)
            {
                return;
            }

            if (Database.GetPendingMigrations().Count() != 0)
            {
                Database.Migrate();
            }

            _isDatabaseUpdatedChecked = true;
        }
    }
}