using MediatR;
using Quiz.Data;
using Quiz.Data.Entities;
using Quiz.Services.Models;

namespace Quiz.Services.Commands
{
    public class AddAnswerToQuestionCommand : IRequest<AnswerDto>
    {
        public Guid QuestionId { get; set; }
        public string DisplayText { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }

    public class AddAnswerToQuestionCommandHandler : IRequestHandler<AddAnswerToQuestionCommand, AnswerDto>
    {
        private readonly QuizDbContext _context;

        public AddAnswerToQuestionCommandHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<AnswerDto> Handle(AddAnswerToQuestionCommand command, CancellationToken cancellationToken)
        {
            var answerId = Guid.NewGuid();
            var answer = new Answer
            {
                AnswerId = answerId,
                DisplayText = command.DisplayText,
                QuestionId = command.QuestionId,
                IsCorrectAnswer = command.IsCorrectAnswer
            };

            _context.Answer.Add(answer);

            await _context.SaveChangesAsync();

            return new AnswerDto
            {
                AnswerId = answerId,
                QuestionId = command.QuestionId,
                DisplayText = command.DisplayText,
                IsCorrectAnswer = command.IsCorrectAnswer
            };
        }
    }
}
