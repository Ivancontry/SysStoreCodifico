using MediatR;
using Microsoft.AspNetCore.Mvc;
using SysStore.Application.Customers;
using System.Threading.Tasks;

namespace SysStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{custId:int}/orders")]
        public async Task<IActionResult> GetAsync(int custId)
        {            
            var response = await _mediator.Send(new GetOrdersForCustomerIdRequest { CustId = custId});
            return Ok(response);
        }

    }
}
