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
    public class ListFoodRecordsQueryHandler : IRequestHandler<ListFoodRecordsQuery, OperationResult<IList<FoodRecord>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListFoodRecordsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<IList<FoodRecord>>> Handle(ListFoodRecordsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IList<FoodRecord>>();
            result.Value = await _dbContext
                .FoodRecords
                .OrderBy(x => x.Id)
                .Include(x => x.FoodRecordItems)
                .ToListAsync();

            return result;
        }
    }
}
