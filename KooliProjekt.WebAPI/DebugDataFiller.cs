using System;
using System.Linq;
using KooliProjekt.Application.Data;

namespace KooliProjekt.WebAPI
{
    public class DebugDataFiller
    {
        public void Fill(ApplicationDbContext context)
        {
            if (!context.HealthConsultants.Any())
            {
                context.HealthConsultants.AddRange(
                    new HealthConsultant { },
                    new HealthConsultant { }
                );
                context.SaveChanges();
            }

            var consultant = context.HealthConsultants.First();

            if (!context.Patients.Any())
            {
                context.Patients.AddRange(
                    new Patient { HealthConsultantId = consultant.Id },
                    new Patient { HealthConsultantId = consultant.Id }
                );
                context.SaveChanges();
            }

            var patient = context.Patients.First();

            if (!context.FoodItems.Any())
            {
                context.FoodItems.AddRange(
                    new FoodItem { Name = "Apple", EnergyKcal = 52, CarbohydrateGrams = 14, FatGrams = 0.2m, ProteinGrams = 0.3m },
                    new FoodItem { Name = "Egg", EnergyKcal = 155, CarbohydrateGrams = 1.1m, FatGrams = 11, ProteinGrams = 13 },
                    new FoodItem { Name = "Bread", EnergyKcal = 265, CarbohydrateGrams = 49, FatGrams = 3.2m, ProteinGrams = 9 },
                    new FoodItem { Name = "Chicken", EnergyKcal = 239, CarbohydrateGrams = 0, FatGrams = 14, ProteinGrams = 27 }
                );
                context.SaveChanges();
            }

            if (!context.FoodRecords.Any())
            {
                context.FoodRecords.AddRange(
                    new FoodRecord { PatientId = patient.Id, RecordDate = DateTime.Now.Date, MealType = MealType.Breakfast },
                    new FoodRecord { PatientId = patient.Id, RecordDate = DateTime.Now.Date, MealType = MealType.Lunch }
                );
                context.SaveChanges();
            }

            if (!context.FoodRecordItems.Any())
            {
                var foodRecord = context.FoodRecords.First();
                var foodItem1 = context.FoodItems.OrderBy(f => f.Name).First(f => f.Name == "Apple" || f.Name == "Egg" || f.Id > 0); // Safe fallback
                var foodItem2 = context.FoodItems.OrderByDescending(f => f.Name).First();

                context.FoodRecordItems.AddRange(
                    new FoodRecordItem { FoodRecordId = foodRecord.Id, FoodItemId = foodItem1.Id, Quantity = 1 },
                    new FoodRecordItem { FoodRecordId = foodRecord.Id, FoodItemId = foodItem2.Id, Quantity = 2 }
                );
                context.SaveChanges();
            }

            if (!context.MedicalRecords.Any())
            {
                context.MedicalRecords.AddRange(
                    new MedicalRecord { PatientId = patient.Id, RecordDate = DateTime.Now.Date, Weight = 75.5m, BloodPressureSystolic = 120, BloodPressureDiastolic = 80, BloodPressurePulse = 70 }
                );
                context.SaveChanges();
            }
        }
    }
}
