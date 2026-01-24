using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features
{
    public class DeleteFoodRecordItemCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
