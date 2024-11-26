
using FluentValidation;

namespace SurveyBasket.Api.Contracts.Validations
{
    public class CreatePollRequestValidator : AbstractValidator<PollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Please add A title")
                .Length(3, 100);

            RuleFor(x => x.Summary)
                .NotEmpty()
                .WithMessage("Please add A title")
                .Length(3, 1500);

            RuleFor(x => x.StartsAt)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.EndsAt)
                .NotEmpty();

            RuleFor(x => x)
                .Must(ValidDate);
               

        }
        private bool ValidDate(PollRequest request)
        {
            return request.EndsAt >= request.StartsAt;
        }
    }
}
 