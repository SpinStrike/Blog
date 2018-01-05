using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class CompletedQuestionnaireConfiguration : EntityTypeConfiguration<CompletedQuestionnaire>
    {
        public CompletedQuestionnaireConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.UserId).IsRequired();

            HasMany(x => x.SelectedAnswers)
                .WithRequired(x => x.CompletedQuestionnaire)
                .HasForeignKey(x => x.CompletedQuestionnaireId)
                .WillCascadeOnDelete(true);
        }
    }
}
