using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Application.Common.Models;
using MyMoon.Domain.UserManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Users.Commands
{
    public class ExternalLoginCallbackCommandHandler : IRequestHandler<ExternalLoginCallbackCommandRequest, ExternalLoginCallbackQueryResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public ExternalLoginCallbackCommandHandler(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ExternalLoginCallbackQueryResponse> Handle(ExternalLoginCallbackCommandRequest request, CancellationToken cancellationToken)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return new ExternalLoginCallbackQueryResponse()
                {
                    Succeeded = false
                };
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
                return new ExternalLoginCallbackQueryResponse()
                {
                    Succeeded = true,
                    ReturnUrl = request.ReturnUrl
                };

            if (signInResult.IsLockedOut)
            {
                return new ExternalLoginCallbackQueryResponse()
                {
                    Succeeded = false,
                    IsLockedOut = signInResult.IsLockedOut
                };
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);
            IdentityResult result;

            if (user != null)
            {
                result = await _userManager.AddLoginAsync(user, info);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return new ExternalLoginCallbackQueryResponse()
                    {
                        Succeeded = true,
                        ReturnUrl = request.ReturnUrl
                    };
                }
            }
            else
            {
                var givenName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
                var surname = info.Principal.FindFirstValue(ClaimTypes.Surname);
                var mobilePhone = info.Principal.FindFirstValue(ClaimTypes.MobilePhone);
                var gender = info.Principal.FindFirstValue(ClaimTypes.Gender);
                var dateOfBirth = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth);
                var userData = info.Principal.FindFirstValue(ClaimTypes.UserData);

                var newUser = new User(givenName, surname, null, email, mobilePhone);

                result = await _userManager.CreateAsync(newUser);

                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(newUser, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newUser, isPersistent: false);

                        return new ExternalLoginCallbackQueryResponse()
                        {
                            Succeeded = true,
                            ReturnUrl = request.ReturnUrl
                        };
                    }
                }
            }

            return new ExternalLoginCallbackQueryResponse()
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => new Error(e.Code, e.Description)).ToList()
            };
        }
    }
}