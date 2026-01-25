using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodRecordItemCommandHandler : IRequestHandler<SaveFoodRecordItemCommand, OperationResult>
    {
        private readonly IFoodRecordItemRepository _foodRecordItemRepository;

        public SaveFoodRecordItemCommandHandler(IFoodRecordItemRepository foodRecordItemRepository)
        {
            _foodRecordItemRepository = foodRecordItemRepository;
        }

        public async Task<OperationResult> Handle(SaveFoodRecordItemCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodRecordItem = new FoodRecordItem();

            if (request.Id != 0)
            {
                foodRecordItem = await _foodRecordItemRepository.GetByIdAsync(request.Id);
            }

            foodRecordItem.FoodRecordId = request.FoodRecordId;
            foodRecordItem.FoodItemId = request.FoodItemId;
            foodRecordItem.Quantity = request.Quantity;

            await _foodRecordItemRepository.SaveAsync(foodRecordItem);
            return result;
        }
    }
}
