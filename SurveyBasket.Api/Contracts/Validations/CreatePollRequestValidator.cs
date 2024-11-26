
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
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Please add A title")
                .Length(3, 1000);

        }
    }
}
 