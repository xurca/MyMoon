using MediatR;
using MyMoon.Application.Common.Models;

namespace MyMoon.Application.Users.Commands
{
    public class ExternalLoginCallbackCommandRequest : IRequest<ExternalLoginCallbackQueryResponse>
    {
        public string ReturnUrl { get; set; }
    }

    public class ExternalLoginCallbackQueryResponse : Result
    {
        public bool IsLockedOut { get; set; }
        public string ReturnUrl { get; set; }
    }
}
