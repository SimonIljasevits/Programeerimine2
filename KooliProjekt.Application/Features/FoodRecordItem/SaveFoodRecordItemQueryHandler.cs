using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodRecordItemQueryHandler : IRequestHandler<SaveFoodRecordItemQuery, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveFoodRecordItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveFoodRecordItemQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodRecordItem = new FoodRecordItem();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(foodRecordItem);
            }
            else
            {
                foodRecordItem = await _dbContext.FoodRecordItems.FindAsync(request.Id);
            }

            foodRecordItem.FoodRecordId = request.FoodRecordId;
            foodRecordItem.FoodItemId = request.FoodItemId;
            foodRecordItem.Quantity = request.Quantity;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
