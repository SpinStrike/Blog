using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.Model;
using Blog.AppLogic.DTO;
using Blog.Data.EF;
using Blog.Data.Repository;

namespace Blog.AppLogic.Service.Implementation
{
    /// <summary>
    ///  Represent functionality for work with articles.
    /// </summary>
    public class ArticleService : BaseService, IArticleService
    {
        /// <summary>
        /// Create article service. 
        /// </summary>
        public ArticleService(IDbContextService dbContextService)
        {
            context = dbContextService.GetDbContextInstance();
            _aRepository = RepositoryFactory.GetArticleRepository(context);
            _atRepository = RepositoryFactory.GetArticleTagRepository(context);
        }

        /// <summary>
        /// Create new article entity and add it to dataset. 
        /// </summary>
        public void Create(string title, string text, DateTime time, List<string> tags)
        {
            var article = new Article()
            {
                Title = title,
                Text = text,
                PublishingDate = time
            };

            var selectedTags = _atRepository.LoadandSelectMany(tags);

            article.Tags.AddRange(selectedTags);

            _aRepository.Add(article);
            _aRepository.Commit();
        }

        /// <summary>
        /// Select all articles from dataset and return list of articleDto. 
        /// </summary>
        public IEnumerable<ArticleDto> GetAll()
        {
            var entityesDto = new List<ArticleDto>();
            foreach (var entity in _aRepository.FetchAll())
            {
                entityesDto.Add(entity.ToDto());
            }

            return entityesDto;
        }

        /// <summary>
        /// Find Article by identifier and return ArticleDto.
        /// </summary>
        public ArticleDto FindById(Guid id)
        {
            return _aRepository.FindById(id).ToDto(true);
        }

        public IEnumerable<ArticleDto> GetAllByTag(Guid idTag)
        {
            return _atRepository.FindById(idTag)
                .Articles.Select(x => x.ToDto());
        }

        private IArticleRepository _aRepository;
        private IArticleTagRepository _atRepository;
    }
}
