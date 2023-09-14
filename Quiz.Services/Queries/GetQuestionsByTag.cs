using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Services.Models;

namespace Quiz.Services.Queries
{
    public class GetQuestionsByTag : IRequest<List<QuestionDto>>
    {
        public List<string> Tags { get; set; }
    }

    public class GetQuestionsByTagHandler : IRequestHandler<GetQuestionsByTag, List<QuestionDto>>
    {
        private readonly QuizDbContext _context;

        public GetQuestionsByTagHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> Handle(GetQuestionsByTag query, CancellationToken cancellationToken)
        {
            return await _context.QuestionTag.Include(x => x.Question)
                                        .Include(x => x.Question.Answers)
                                        .Where(x => query.Tags.Any(t => t == x.TagText)).Select(x => new QuestionDto
                                        {
                                            DisplayText = x.Question.DisplayText,
                                            QuestionId = x.Question.QuestionId,
                                            IsActive = x.Question.IsActive,
                                        }).ToListAsync();

        }
    }
}
