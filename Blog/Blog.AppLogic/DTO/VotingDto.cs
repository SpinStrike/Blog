using System.Collections.Generic;

namespace Blog.AppLogic.DTO
{
    public class VotingDto : EntityDto
    {
        public string Text { get; set; }

        public List<VotingOptionDto> Options { get; set; } = new List<VotingOptionDto>();
    }
}
