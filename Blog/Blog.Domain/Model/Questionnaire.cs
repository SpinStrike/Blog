using System.Collections.Generic;

namespace Blog.Data.Model
{
    /// <summary>
    /// Represent Questionnaire in model as entity. 
    /// </summary>
    public class Questionnaire : BaseEntity
    {
        /// <summary>
        /// Get or set title/name of Questionnaire.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represent collection of all  questions in Questionnaire. Also it is navigation property 'Answers'.
        /// </summary>
        public List<Question> Questions { get; set; } = new List<Question>();

        /// <summary>
        /// Represent  navigation property 'CompletedQuestionnaires'.
        /// </summary>
        public List<CompletedQuestionnaire> CompletedQuestionnaires { get; set; }
    }
}
