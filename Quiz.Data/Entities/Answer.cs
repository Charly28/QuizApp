using System.ComponentModel.DataAnnotations;

namespace Quiz.Data.Entities
{
    public partial class Answer
    {
        [Key]
        public Guid AnswerId { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        [Required]
        public string DisplayText { get; set; }
        [Required]
        public bool IsCorrectAnswer { get; set; }
        public virtual Question Question { get; set; }
    }
}
