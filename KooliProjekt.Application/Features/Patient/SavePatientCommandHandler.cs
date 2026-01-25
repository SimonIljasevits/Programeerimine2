using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SavePatientCommandHandler : IRequestHandler<SavePatientCommand, OperationResult>
    {
        private readonly IPatientRepository _patientRepository;

        public SavePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<OperationResult> Handle(SavePatientCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var patient = new Patient();

            if (request.Id != 0)
            {
                patient = await _patientRepository.GetByIdAsync(request.Id);
            }

            patient.HealthConsultantId = request.HealthConsultantId;

            await _patientRepository.SaveAsync(patient);
            return result;
        }
    }
}
