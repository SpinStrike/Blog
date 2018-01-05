using System.Data.Entity.ModelConfiguration;
using Blog.Data.Model;

namespace Blog.Data.EF.Configuration
{
    public class VotingConfiguration : EntityTypeConfiguration<Voting>
    {
        public VotingConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Text).IsRequired();

            HasMany(x => x.Options)
                .WithRequired(x => x.Voting)
                .HasForeignKey(x => x.VotingId);
        }
    }
}
