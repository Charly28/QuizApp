using MediatR;
using Quiz.Data;
using Quiz.Data.Entities;
using Quiz.Services.Models;

namespace Quiz.Services.Commands
{
    public class BulkCommand : IRequest<List<QuestionDto>>
    {

    }

    public class BulkCommandHandler : IRequestHandler<BulkCommand, List<QuestionDto>>
    {
        private readonly QuizDbContext _context;

        public BulkCommandHandler(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> Handle(BulkCommand command, CancellationToken cancellationToken)
        {
            #region Question 1
            var question1Id = Guid.NewGuid();
            var question1 = new Question
            {
                DisplayText = "What is C#?",
                IsActive = true,
                QuestionId = question1Id,
            };

            _context.Question.Add(question1);

            var answer1 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question1Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer2 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question1Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer3 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question1Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer4 = new Answer
            {
                DisplayText = "C sharp is an object-oriented programming language developed by Microsoft. C# is used with the .NET framework for creating websites, applications, and games.",
                IsCorrectAnswer = true,
                QuestionId = question1Id,
                AnswerId = Guid.NewGuid(),
            };

            _context.Answer.AddRange(answer1, answer2, answer3, answer4);
            #endregion

            #region Question 2
            var question2Id = Guid.NewGuid();
            var question2 = new Question
            {
                DisplayText = "How is C# different from C",
                IsActive = true,
                QuestionId = question2Id,
            };

            _context.Question.Add(question2);

            var answer22 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question2Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer23 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question2Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer34 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question2Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer45 = new Answer
            {
                DisplayText = "The biggest difference is that C# supports automatic garbage collection by Common Language Runtime (CLR) while C does not.",
                IsCorrectAnswer = true,
                QuestionId = question2Id,
                AnswerId = Guid.NewGuid(),
            };

            _context.Answer.AddRange(answer22, answer23, answer34, answer45);
            #endregion

            #region Question 3
            var question3Id = Guid.NewGuid();
            var question3 = new Question
            {
                DisplayText = "What is Common Language Runtime (CLR)",
                IsActive = true,
                QuestionId = question3Id,
            };

            _context.Question.Add(question3);

            var answer32 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question3Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer33 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question3Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer44 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question3Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer55 = new Answer
            {
                DisplayText = "CLR handles program execution for various languages including C#.",
                IsCorrectAnswer = true,
                QuestionId = question3Id,
                AnswerId = Guid.NewGuid(),
            };

            _context.Answer.AddRange(answer32, answer33, answer44, answer55);
            #endregion

            #region Question 4
            var question4Id = Guid.NewGuid();
            var question4 = new Question
            {
                DisplayText = "What is garbage collection in C#",
                IsActive = true,
                QuestionId = question4Id,
            };

            _context.Question.Add(question4);

            var answer42 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question4Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer43 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question4Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer54 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question4Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer65 = new Answer
            {
                DisplayText = "Garbage collection is the process of freeing up memory that is captured by unwanted objects.",
                IsCorrectAnswer = true,
                QuestionId = question4Id,
                AnswerId = Guid.NewGuid(),
            };

            _context.Answer.AddRange(answer42, answer43, answer54, answer65);
            #endregion

            #region Question 5
            var question5Id = Guid.NewGuid();
            var question5 = new Question
            {
                DisplayText = "What are extension methods in C#",
                IsActive = true,
                QuestionId = question5Id,
            };

            _context.Question.Add(question5);

            var answer52 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question5Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer53 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question5Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer555 = new Answer
            {
                DisplayText = "Test",
                IsCorrectAnswer = false,
                QuestionId = question5Id,
                AnswerId = Guid.NewGuid(),
            };

            var answer655 = new Answer
            {
                DisplayText = "Extension methods help to add new methods to the existing ones. The methods that are added are static.",
                IsCorrectAnswer = true,
                QuestionId = question5Id,
                AnswerId = Guid.NewGuid(),
            };

            _context.Answer.AddRange(answer52, answer53, answer555, answer655);
            #endregion 

            await _context.SaveChangesAsync();

            return _context.Question.Select(x => new QuestionDto
            {
                QuestionId = x.QuestionId,
                DisplayText = x.DisplayText,
                IsActive = x.IsActive,
                Tags = (from t in x.QuestionTags
                        select new QuestionTagDto
                        {
                            QuestionId = t.QuestionId,
                            QuestionTagId = t.QuestionTagId,
                            TagText = t.TagText,
                        }).ToList(),
                Answers = (from a in x.Answers
                           select new AnswerDto
                           {
                               AnswerId = a.AnswerId,
                               QuestionId = a.QuestionId,
                               DisplayText = a.DisplayText,
                               IsCorrectAnswer = a.IsCorrectAnswer
                           }).ToList(),
            }).ToList();
        }
    }
}
