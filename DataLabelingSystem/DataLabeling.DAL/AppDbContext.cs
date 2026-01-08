using Microsoft.EntityFrameworkCore;
using DataLabeling.Core.Entities;

namespace DataLabeling.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DataItem> DataItems { get; set; }
        public DbSet<LabelTask> LabelTasks { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LabelTask>()
                .HasOne(t => t.DataItem)
                .WithOne(d => d.LabelTask)
                .HasForeignKey<LabelTask>(t => t.DataItemId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Manager)
                .WithMany(u => u.ManagedProjects)
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<LabelTask>()
                .HasOne(t => t.Annotator)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AnnotatorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}