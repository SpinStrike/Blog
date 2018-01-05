using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class SelectedAnswerConfiguration : EntityTypeConfiguration<SelectedAnswer>
    {
        public SelectedAnswerConfiguration()
        {
            HasKey(s => new {s.Id});
        }
    }
}
