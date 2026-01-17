using System;

namespace KooliProjekt.Application.Data
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal? Weight { get; set; }
        public decimal? SugarLevel { get; set; }
        public int? BloodPressureSystolic { get; set; }
        public int? BloodPressureDiastolic { get; set; }
        public int? BloodPressurePulse { get; set; }
    }
}
