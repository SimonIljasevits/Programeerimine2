using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features;
public class GetFoodRecordQueryHandler : IRequestHandler<GetFoodRecordQuery, OperationResult<object>>
{
    private IFoodRecordRepository _foodRecordRepository;

    public GetFoodRecordQueryHandler(IFoodRecordRepository foodRecordRepository)
    {
        _foodRecordRepository = foodRecordRepository;
    }

    public async Task<OperationResult<object>> Handle(GetFoodRecordQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var foodRecord = await _foodRecordRepository.GetByIdAsync(request.Id);
        result.Value = foodRecord;

        return result;
    }
}
