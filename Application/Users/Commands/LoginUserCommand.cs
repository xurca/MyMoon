using FluentValidation;
using MediatR;
using MyMoon.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Application.Users.Commands
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginUserCommandResponse : CommandResult
    {
        public string AccessToken { get; set; }
    }

    public class LoginUserCommandRequestValidator : AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandRequestValidator()
        {
        }
    }

}
