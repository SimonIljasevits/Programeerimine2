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
    public class ListMedicalRecordsQueryHandler : IRequestHandler<ListMedicalRecordsQuery, OperationResult<IList<MedicalRecord>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListMedicalRecordsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<IList<MedicalRecord>>> Handle(ListMedicalRecordsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IList<MedicalRecord>>();
            result.Value = await _dbContext
                .MedicalRecords
                .OrderBy(x => x.Id)
                .ToListAsync();

            return result;
        }
    }
}
