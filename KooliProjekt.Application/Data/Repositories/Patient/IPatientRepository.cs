using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IPatientRepository
    {
        public Task<Patient> GetByIdAsync(int Id);
        public Task SaveAsync(Patient record);
        public Task DeleteAsync(Patient record);
    }
}
