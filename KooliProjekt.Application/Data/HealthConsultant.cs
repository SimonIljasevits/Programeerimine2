using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    public class HealthConsultant : Entity
    {
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
