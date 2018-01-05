using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasKey(q => q.Id);
            Property(q => q.Text).IsRequired();
            Property(q => q.IsFewAnswers).IsRequired();

            HasMany(q => q.Answers)
                .WithRequired(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.SelectedAnswers)
                .WithRequired(x => x.Question)
                .HasForeignKey(x => x.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}
