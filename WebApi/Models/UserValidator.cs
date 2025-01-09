using FluentValidation;

namespace WebApi.Models
{
    public class UserValidator : AbstractValidator<AuthenticateRequest>
    {
        public UserValidator()
        {
            RuleFor(authenticateRequest => authenticateRequest.Username)
            .NotEmpty()
            .WithMessage("The Username is required.");
            //.MaximumLength(50);

            RuleFor(authenticateRequest => authenticateRequest.Password)
            .NotEmpty()
            .WithMessage("The Password is required.");
            //.MaximumLength(50);

           //RuleFor(book => book.BookId)
          //.NotEmpty()
          //.Matches(@"^[A-Z0-9-]+$")
          //.WithMessage("Invalid book ID format.");
        }
    }
}
