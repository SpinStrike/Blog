using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.EF;
using Blog.Data.Model;
using System;

namespace Blog.Data.Repository.Implementation
{
    public class VotingRepository : BaseRepository<Voting>, IVotingRepository
    {
        public VotingRepository(BlogDbContext context) 
            : base(context, context.Votings)
        {}

        public override IEnumerable<Voting> FetchAll()
        {
            return GetDbSet().Include(x => x.Options);
        }

        public override Voting FindById(Guid id)
        {
            return FetchAll().First(x => x.Id.Equals(id));
        }

        public Voting GetRandomVoting()
        {
            var random = new Random();

            return GetDbSet().OrderBy(x => Guid.NewGuid())
                .Include(x => x.Options)
                .FirstOrDefault();
        } 
    }
}
