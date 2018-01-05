using System;

namespace Blog.Data.Model
{ 
    public class VotingOption : BaseEntity
    {
        public string Text { get; set; }

        public int Count { get; set; } = 0;

        public Guid VotingId { get; set; }

        public Voting Voting { get; set; }
    }
}
