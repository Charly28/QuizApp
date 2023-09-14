using MediatR;
using Quiz.Data;
using Quiz.Data.Entities;
using Quiz.Services.Models;

namespace Quiz.Services.Commands
{
    public class AddQuestionCommand : IRequest<QuestionDto>
    {
        public string DisplayText { get; set; }
        public bool IsActive { get; set; }
        public List<string> Tags { get; set; }
    }

    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, QuestionDto>
    {
        private readonly QuizDbContext _context;

        public AddQuestionCommandHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionDto> Handle(AddQuestionCommand command, CancellationToken cancellationToken)
        {
            Guid questionId = Guid.NewGuid();

            var question = new Question
            {
                DisplayText = command.DisplayText,
                IsActive = command.IsActive,
                QuestionId = questionId,
            };

            _context.Question.Add(question);

            if (command.Tags.Any())
            {
                foreach (var tag in command.Tags)
                {
                    _context.QuestionTag.Add(new QuestionTag
                    {
                        QuestionId = questionId,
                        QuestionTagId = Guid.NewGuid(),
                        TagText = tag
                    });
                }
            }

            await _context.SaveChangesAsync();

            return new QuestionDto
            {
                QuestionId = questionId,
                DisplayText = command.DisplayText,
                IsActive = command.IsActive,
            };
        }
    }
}
