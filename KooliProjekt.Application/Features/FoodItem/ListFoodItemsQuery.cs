using System.Collections.Generic;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features
{
    public class ListFoodItemsQuery : IRequest<OperationResult<IList<FoodItem>>>
    {
    }
}
