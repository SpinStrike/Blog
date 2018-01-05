using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Text).IsRequired();

            HasMany(x => x.SelectedAnswers)
                .WithRequired(x => x.Answer)
                .HasForeignKey(x => x.AnswerId)
                .WillCascadeOnDelete(false);
        }
    }
}
