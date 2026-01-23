using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveHealthConsultantQueryHandler : IRequestHandler<SaveHealthConsultantQuery, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveHealthConsultantQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveHealthConsultantQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var healthConsultant = new HealthConsultant();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(healthConsultant);
            }
            else
            {
                healthConsultant = await _dbContext.HealthConsultants.FindAsync(request.Id);
            }

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
