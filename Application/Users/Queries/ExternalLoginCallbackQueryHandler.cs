using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Users.Queries
{
    public class ExternalLoginCallbackQueryHandler : IRequestHandler<ExternalLoginCallbackQueryRequest, ExternalLoginCallbackQueryResponse>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public ExternalLoginCallbackQueryHandler(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ExternalLoginCallbackQueryResponse> Handle(ExternalLoginCallbackQueryRequest request, CancellationToken cancellationToken)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return new ExternalLoginCallbackQueryResponse()
                {
                    Succeeded = false
                };
            }

            //var user = await _userManager.FindByEmailAsync(model.Email);
            //IdentityResult result;

            //if (user != null)
            //{
            //    result = await _userManager.AddLoginAsync(user, info);
            //    if (result.Succeeded)
            //    {
            //        await _signInManager.SignInAsync(user, isPersistent: false);
            //        return RedirectToLocal(returnUrl);
            //    }
            //}
            //else
            //{
            //    model.Principal = info.Principal;
            //    user = _mapper.Map<User>(model);
            //    result = await _userManager.CreateAsync(user);
            //    if (result.Succeeded)
            //    {
            //        result = await _userManager.AddLoginAsync(user, info);
            //        if (result.Succeeded)
            //        {
            //            //TODO: Send an emal for the email confirmation and add a default role as in the Register action
            //            await _signInManager.SignInAsync(user, isPersistent: false);
            //            return RedirectToLocal(returnUrl);
            //        }
            //    }
            //}
            //result.Errors

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if(signInResult.Succeeded)
                return new ExternalLoginCallbackQueryResponse()
                {
                    Succeeded = true,
                    t = request.
                }

            if (signInResult.IsLockedOut)
            {
                return new ExternalLoginCallbackQueryResponse()
                {
                    Succeeded = false,
                    IsLockedOut = signInResult.IsLockedOut
                };
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            return new ExternalLoginCallbackQueryResponse()
            {
                Succeeded = true,
                Email = email
            };
        }
    }
}
