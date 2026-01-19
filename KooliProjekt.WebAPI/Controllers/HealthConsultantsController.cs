using KooliProjekt.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KooliProjekt.WebAPI.Controllers
{
    public class HealthConsultantsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public HealthConsultantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var query = new ListHealthConsultantsQuery();
            var healthConsultants = await _mediator.Send(query);

            return Result(healthConsultants);
        }
    }
}
