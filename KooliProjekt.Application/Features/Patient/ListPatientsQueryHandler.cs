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
    public class ListPatientsQueryHandler : IRequestHandler<ListPatientsQuery, OperationResult<IList<Patient>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListPatientsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<IList<Patient>>> Handle(ListPatientsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IList<Patient>>();
            result.Value = await _dbContext
                .Patients
                .OrderBy(x => x.Id)
                .ToListAsync();

            return result;
        }
    }
}
