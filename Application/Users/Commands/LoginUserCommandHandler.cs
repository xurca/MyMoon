using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Application.Common.Models;
using MyMoon.Domain.UserManagement;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace MyMoon.Application.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        public LoginUserCommandHandler(IDbContext context, UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginUserCommandResponse();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var config = _configuration.GetSection("JWTTokenSettings");
                var validIssuer = config.GetValue<string>("ValidIssuer");
                var validAudience = config.GetValue<string>("ValidAudience");
                var key = config.GetValue<string>("Key");

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var token = new JwtSecurityToken(
                    issuer: validIssuer,
                    audience: validAudience,
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FullName)
                    },
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256));

                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                var res = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
                //await _signInManager.SignInAsync(user, request.RememberMe);

                response.AccessToken = accessToken;
                response.Succeeded = true;
            }
            else
                response.Errors.Add(new Error("UserNotFound", "User not found"));

            return response;
        }
    }
}