using System.Collections.Generic;

namespace Blog.Data.Model
{
    public class Voting : BaseEntity
    {
        public string Text { get; set; }

        public List<VotingOption> Options { get; set; }  = new List<VotingOption>();
    }
}
