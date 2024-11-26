using SurveyBasket.Api.Contracts.Responses;

namespace SurveyBasket.Api.Contracts.Requests
{
    public record PollRequest 
    (
     string Title,
     string Description
    );

}
