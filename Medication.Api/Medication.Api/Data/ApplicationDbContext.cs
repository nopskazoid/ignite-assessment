using Medication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Medication.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Clinician> Clinicians { get; set; }

        public DbSet<Medication.Entities.Medication> Medications { get; set; }

        public DbSet<MedicationRequest> MedicationRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(x =>
            {
                x.HasData(
                    new Patient() { Id = 1, FirstName = "Brian", LastName = "Purvis", DateOfBirth = new DateTime(1973, 4, 2).ToUniversalTime() });
            });

            modelBuilder.Entity<Clinician>(x =>
            {
                x.HasData(
                    new Clinician() { Id = 1, FirstName = "James", LastName = "Watson", RegistrationId = "NHS001" });
            });

            modelBuilder.Entity<Medication.Entities.Medication>(x =>
            {
                x.HasData(
                    new Entities.Medication() { Id = 1, Code = "0407010H0AAAMAM", CodeName = "Paracetamol 500mg tablets", CodeSystem = "SNOMED", StrengthUnit = "mg", StrengthValue = 500, Form = Entities.Medication.MedicationForm.Tablet },
                    new Entities.Medication() { Id = 2, Code = "42104811000001109", CodeName = "Ibuprofen 200mg tablets", CodeSystem = "SNOMED", StrengthValue = 200, StrengthUnit = "mg", Form = Entities.Medication.MedicationForm.Tablet });
            });
        }
    }
}
