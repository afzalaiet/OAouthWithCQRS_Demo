using CeremonyBazar.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CeremonyBazar.Infrustructure.Identity
{
    public class ApplicationUser : User, IUser<int>
    {
        public static ApplicationUser Clone(User _user)
        {
            if (_user == null)
            {
                return null;
            }
            ApplicationUser appUser = new ApplicationUser();
            appUser.Address = _user.Address;
            appUser.CreatedOn = _user.CreatedOn;
            appUser.DOB = _user.DOB;
            appUser.Email = _user.Email;
            appUser.Gender = _user.Gender;
            (appUser as User).Id = _user.Id;
            appUser.IsActive = _user.IsActive;
            appUser.IsEmailVerified = _user.IsEmailVerified;
            appUser.IsMobileVerified = _user.IsMobileVerified;
            appUser.Mobile = _user.Mobile;
            appUser.UserName = _user.Name;
            appUser.FullName = _user.FullName;
            appUser.Password = _user.Password;
            appUser.ProfilePicUrl = _user.ProfilePicUrl;
            appUser.AdditedOn = _user.AdditedOn;
            appUser.CreatedOn = _user.CreatedOn;

            return appUser;

        }

        public static User Clone(ApplicationUser _applicationUser)
        {
            if (_applicationUser == null)
            {
                return null;
            }
            User user = new User();
            user.Address = _applicationUser.Address;
            user.CreatedOn = _applicationUser.CreatedOn;
            user.DOB = _applicationUser.DOB;
            user.Email = _applicationUser.Email;
            user.Gender = _applicationUser.Gender;
            user.Id =  (_applicationUser as User).Id;
            user.IsActive = _applicationUser.IsActive;
            user.IsEmailVerified = _applicationUser.IsEmailVerified;
            user.IsMobileVerified = _applicationUser.IsMobileVerified;
            user.Mobile = _applicationUser.Mobile;
            user.Name = _applicationUser.UserName;
            user.FullName = _applicationUser.FullName;
            user.Password = _applicationUser.Password;
            user.ProfilePicUrl = _applicationUser.ProfilePicUrl;
            user.AdditedOn = _applicationUser.AdditedOn;
            user.CreatedOn = _applicationUser.CreatedOn;

            return user;

        }
        public string Id
        {
            get
            {
                return Convert.ToString(base.Id);
            }
        }

        public string UserName
        {
            get;

            set;
        }

        public string SecurityStamp { get; set; }

        internal async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager, string authenticationType)
        {
            var userIdentity = await userManager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here

            return userIdentity;
        }
    }
}