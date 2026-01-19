using System.Collections.Generic;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features
{
    public class ListFoodRecordItemsQuery : IRequest<OperationResult<IList<FoodRecordItem>>>
    {
    }
}
