using Application.Employee.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetById()
        {
            var dashboard = await _mediator.Send(new DashboardEmployeeCommand());
            var response = new Requests.HttpResponse<object>
                {
                    Code = "OK",
                    Message = "",
                    Data = dashboard
                };
            return Ok(response);
        }
    }
}
