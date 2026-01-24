using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features
{
    public class DeleteFoodItemCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
