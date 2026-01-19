using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features
{
    public class ListFoodRecordItemsQueryHandler : IRequestHandler<ListFoodRecordItemsQuery, OperationResult<IList<FoodRecordItem>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListFoodRecordItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<IList<FoodRecordItem>>> Handle(ListFoodRecordItemsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IList<FoodRecordItem>>();
            result.Value = await _dbContext
                .FoodRecordItems
                .OrderBy(x => x.Id)
                .ToListAsync();

            return result;
        }
    }
}
