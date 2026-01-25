using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IFoodRecordItemRepository
    {
        public Task<FoodRecordItem> GetByIdAsync(int Id);
        public Task SaveAsync(FoodRecordItem record);
        public Task DeleteAsync(FoodRecordItem record);
    }
}
