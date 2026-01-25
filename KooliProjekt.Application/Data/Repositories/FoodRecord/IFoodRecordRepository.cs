using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IFoodRecordRepository
    {
        public Task<FoodRecord> GetByIdAsync(int Id);
        public Task SaveAsync(FoodRecord record);
        public Task DeleteAsync(FoodRecord record);
    }
}
