using FluentValidation;
using MediatR;
using MyMoon.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Application.Users.Queries
{
    public class ExternalLoginCallbackQueryRequest : IRequest<ExternalLoginCallbackQueryResponse>
    {
        public string ReturnUrl { get; set; }
    }

    public class ExternalLoginCallbackQueryResponse : Result
    {
        public bool Succeeded { get; set; }
        public bool IsLockedOut { get; set; }
        public string Email { get; set; }
    }
}
