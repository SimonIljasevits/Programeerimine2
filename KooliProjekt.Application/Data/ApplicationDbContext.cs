using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<HealthConsultant> HealthConsultants { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodRecord> FoodRecords { get; set; }
        public DbSet<FoodRecordItem> FoodRecordItems { get; set; }

        public bool Any()
        {
            if (Patients.Any())
                return true;
            if (HealthConsultants.Any())
                return true;
            if (MedicalRecords.Any())
                return true;
            if (FoodItems.Any())
                return true;
            if (FoodRecords.Any())
                return true;
            if (FoodRecordItems.Any())
                return true;
            return false;
        }
    }
}
