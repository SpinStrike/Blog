using System.Collections.Generic;

namespace Blog.Data.Model
{
    /// <summary>
    /// Represent single article in model as entity. 
    /// </summary>
    public class Article : PublishingWorkBase
    {
        /// <summary>
        /// Title/name of article.
        /// </summary>
        public string Title { get; set; }

        public List<ArticleTag> Tags { get; set; } = new List<ArticleTag>();
    }
}
