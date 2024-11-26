using SurveyBasket.Api.Contracts.Requests;
using SurveyBasket.Api.Contracts.Responses;

namespace SurveyBasket.Api.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

      
        
    }
}
