using System.Collections;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    public class Patient
    {
        public int Id { get; set; }
        public int HealthConsultantId { get; set; }
        public HealthConsultant HealthConsultant { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<FoodRecord> FoodRecords { get; set; } = new List<FoodRecord>();
    }
}
