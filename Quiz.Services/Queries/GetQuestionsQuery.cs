using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Services.Models;

namespace Quiz.Services.Queries
{
    public class GetQuestionsQuery : IRequest<List<QuestionDto>>
    {
    }

    public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, List<QuestionDto>>
    {
        private readonly QuizDbContext _context;

        public GetQuestionsQueryHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> Handle(GetQuestionsQuery query, CancellationToken cancellationToken)
        {
            return await _context.Question.Include(x => x.QuestionTags).Include(x => x.Answers).Select(x => new QuestionDto
            {
                DisplayText = x.DisplayText,
                IsActive = x.IsActive,
                QuestionId = x.QuestionId,
                Tags = (from t in x.QuestionTags
                        select new QuestionTagDto
                        {
                            QuestionId = t.QuestionId,
                            QuestionTagId = t.QuestionTagId,
                            TagText = t.TagText,
                        }).ToList()
            }).ToListAsync();
        }
    }
}
