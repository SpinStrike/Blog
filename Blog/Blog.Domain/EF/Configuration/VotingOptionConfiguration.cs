using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class VotingOptionConfiguration : EntityTypeConfiguration<VotingOption>
    {
        public VotingOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Text).IsRequired();
        }
    }
}
