namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Represent review as review data transfer object.
    /// </summary>
    public class ReviewDto : PublishingWorkBaseDto
    {
        /// <summary>
        /// Article's author.
        /// </summary>
        public string Author { get; set; }
    }
}
