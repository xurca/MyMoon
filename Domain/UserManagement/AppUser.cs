using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.UserManagement
{
    public class AppUser : IdentityUser<int>
    {
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
    }

    public class UserRole : IdentityUserRole<int>
    {
        public virtual Role Role { get; set; }
        public virtual AppUser User { get; set; }
    }

    public class UserToken : IdentityUserToken<int>
    {
    }
}
