using System.ComponentModel.DataAnnotations;


namespace Quiz.Data.Entities
{
    public partial class Vote
    {
        [Key]
        public Guid VoteId { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        [Required]
        public Guid? VotedBy { get; set; }
    }
}
