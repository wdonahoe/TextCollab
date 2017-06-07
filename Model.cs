using System;
using TextCollab.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace TextCollab {

    public class TextContext : DbContext {
        
        public TextContext(DbContextOptions<TextContext> options) : base(options) { }

        public DbSet<Text> Text { get; set; }
        public DbSet<TextSlice> TextSlice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Text>().ToTable("Text");
            modelBuilder.Entity<TextSlice>().ToTable("TextSlice");
        }

        public override int SaveChanges(){
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps(){

            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities){

                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).dateCreated = DateTime.UtcNow;
                
                ((BaseEntity)entity.Entity).dateModified = DateTime.UtcNow;

            }
        }
    }
}