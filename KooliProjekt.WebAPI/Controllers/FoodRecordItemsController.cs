using System;
using System.Linq;
using System.Threading.Tasks;
using KooliProjekt.Application.Features;
using KooliProjekt.Application.Infrastructure.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class FoodRecordItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public FoodRecordItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListFoodRecordItemsQuery query)
        {
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
