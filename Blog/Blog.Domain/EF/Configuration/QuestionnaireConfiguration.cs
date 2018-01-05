using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class QuestionnaireConfiguration : EntityTypeConfiguration<Questionnaire>
    {
        public QuestionnaireConfiguration()
        {
            HasKey(q => q.Id);
            Property(q => q.Title).IsRequired();

            HasMany(q => q.Questions)
                .WithRequired(q => q.Questionnaire)
                .HasForeignKey(q => q.QuestionnaireId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.CompletedQuestionnaires)
                .WithRequired(x => x.Questionnaire)
                .HasForeignKey(x => x.QuestionnaireId)
                .WillCascadeOnDelete(true);
        }
    }
}
