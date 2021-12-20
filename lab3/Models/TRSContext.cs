using Microsoft.EntityFrameworkCore;

namespace TRS.Models
{
    public class TRSContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<ActivityEntry> ActivityEntry { get; set; }
        public DbSet<AcceptedTime> AcceptedTime { get; set; }
        public DbSet<Subactivity> Subactivity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("server=localhost;database=NTR21Z;user=NTR21Z;password=343762345");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Publisher>(entity => {
            //     entity.HasKey(e => e.ID);
            //     entity.Property(e => e.Name).IsRequired();
            // });
            // modelBuilder.Entity<Book>(entity => {
            //     entity.HasKey(e => e.ISBN);
            // });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Code);
            });

            modelBuilder.Entity<ActivityEntry>()
                .HasOne(a => a.Project)
                .WithMany(p => p.Activities)
                .IsRequired()
                .HasForeignKey(a => a.Code);
        }
    }
}