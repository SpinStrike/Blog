using System;
using System.Collections.Generic;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service
{
    public interface IVotingService : IBaseService<VotingDto>
    {
        void Create(string text, IEnumerable<string> options);

        VotingDto GetRandom();

        void Vote(Guid idVoting, Guid idOption);
    }
}
