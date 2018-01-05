using System;
using System.Collections.Generic;

namespace Blog.Data.Model
{
    /// <summary>
    /// Represent single question's answer in model as entity. 
    /// </summary>
    public class Answer : BaseEntity
    {
        /// <summary>
        /// Get or set text value, that represented by answer. 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Represent value of foreign key for navigation property 'Question'.
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Represent navigation propery 'Question'.
        /// </summary>
        public Question Question { get; set; }


        /// <summary>
        /// Represent navigation propery 'SelectedAnswers'.
        /// </summary>
        public List<SelectedAnswer> SelectedAnswers { get; set; }
    }
}
