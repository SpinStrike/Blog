using System;

namespace Blog.Data.Model
{
    public class SelectedAnswer : BaseEntity
    {
        /// <summary>
        /// Represent value of foreign key for navigation property 'CompletedQuestionnaire'.
        /// </summary>
        public Guid CompletedQuestionnaireId { get; set; }

        /// <summary>
        /// Represent  navigation property 'CompletedQuestionnaire'.
        /// </summary>
        public CompletedQuestionnaire CompletedQuestionnaire { get; set; }

        /// <summary>
        /// Represent value of foreign key for navigation property 'Question'.
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Represent  navigation property 'Question'.
        /// </summary>
        public Question Question { get; set; }

        /// <summary>
        /// Represent value of foreign key for navigation property 'Answer'.
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Represent  navigation property 'Answer'.
        /// </summary>
        public Answer Answer { get; set; } 
    }
}
