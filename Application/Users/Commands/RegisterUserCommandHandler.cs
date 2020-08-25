using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly IDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserCommandHandler(IDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var newUser = new AppUser()
            {

            };

            //await _userManager.CreateAsync()
            return await Task.FromResult(new RegisterUserCommandResponse());
        }
    }
}
