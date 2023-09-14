namespace Quiz.Services.Models
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            Tags = new List<QuestionTagDto>();
            Answers = new List<AnswerDto>();
        }

        public Guid QuestionId { get; set; }
        public string DisplayText { get; set; }
        public bool IsActive { get; set; }

        public List<QuestionTagDto> Tags { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
