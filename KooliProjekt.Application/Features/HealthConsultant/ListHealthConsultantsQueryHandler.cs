using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class ListHealthRecordsQueryHandler : IRequestHandler<ListHealthConsultantsQuery, OperationResult<IList<HealthConsultant>>>
    {
        private ApplicationDbContext _dbContext;

        public ListHealthRecordsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<IList<HealthConsultant>>> Handle(ListHealthConsultantsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IList<HealthConsultant>>();
            result.Value = await _dbContext
                .HealthConsultants
                .OrderBy(hc => hc.Id)
                .ToListAsync();

            return result;
        }
    }
}
