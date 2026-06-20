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
        }
    }
}