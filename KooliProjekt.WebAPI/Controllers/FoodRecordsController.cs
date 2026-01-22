using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Features;
using KooliProjekt.Application.Infrastructure.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class FoodRecordsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public FoodRecordsController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListFoodRecordsQuery query)
        {
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
