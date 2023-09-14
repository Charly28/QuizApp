using MediatR;
using Quiz.Data;
using Quiz.Data.Entities;
using Quiz.Services.Models;


namespace Quiz.Services.Commands
{
    public class VoteQuestionCommand : IRequest<VoteDto>
    {
        public Guid QuestionId { get; set; }
    }

    public class VoteQuestionCommandHandler : IRequestHandler<VoteQuestionCommand, VoteDto>
    {
        private readonly QuizDbContext _context;

        public VoteQuestionCommandHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<VoteDto> Handle(VoteQuestionCommand command, CancellationToken cancellationToken)
        {
            var vote = new Vote
            {
                VoteId = Guid.NewGuid(),
                QuestionId = command.QuestionId,
            };

            _context.Vote.Add(vote);

            await _context.SaveChangesAsync();

            return new VoteDto
            {
                VoteId = vote.VoteId,
                QuestionId = vote.QuestionId.Value,
            };
        }
    }
}
