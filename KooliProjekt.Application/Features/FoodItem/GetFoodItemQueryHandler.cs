using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features;
public class GetFoodItemQueryHandler : IRequestHandler<GetFoodItemQuery, OperationResult<object>>
{
    private IFoodItemRepository _foodItemRepository;

    public GetFoodItemQueryHandler(IFoodItemRepository foodItemRepository)
    {
        _foodItemRepository = foodItemRepository;
    }

    public async Task<OperationResult<object>> Handle(GetFoodItemQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var foodItem = await _foodItemRepository.GetByIdAsync(request.Id);
        result.Value = foodItem;

        return result;
    }
}
