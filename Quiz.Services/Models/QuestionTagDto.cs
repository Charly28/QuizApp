namespace Quiz.Services.Models
{
    public class QuestionTagDto
    {
        public Guid QuestionTagId { get; set; }
        public string TagText { get; set; }
        public Guid QuestionId { get; set; }
    }
}
