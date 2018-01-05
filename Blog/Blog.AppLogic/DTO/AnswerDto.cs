namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Represent answer as answer data transfer object.
    /// </summary>
    public class AnswerDto : EntityDto
    {
        /// <summary>
        /// Answer's text.
        /// </summary>
        public string Text { get; set; }
    }
}
