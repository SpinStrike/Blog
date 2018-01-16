using System;
using System.Collections.Generic;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service
{
    /// <summary>
    ///  Presents functionality for work with articles.
    /// </summary>
    public interface IArticleService : IBaseService<ArticleDto>
    {
        /// <summary>
        /// Create new article entity and add it to dataset. 
        /// </summary>
        void Create(string title, string text, DateTime time, List<string> tags);

        IEnumerable<ArticleDto> GetAllByTag(Guid idTag);

        IEnumerable<ArticleTagDto> GetAllTags();
    }
}
