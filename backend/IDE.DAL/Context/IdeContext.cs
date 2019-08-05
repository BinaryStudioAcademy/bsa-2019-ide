using Microsoft.EntityFrameworkCore;

namespace IDE.DAL.Context
{
    public sealed class IdeContext : DbContext
    {
        public IdeContext(DbContextOptions<IdeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();

            modelBuilder.Seed();
        }
    }
}
