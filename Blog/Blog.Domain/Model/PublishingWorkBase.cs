using System;

namespace Blog.Data.Model
{
    /// <summary>
    /// Represent abstract entity that mean some publishing work. 
    /// </summary>
    public class PublishingWorkBase : BaseEntity
    {
        /// <summary>
        /// Get or set publishing date.
        /// </summary>
        public DateTime PublishingDate { get; set; }

        /// <summary>
        /// Get or set main text.
        /// </summary>
        public string Text { get; set; }
    }
}
