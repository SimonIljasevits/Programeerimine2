using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveFoodRecordCommandHandler : IRequestHandler<SaveFoodRecordCommand, OperationResult>
    {
        private readonly IFoodRecordRepository _foodRecordRepository;

        public SaveFoodRecordCommandHandler(IFoodRecordRepository foodRecordRepository)
        {
            _foodRecordRepository = foodRecordRepository;
        }

        public async Task<OperationResult> Handle(SaveFoodRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var foodRecord = new FoodRecord();

            if (request.Id != 0)
            {
                foodRecord = await _foodRecordRepository.GetByIdAsync(request.Id);
            }

            foodRecord.PatientId = request.PatientId;
            foodRecord.RecordDate = request.RecordDate;
            foodRecord.MealType = request.MealType;

            await _foodRecordRepository.SaveAsync(foodRecord);
            return result;
        }
    }
}
