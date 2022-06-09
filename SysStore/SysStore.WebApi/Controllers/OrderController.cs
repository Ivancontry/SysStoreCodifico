using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysStore.Application.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysStore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerName}")]
        public async Task<IActionResult> GetSalesDatePredictionAsync([FromQuery] GetSalesDatePredictionRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("{custId}")]
        public async Task<IActionResult> GetOrdersForCustomerIdAsync([FromQuery] GetOrdersForCustomerIdRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
