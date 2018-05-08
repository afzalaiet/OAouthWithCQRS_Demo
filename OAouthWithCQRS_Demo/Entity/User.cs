using Microsoft.AspNet.Identity;
using System;
using CeremonyBazar.Infrustructure.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace CeremonyBazar.Entity
{
    public class User : BaseEntity , IUser<int>
    {
        public string UserName { get; set; }        
        public string Password { get; set; }       
        public bool IsActive { get; set; }
        public bool IsTwofactorAuthenticated { get; set; }
        public int RoleId { get; set; }
        public DateTime? LastLogin { get; set; }

        [Write(false)]
        public string SecurityStamp { get; set; }

        internal async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager, string authenticationType)
        {
            var userIdentity = await userManager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here

            return userIdentity;
        }


    }
}