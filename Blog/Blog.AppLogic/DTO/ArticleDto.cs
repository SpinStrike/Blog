using System.Collections.Generic;

namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Represent article as article data transfer object.
    /// </summary>
    public class ArticleDto : PublishingWorkBaseDto
    {
        /// <summary>
        /// Article title/name.
        /// </summary>
        public string Title { get; set; }

        public List<ArticleTagDto> Tags { get; set; } = new List<ArticleTagDto>();
    }
}
