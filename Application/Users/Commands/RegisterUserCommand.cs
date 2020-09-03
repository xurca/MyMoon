using FluentValidation;
using MediatR;
using MyMoon.Application.Common.Models;
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
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }

    public class RegisterUserCommandResponse : Result
    {
        public int Id { get; set; }
    }

    public class RegisterUserCommandRequestValidator : AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("'{PropertyName}' Is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("'{PropertyName}' Is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("'{PropertyName}' Is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("'{PropertyName}' Is required");
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirm).WithMessage("Password fields should match");
        }
    }
}
