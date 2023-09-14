namespace Quiz.Services.Models
{
    public class VoteDto
    {
        public Guid VoteId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
