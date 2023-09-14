using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Services.Commands;
using Quiz.Services.Queries;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    public class QuestionsController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Post a Question
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] AddQuestionCommand command)
        {
            var question = await _mediator.Send(command);

            return Ok(question);
        }

        /// <summary>
        ///  Retrieves a question with QuestionId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(Guid id)
        {
            var question = await _mediator.Send(new GetQuestionQuery { QuestionId = id });

            return Ok(question);
        }

        /// <summary>
        /// Retrieves a list of questions
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetQuestions(GetQuestionsQuery query)
        {
            var question = await _mediator.Send(query);

            return Ok(question);
        }

        /// <summary>
        /// Register a vote for a Question
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("vote")]
        public async Task<IActionResult> VoteQuestion([FromBody] VoteQuestionCommand command)
        {
            var question = await _mediator.Send(command);

            return Ok(question);
        }

        /// <summary>
        /// Get a list of questions filtered by tag list
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("tag")]
        public async Task<IActionResult> GetQuestionsByTag(GetQuestionsByTag query)
        {
            var question = await _mediator.Send(query);

            return Ok(question);
        }

    }
}
