using MediatR;
using Microsoft.AspNetCore.Mvc;
using SysStore.Application.Customers.Orders;
using System.Threading.Tasks;

namespace SysStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAddOrderAsync(RegisterOrderRequest request) {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetSalesDatePredictionRequest request)
        {
            request.CustomerName ??= "";
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
