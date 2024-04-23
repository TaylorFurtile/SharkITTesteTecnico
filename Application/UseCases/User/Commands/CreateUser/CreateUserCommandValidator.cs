using FluentValidation;
using SharkITTesteTecnico.Application.Abstractions.Repository;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(e => e.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username field is required")
                .MinimumLength(5)
                .WithMessage("Username must have at least 5 characters.")
                .MaximumLength(100)
                .WithMessage("Username must have less than 100 characters.");

            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email field is required.")
                .EmailAddress()
                .WithMessage("Email is invalid.");

            RuleFor(t => t)
                .MustAsync(async (t, ct) => t.Email == null || await _userRepository.IsEmailUnique(t.Email))
                .WithMessage("Email already exists.");
        }
    }
}
