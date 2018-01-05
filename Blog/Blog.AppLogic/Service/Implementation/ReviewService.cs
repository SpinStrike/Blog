using System;
using System.Collections.Generic;
using Blog.AppLogic.DTO;
using Blog.Data.Model;
using Blog.Data.EF;
using Blog.Data.Repository;

namespace Blog.AppLogic.Service.Implementation
{
    /// <summary>
    ///  Represent functionality for work with articles.
    /// </summary>
    public class ReviewService : BaseService, IReviewService
    {
        /// <summary>
        /// Create article service. 
        /// </summary>
        public ReviewService(IDbContextService dbContextService)
        {
            context = dbContextService.GetDbContextInstance();
            _repository = RepositoryFactory.GetReviewRepository(context);
        }

        /// <summary>
        /// Create new review entity and add it to dataset. 
        /// </summary>
        public void Create(string text, string author, DateTime time)
        {
            var review = new Review()
            {
                Text = text,
                Author = author,
                PublishingDate = time
            };

            _repository.Add(review);
            _repository.Commit();
        }

        /// <summary>
        /// Select all articles from dataset and return list of reviewDto. 
        /// </summary>
        public IEnumerable<ReviewDto> GetAll()
        {
            var entityesDto = new List<ReviewDto>();
            foreach (var entity in _repository.FetchAll())
            {
                entityesDto.Add(entity.ToDto());
            }

            return entityesDto;
        }

        /// <summary>
        /// Find review by identifier and return reviewDto.
        /// </summary>
        public ReviewDto FindById(Guid id)
        {
            return _repository.FindById(id).ToDto();
        }

        private IReviewRepository _repository;
    }
}
