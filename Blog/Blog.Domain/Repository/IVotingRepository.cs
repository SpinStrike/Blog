using System;
using Blog.Data.Model;

namespace Blog.Data.Repository
{
    public interface IVotingRepository : IBaseRepository<Voting>
    {
        Voting GetRandomVoting();
    }
}
