
using FluentValidation;

namespace SurveyBasket.Api.Contracts.Polls
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.password).NotEmpty();


        }
       
    }
}
