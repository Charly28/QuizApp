using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Services.Commands;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    public class BulkController : Controller
    {
        private readonly IMediator _mediator;

        public BulkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Bulk insert
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Bulk([FromBody] BulkCommand command)
        {
            var bulk = await _mediator.Send(command);

            return Ok(bulk);
        }
    }
}
