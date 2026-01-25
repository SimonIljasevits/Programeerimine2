using KooliProjekt.Application.Data;
using KooliProjekt.Application.Data.Repositories;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class SaveMedicalRecordCommandHandler : IRequestHandler<SaveMedicalRecordCommand, OperationResult>
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public SaveMedicalRecordCommandHandler(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<OperationResult> Handle(SaveMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var medicalRecord = new MedicalRecord();

            if (request.Id != 0)
            {
                medicalRecord = await _medicalRecordRepository.GetByIdAsync(request.Id);
            }

            medicalRecord.PatientId = request.PatientId;
            medicalRecord.RecordDate = request.RecordDate;
            medicalRecord.Weight = request.Weight;
            medicalRecord.SugarLevel = request.SugarLevel;
            medicalRecord.BloodPressureDiastolic = request.BloodPressureDiastolic;
            medicalRecord.BloodPressureSystolic = request.BloodPressureSystolic;
            medicalRecord.BloodPressurePulse = request.BloodPressurePulse;

            await _medicalRecordRepository.SaveAsync(medicalRecord);
            return result;
        }
    }
}
