using TextCollab.Models;
using Microsoft.EntityFrameworkCore;

namespace TextCollab {

    public class TextContext : DbContext {

        //public TextContext() { }

        public TextContext(DbContextOptions<TextContext> options) : base(options) { }

        public DbSet<Text> Text { get; set; }
        public DbSet<TextSlice> TextSlice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Text>().ToTable("Text");
            modelBuilder.Entity<TextSlice>().ToTable("TextSlice");
        }
    }
}