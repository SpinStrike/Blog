using Blog.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace Blog.Data.EF.Configuration
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Title).IsRequired();
            Property(a => a.Text).IsRequired();
            Property(a => a.PublishingDate).IsRequired();

            HasMany(x => x.Tags)
                .WithMany(y => y.Articles)
                .Map(xy => {
                    xy.MapLeftKey("ArticleId");
                    xy.MapRightKey("TagId");
                });
        }
    }
}
