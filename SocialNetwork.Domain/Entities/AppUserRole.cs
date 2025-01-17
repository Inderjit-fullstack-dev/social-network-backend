﻿using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Domain.Entities
{
    public class AppUserRole : IdentityUserRole<long>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
