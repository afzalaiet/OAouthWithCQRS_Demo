using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using CeremonyBazar.Repository.Contracts;
using CeremonyBazar.Repository.Implementation;

namespace CeremonyBazar.Infrustructure.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create()
        {
            // Use Unity to resolve it...
            var appRoleManager = new ApplicationRoleManager(new ApplicationRoleStore<ApplicationRole>(new RoleRepository(new ConnectionFactory())));

            return appRoleManager;
        }
    }
}