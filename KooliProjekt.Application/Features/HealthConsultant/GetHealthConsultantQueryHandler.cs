using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features;
public class GetHealthConsultantQueryHandler : IRequestHandler<GetHealthConsultantQuery, OperationResult<object>>
{
    private IHealthConsultantRepository _healthConsultantRepository;

    public GetHealthConsultantQueryHandler(IHealthConsultantRepository healthConsultantRepository)
    {
        _healthConsultantRepository = healthConsultantRepository;
    }

    public async Task<OperationResult<object>> Handle(GetHealthConsultantQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var healthConsultant = await _healthConsultantRepository.GetByIdAsync(request.Id);
        result.Value = healthConsultant;

        return result;
    }
}
