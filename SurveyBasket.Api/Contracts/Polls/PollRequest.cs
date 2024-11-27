using SurveyBasket.Api.Contracts.Polls;

namespace SurveyBasket.Api.Contracts.Polls
{
    public record PollRequest
    (
     string Title,
     string Summary,
     bool IsPublished,
     DateOnly StartsAt,
     DateOnly EndsAt
    );

}
