using System;
using System.Collections.Generic;

namespace Blog.Data.Model
{
    /// <summary>
    /// Represent questionare as complext user's answers on questions group. This class is a part of data model.   
    /// </summary>
    public class CompletedQuestionnaire : BaseEntity
    {
        /// <summary>
        /// Represent collection of selected by user answers that are related with questions from this questionnaire. Also it is  navigation property 'SelectedAnswers'.
        /// </summary>
        public List<SelectedAnswer> SelectedAnswers { get; set; } = new List<SelectedAnswer>();

        /// <summary>
        /// Represent property that set relationship with user in data model. 
        /// </summary>
        public Guid UserId { get; set; } = new Guid();

        /// <summary>
        /// Represent value of foreign key for navigation property 'Questionnaire'.
        /// </summary>
        public Guid QuestionnaireId { get; set; }

        /// <summary>
        /// Represent navigation propery 'Questionnaire'.
        /// </summary>
        public Questionnaire Questionnaire { get; set; }
    }
}
