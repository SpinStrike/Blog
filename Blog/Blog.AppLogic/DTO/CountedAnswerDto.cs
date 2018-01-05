namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Extend ArticleDto. Used for output statistic.
    /// </summary>
    public class CountedAnswerDto : AnswerDto
    {
        /// <summary>
        /// Get or set how many times answer has been select. 
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
