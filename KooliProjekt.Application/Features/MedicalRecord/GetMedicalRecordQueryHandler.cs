using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features;
public class GetMedicalRecordQueryHandler : IRequestHandler<GetMedicalRecordQuery, OperationResult<object>>
{
    private IMedicalRecordRepository _medicalRecordRepository;

    public GetMedicalRecordQueryHandler(IMedicalRecordRepository medicalRecordRepository)
    {
        _medicalRecordRepository = medicalRecordRepository;
    }

    public async Task<OperationResult<object>> Handle(GetMedicalRecordQuery request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<object>();
        var medicalRecord = await _medicalRecordRepository.GetByIdAsync(request.Id);
        result.Value = medicalRecord;

        return result;
    }
}