using System;

namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Base abstruct class for publishing work data transfer objects.
    /// </summary>
    public abstract class PublishingWorkBaseDto : EntityDto
    {
        /// <summary>
        /// Main text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Date of publishing.
        /// </summary>
        public DateTime PublishingDate { get; set; }
    }
}
