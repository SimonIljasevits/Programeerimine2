using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features;
public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, OperationResult<object>>
{
    private IPatientRepository _patientRepository;

    public GetPatientQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<OperationResult<object>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var patient = await _patientRepository.GetByIdAsync(request.Id);
        result.Value = patient;

        return result;
    }
}
