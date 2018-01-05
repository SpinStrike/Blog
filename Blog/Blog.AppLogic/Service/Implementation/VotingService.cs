using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.Model;
using Blog.Data.EF;
using Blog.Data.Repository;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service.Implementation
{
    public class VotingService : BaseService, IVotingService
    {
        public VotingService(IDbContextService dbContextService)
        {
            context = dbContextService.GetDbContextInstance();
            _repository = RepositoryFactory.GetVotingRepository(context);
        }


        public void Create(string text, IEnumerable<string> options)
        {
            var voting = new Voting() { Text = text };

            foreach(var option in options)
            {
                voting.Options.Add(new VotingOption(){ Text = option });
            }

            _repository.Add(voting);
            _repository.Commit();
        }

        public VotingDto FindById(Guid id)
        {
            return _repository.FindById(id).ToDto();
        }

        public IEnumerable<VotingDto> GetAll()
        {
            return _repository.FetchAll().Select(x => x.ToDto()).ToList();
        }

        public VotingDto GetRandom()
        {
            return _repository.GetRandomVoting().ToDto();
        }

        public void Vote(Guid idVoting, Guid idOption)
        {
            _repository.FindById(idVoting)
                .Options.First(x => x.Id.Equals(idOption))
                    .Count++;

            _repository.Commit();
        }

        private IVotingRepository _repository;
    }
}
