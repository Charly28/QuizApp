using Microsoft.EntityFrameworkCore;
using Quiz.Data.Entities;

namespace Quiz.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext()
        {

        }

        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<QuestionTag> QuestionTag { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                       .Navigation(e => e.QuestionTags)
                       .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<QuestionTag>()
                .Navigation(e => e.Question);

            modelBuilder.Entity<Question>()
           .Navigation(e => e.Answers)
           .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Answer>()
                .Navigation(e => e.Question);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
