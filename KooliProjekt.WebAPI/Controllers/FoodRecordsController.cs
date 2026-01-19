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
        public async Task<IActionResult> List()
        {
            var query = new ListFoodRecordsQuery();
            var result = await _mediator.Send(query);
            var list = new List<FoodRecordItem>();
            list.Add(new FoodRecordItem { FoodItemId = 1 });
            list.Add(new FoodRecordItem { FoodItemId = 2 });
            list.Add(new FoodRecordItem { FoodItemId = 3 });
            result.Value.First().FoodRecordItems = list;

            return Result(result);
        }
    }
}
