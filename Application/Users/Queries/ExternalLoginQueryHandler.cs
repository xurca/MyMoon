using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Domain.UserManagement;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Users.Queries
{
    public class ExternalLoginQueryHandler : RequestHandler<ExternalLoginQueryRequest, ExternalLoginQueryResponse>
    {
        private readonly SignInManager<User> _signInManager;

        public ExternalLoginQueryHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        protected override ExternalLoginQueryResponse Handle(ExternalLoginQueryRequest request)
        {
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(request.Provider, request.RedirectUrl);

            return new ExternalLoginQueryResponse()
            {
                Succeeded = true,
                Properties = properties
            };
        }
    }
}
