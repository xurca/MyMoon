using MediatR;
using Microsoft.AspNetCore.Identity;
using MyMoon.Application.Common;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Application.Common.Models;
using MyMoon.Domain.Entities;
using MyMoon.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly IDbContext _context;
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(IDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new User(request.FirstName, request.LastName, request.Gender, request.Email, request.PhoneNumber);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new RegisterUserCommandResponse()
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(e => new Error(e.Code, e.Description)).ToList()
                };
            }

            return new RegisterUserCommandResponse()
            {
                Succeeded = true,
                Id = user.Id
            };
        }
    }
}
