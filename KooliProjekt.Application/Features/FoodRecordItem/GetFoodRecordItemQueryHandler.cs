using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features;
public class GetFoodRecordItemQueryHandler : IRequestHandler<GetFoodRecordItemQuery, OperationResult<object>>
{
    private IFoodRecordItemRepository _foodRecordItemRepository;

    public GetFoodRecordItemQueryHandler(IFoodRecordItemRepository foodRecordItemRepository)
    {
        _foodRecordItemRepository = foodRecordItemRepository;
    }

    public async Task<OperationResult<object>> Handle(GetFoodRecordItemQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var foodRecordItem = await _foodRecordItemRepository.GetByIdAsync(request.Id);
        result.Value = foodRecordItem;

        return result;
    }
}
