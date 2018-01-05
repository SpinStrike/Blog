namespace Blog.Data.Model
{
    /// <summary>
    /// Represent Review in model as entity. 
    /// </summary>
    public class Review : PublishingWorkBase
    {
        /// <summary>
        /// Get or set author of review. 
        /// </summary>
        public string Author { get; set; }
    }
}
