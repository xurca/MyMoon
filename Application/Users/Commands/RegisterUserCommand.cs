using FluentValidation;
using MediatR;
using MyMoon.Domain.Enums;

namespace MyMoon.Application.Users.Commands
{
    public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class RegisterUserCommandResponse
    {

    }

    public class RegisterUserCommandRequestValidator : AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Is required");
        }
    }

}
