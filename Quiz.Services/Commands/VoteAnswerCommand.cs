using MediatR;
using Quiz.Data;
using Quiz.Data.Entities;
using Quiz.Services.Models;


namespace Quiz.Services.Commands
{
    public class VoteAnswerCommand : IRequest<VoteDto>
    {
        public Guid AnswerId { get; set; }
    }

    public class VoteAnswerCommandHandler : IRequestHandler<VoteAnswerCommand, VoteDto>
    {
        private readonly QuizDbContext _context;

        public VoteAnswerCommandHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<VoteDto> Handle(VoteAnswerCommand command, CancellationToken cancellationToken)
        {
            var vote = new Vote
            {
                VoteId = Guid.NewGuid(),
                AnswerId = command.AnswerId,
            };

            _context.Vote.Add(vote);

            await _context.SaveChangesAsync();

            return new VoteDto
            {
                VoteId = vote.VoteId,
                AnswerId = vote.AnswerId.Value,
            };
        }
    }
}
