using FluentValidation;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(e => e.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username field is required")
                .MinimumLength(5)
                .WithMessage("Username must have at least 5 characters.")
                .MaximumLength(100)
                .WithMessage("Username must have less than 100 characters.");
        }
    }
}
