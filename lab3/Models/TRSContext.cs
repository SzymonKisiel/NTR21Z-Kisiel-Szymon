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
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity
                    .Property(entity => entity.Timestamp)
                    .IsRowVersion();
            });

            modelBuilder.Entity<ActivityEntry>(entity =>
            {
                entity
                    .HasOne(activity => activity.Project)
                    .WithMany(project => project.Activities)
                    .IsRequired()
                    .HasForeignKey(activity => activity.Code);
                entity
                    .Property(entity => entity.Timestamp)
                    .IsRowVersion();
            });

            modelBuilder.Entity<AcceptedTime>(entity =>
            {
                entity
                    .HasOne(accepted => accepted.Project)
                    .WithMany(project => project.AcceptedTimes)
                    .IsRequired()
                    .HasForeignKey(accepted => accepted.Code);
                entity
                    .Property(entity => entity.Timestamp)
                    .IsRowVersion();
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity
                    .Property(entity => entity.Timestamp)
                    .IsRowVersion();
            });

            modelBuilder.Entity<Subactivity>(entity =>
            {
                entity
                    .HasOne(subactivity => subactivity.Project)
                    .WithMany(project => project.Subactivities)
                    .IsRequired()
                    .HasForeignKey(subactivity => subactivity.Code);
                entity
                    .Property(entity => entity.Timestamp)
                    .IsRowVersion();
            });
        }
    }
}