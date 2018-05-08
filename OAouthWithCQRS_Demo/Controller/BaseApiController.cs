using CeremonyBazar.Infrustructure.Identity;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;

namespace CeremonyBazar.Controller
{
    public class BaseApiController : ApiController
    {

        private ApplicationRoleManager _AppRoleManager = null;
        private ApplicationUserManager _AppUserManager = null;
        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
    }
}