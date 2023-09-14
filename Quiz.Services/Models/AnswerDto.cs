namespace Quiz.Services.Models
{
    public class AnswerDto
    {
        public Guid AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public string DisplayText { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
