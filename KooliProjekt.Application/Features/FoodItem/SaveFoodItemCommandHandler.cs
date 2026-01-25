using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodItemCommandHandler : IRequestHandler<SaveFoodItemCommand, OperationResult>
    {
        private readonly IFoodItemRepository _foodItemRepository;

        public SaveFoodItemCommandHandler(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }

        public async Task<OperationResult> Handle(SaveFoodItemCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodItem = new FoodItem();

            if (request.Id != 0)
            {
                foodItem = await _foodItemRepository.GetByIdAsync(request.Id);
            }

            foodItem.Name = request.Name;
            foodItem.EnergyKcal = request.EnergyKcal;
            foodItem.FatGrams = request.FatGrams;
            foodItem.CarbohydrateGrams = request.CarbohydrateGrams;
            foodItem.ProteinGrams = request.ProteinGrams;
            foodItem.SaltGrams = request.SaltGrams;

            await _foodItemRepository.SaveAsync(foodItem);
            return result;
        }
    }
}
