using CeremonyBazar.Entity;
using CeremonyBazar.Repository.Implementation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Infrustructure.Identity
{
    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IUserStore<User, int> store) : base(store)
        {

        }

        public static ApplicationUserManager Create()
        {
            // TODO: use container to resolve Store.
            var appUserManager = new ApplicationUserManager(new UserStore<User>(new UserRepository(new ConnectionFactory()), new ClaimRepository(new ConnectionFactory())));

            return appUserManager;
        }
    }
}