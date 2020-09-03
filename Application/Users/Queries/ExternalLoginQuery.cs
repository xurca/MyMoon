using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using MyMoon.Application.Common.Models;

namespace MyMoon.Application.Users.Queries
{
    public class ExternalLoginQueryRequest : IRequest<ExternalLoginQueryResponse>
    {
        public string Provider { get; set; }
        public string ReturnUrl { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class ExternalLoginQueryResponse : Result
    {
        public AuthenticationProperties Properties { get; set; }
    }

    public class ExternalLoginQueryRequestValidator : AbstractValidator<ExternalLoginQueryRequest>
    {
        public ExternalLoginQueryRequestValidator()
        {
            RuleFor(x => x.Provider).NotEmpty().WithMessage("'{PropertyName}' Is required");
        }
    }
}
