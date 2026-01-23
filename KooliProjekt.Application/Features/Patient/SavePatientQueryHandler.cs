using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SavePatientQueryHandler : IRequestHandler<SavePatientQuery, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePatientQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SavePatientQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var patient = new Patient();

            if (request.Id == 0)
            {
                await _dbContext.AddAsync(patient);
            }
            else
            {
                patient = await _dbContext.Patients.FindAsync(request.Id);
            }

            patient.HealthConsultantId = request.HealthConsultantId;

            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
