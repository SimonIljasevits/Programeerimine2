using System.Threading.Tasks;
using KooliProjekt.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class MedicalRecordsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalRecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var query = new ListMedicalRecordsQuery();
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
