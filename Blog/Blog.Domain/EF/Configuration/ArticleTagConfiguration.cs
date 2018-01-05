using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class ArticleTagConfiguration : EntityTypeConfiguration<ArticleTag>
    {
        public ArticleTagConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Text);
        }
    }
}
