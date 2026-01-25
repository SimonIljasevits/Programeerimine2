using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IMedicalRecordRepository
    {
        public Task<MedicalRecord> GetByIdAsync(int Id);
        public Task SaveAsync(MedicalRecord record);
        public Task DeleteAsync(MedicalRecord record);
    }
}
