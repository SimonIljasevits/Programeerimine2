using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features
{
    public class DeleteMedicalRecordCommandHandler : IRequestHandler<DeleteMedicalRecordCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteMedicalRecordCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            await _dbContext
                .MedicalRecords
                .Where(record => record.Id == request.Id)
                .ExecuteDeleteAsync();

            return result;
        }
    }
}
