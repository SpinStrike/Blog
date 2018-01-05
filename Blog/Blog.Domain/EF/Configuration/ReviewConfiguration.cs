using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Author).IsRequired();
            Property(a => a.Text).IsRequired();
            Property(a => a.PublishingDate).IsRequired();
        }
    }
}
