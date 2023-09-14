using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Services.Models;

namespace Quiz.Services.Queries
{

    public class GetQuestionQuery : IRequest<QuestionDto>
    {
        public Guid QuestionId { get; set; }
    }

    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionDto>
    {
        private readonly QuizDbContext _context;

        public GetQuestionQueryHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionDto> Handle(GetQuestionQuery query, CancellationToken cancellationToken)
        {
            var question = await _context.Question.Include(x => x.QuestionTags).Include(x => x.Answers).FirstOrDefaultAsync(x => x.QuestionId == query.QuestionId);

            return new QuestionDto
            {
                QuestionId = question.QuestionId,
                DisplayText = question.DisplayText,
                IsActive = question.IsActive,
                Tags = (from t in question.QuestionTags
                        select new QuestionTagDto
                        {
                            QuestionId = t.QuestionId,
                            QuestionTagId = t.QuestionTagId,
                            TagText = t.TagText,
                        }).ToList(),
                Answers = (from a in question.Answers      
                           select new AnswerDto
                           {
                               AnswerId = a.AnswerId,
                               QuestionId = a.QuestionId,
                               DisplayText = a.DisplayText,
                               IsCorrectAnswer = a.IsCorrectAnswer
                           }).ToList(),
            };
        }
    }
}
