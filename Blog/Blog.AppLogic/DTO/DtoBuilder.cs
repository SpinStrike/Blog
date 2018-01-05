using System.Linq;
using Blog.Data.Model;

namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Represent functionality to convert model entity to data transfer object.
    /// </summary>
    public static class DtoBuilder
    {
        /// <summary>
        /// Convert Article entity to ArticleDto.
        /// </summary>
        public static ArticleDto ToDto(this Article article, bool isLoadTags = false)
        {
            var articleDto  = new ArticleDto()
            {
                Id = article.Id,
                Title = article.Title,
                Text = article.Text,
                PublishingDate = article.PublishingDate
            };

            if(isLoadTags)
            {
                articleDto.Tags = article.Tags.Select(x => new ArticleTagDto() {
                    Id = x.Id,
                    Text = x.Text })
                        .ToList();
            }

            return articleDto;

        }

        /// <summary>
        /// Convert Review entity to ReviewDto.
        /// </summary>
        public static ReviewDto ToDto(this Review review)
        {
            return new ReviewDto()
            {
                Id = review.Id,
                Author = review.Author,
                Text = review.Text,
                PublishingDate = review.PublishingDate
            };
        }

        /// <summary>
        /// Convert Questionnaire entity to QuestionnaireDto.
        /// </summary>
        public static QuestionnaireDto ToDto(this Questionnaire questionnaire)
        {
            var questionnaireDto = new QuestionnaireDto()
            {
                Id = questionnaire.Id,
                Title = questionnaire.Title
            };

            foreach (var question in questionnaire.Questions)
            {
                questionnaireDto.Questions.Add(new QuestionDto<AnswerDto>()
                {
                    Id = question.Id,
                    Text = question.Text,
                    IsFewAnswers = question.IsFewAnswers,
                });

                foreach (var answer in question.Answers)
                {
                    questionnaireDto.Questions.Last().Answers.Add(new AnswerDto()
                    {
                        Id = answer.Id,
                        Text = answer.Text
                    });
                }
            }
            return questionnaireDto;
        }

        public static VotingDto ToDto(this Voting voting)
        {
            var votingDto = new VotingDto {
                Id = voting.Id,
                Text = voting.Text };

            foreach(var option in voting.Options)
            {
                votingDto.Options.Add(new VotingOptionDto() {
                    Id = option.Id,
                    Text = option.Text,
                    Count = option.Count });
            }

            return votingDto;
        }
    }
}
