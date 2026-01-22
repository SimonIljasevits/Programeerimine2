using System.Threading.Tasks;
using KooliProjekt.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class FoodItemsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public FoodItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListFoodItemsQuery query)
        {
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
