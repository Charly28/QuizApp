using System.ComponentModel.DataAnnotations;

namespace Quiz.Data.Entities
{
    public partial class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        public string DisplayText { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
