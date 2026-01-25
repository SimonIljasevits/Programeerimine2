using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IHealthConsultantRepository
    {
        public Task<HealthConsultant> GetByIdAsync(int Id);
        public Task SaveAsync(HealthConsultant record);
        public Task DeleteAsync(HealthConsultant record);
    }
}
