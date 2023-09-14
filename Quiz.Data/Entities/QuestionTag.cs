using System.ComponentModel.DataAnnotations;

namespace Quiz.Data.Entities
{
    public partial class QuestionTag
    {
        [Key]
        public Guid QuestionTagId { get; set; }
        [Required]
        public string TagText { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
