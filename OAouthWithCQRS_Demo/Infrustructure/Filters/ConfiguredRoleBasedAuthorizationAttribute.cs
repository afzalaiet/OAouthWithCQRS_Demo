using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Configuration;

namespace AspNetIdentity.WebApi.Infrastructure
{

    public class ConfiguredRoleBasedAuthorizationAttribute : AuthorizeAttribute
    {
      
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }
            // ConfigurationManager.AppSettings["Roles"] == "Admin|SuperAdmin|ExternalUser"
            if (!principal.Claims.Any(r => ConfigurationManager.AppSettings["Roles"].Contains(r.Value)))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }
            base.OnAuthorizationAsync(actionContext, cancellationToken);
            //User is Authorized, complete execution
            return Task.FromResult<object>(null);

        }

        
    }
}