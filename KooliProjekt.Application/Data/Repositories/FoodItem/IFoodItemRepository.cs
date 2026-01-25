using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Repositories
{
    public interface IFoodItemRepository
    {
        public Task<FoodItem> GetByIdAsync(int Id);
        public Task SaveAsync(FoodItem record);
        public Task DeleteAsync(FoodItem record);
    }
}
