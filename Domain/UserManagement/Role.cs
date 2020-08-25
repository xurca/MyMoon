using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.UserManagement
{
    public class Role : IdentityRole<int>
    {
    }

    public class RoleClaim : IdentityRoleClaim<int>
    {
    }
}
