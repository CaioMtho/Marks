using Marks.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marks.Infrastructure.Data
{
    public class MarksDbContext : DbContext
    {
        public MarksDbContext(DbContextOptions<MarksDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Bookmark> Bookmarks => Set<Bookmark>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Folder> Folders => Set<Folder>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Bookmark>()
                .HasMany(b => b.Tags)
                .WithMany(t => t.Bookmarks)
                .UsingEntity(j => j.ToTable("bookmark_tag").HasData());
        }
    }
}
