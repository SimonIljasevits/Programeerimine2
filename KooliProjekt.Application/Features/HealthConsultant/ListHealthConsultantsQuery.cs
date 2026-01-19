using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace KooliProjekt.Application.Features
{
    public class ListHealthConsultantsQuery : IRequest<OperationResult<IList<HealthConsultant>>>
    {
    }
}
