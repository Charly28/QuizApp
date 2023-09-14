using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Services.Commands;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    public class AnswersController : Controller
    {
        private readonly IMediator _mediator;

        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add an answer to a question
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] AddAnswerToQuestionCommand command)
        {
            var question = await _mediator.Send(command);

            return Ok(question);
        }

        /// <summary>
        /// Generates a vote for an answer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("vote")]
        public async Task<IActionResult> VoteAnswer([FromBody] VoteAnswerCommand command)
        {
            var question = await _mediator.Send(command);

            return Ok(question);
        }
    }
}
