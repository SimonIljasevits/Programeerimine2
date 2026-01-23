using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodItemQueryHandler : IRequestHandler<SaveFoodItemQuery, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveFoodItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveFoodItemQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodItem = new FoodItem();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(foodItem);
            }
            else
            {
                foodItem = await _dbContext.FoodItems.FindAsync(request.Id);
            }

            foodItem.Name = request.Name;
            foodItem.EnergyKcal = request.EnergyKcal;
            foodItem.FatGrams = request.FatGrams;
            foodItem.CarbohydrateGrams = request.CarbohydrateGrams;
            foodItem.ProteinGrams = request.ProteinGrams;
            foodItem.SaltGrams = request.SaltGrams;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
