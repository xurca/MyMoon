using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Domain.UserManagement;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Users.Queries
{
    public class GetProvidersQueryHandler : IRequestHandler<GetProvidersQueryRequest, GetProvidersQueryResponse>
    {
        private readonly SignInManager<User> _signInManager;

        public GetProvidersQueryHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<GetProvidersQueryResponse> Handle(GetProvidersQueryRequest request, CancellationToken cancellationToken)
        {
            var providers = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return new GetProvidersQueryResponse()
            {
                Providers = providers.Select(x => new ProviderItem(x.Name, x.DisplayName))
            };
        }
    }
}
