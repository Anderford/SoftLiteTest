using Microsoft.EntityFrameworkCore;
using SoftLiteTest.Models;

namespace SoftLiteTest.Data
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey(t => t.Id);
            modelBuilder.Entity<Status>().HasKey(s => s.Status_ID);

            modelBuilder.Entity<Task>()
                .HasOne(x => x.Status)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.Status_ID);

            modelBuilder.Entity<Status>().HasData(
                new Status { Status_ID = 1, Status_Name = "Создана" },
                new Status { Status_ID = 2, Status_Name = "В работе"},
                new Status { Status_ID = 3, Status_Name = "Создана" }

                );
        }
    }
}