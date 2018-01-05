using System;
using System.Collections.Generic;

namespace Blog.Data.Model
{
    /// <summary>
    /// Represent single question in model as entity. 
    /// </summary>
    public class Question : BaseEntity
    {
        /// <summary>
        /// Get or set question text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Get or set one or few answers available to select at same time.
        /// </summary>
        public bool IsFewAnswers { get; set; } = false;

        /// <summary>
        /// Represent collection of related with question avaikable question. Also it is navigation property 'Answers'.
        /// </summary>
        public List<Answer> Answers { get; set; } = new List<Answer>();

        /// <summary>
        /// Represent value of foreign key for navigation property 'Questionnaire'.
        /// </summary>
        public Guid QuestionnaireId { get; set; }

        /// <summary>
        /// Represent  navigation property 'Questionnaire'.
        /// </summary>
        public Questionnaire Questionnaire { get; set; }

        /// <summary>
        /// Represent  navigation property 'SelectedAnswers'.
        /// </summary>
        public List<SelectedAnswer> SelectedAnswers { get; set; }
    }
}
