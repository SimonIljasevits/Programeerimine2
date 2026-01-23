using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodRecordQueryHandler : IRequestHandler<SaveFoodRecordQuery, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveFoodRecordQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveFoodRecordQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodRecord = new FoodRecord();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(foodRecord);
            }
            else
            {
                foodRecord = await _dbContext.FoodRecords.FindAsync(request.Id);
            }

            foodRecord.PatientId = request.PatientId;
            foodRecord.RecordDate = request.RecordDate;
            foodRecord.MealType = request.MealType;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
