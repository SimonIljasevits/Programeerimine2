using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveHealthConsultantCommandHandler : IRequestHandler<SaveHealthConsultantCommand, OperationResult>
    {
        private readonly IHealthConsultantRepository _healthConsultantRepository;

        public SaveHealthConsultantCommandHandler(IHealthConsultantRepository healthConsultantRepository)
        {
            _healthConsultantRepository = healthConsultantRepository;
        }

        public async Task<OperationResult> Handle(SaveHealthConsultantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var healthConsultant = new HealthConsultant();

            if (request.Id != 0)
            {
                healthConsultant = await _healthConsultantRepository.GetByIdAsync(request.Id);
            }

            await _healthConsultantRepository.SaveAsync(healthConsultant);
            return result;
        }
    }
}
