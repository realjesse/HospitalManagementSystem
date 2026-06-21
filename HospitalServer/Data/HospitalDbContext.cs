using HospitalServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalServer.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        // Name of the table
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();

        // Map the Patient entity to the database schema
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity.HasIndex(p => p.MongoUserId);

                entity.Property(p => p.FirstName)
                .IsRequired();

                entity.Property(p => p.LastName)
                .IsRequired();

                entity.Property(p => p.DateOfBirth)
                .IsRequired();

                entity.Property(p => p.CreatedAt)
                .IsRequired();
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(a => a.AppointmentId);

                entity.Property(a => a.PatientId)
                    .IsRequired();

                entity.Property(a => a.DoctorName)
                    .IsRequired();

                entity.Property(a => a.AppointmentDate)
                    .IsRequired();

                entity.Property(a => a.Status)
                    .IsRequired();
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.HasKey(i => i.InventoryItemId);

                entity.Property(i => i.ItemName)
                    .IsRequired();

                entity.Property(i => i.Category)
                    .IsRequired();

                entity.Property(i => i.Quantity)
                    .IsRequired();

                entity.Property(i => i.MinimumStockLevel)
                    .IsRequired();

                entity.Property(i => i.LastUpdated)
                    .IsRequired();
            });
        }
    }
}