using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using CeremonyBazar.Infrustructure.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using CeremonyBazar.App_Start;
using System.Web.Http;
using Microsoft.Owin.Security;
using CeremonyBazar.Providers;
using Microsoft.Owin.Security.Jwt;

[assembly: OwinStartup(typeof(CeremonyBazar.Startup))]

namespace CeremonyBazar
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            UnityConfig.Register(httpConfig);
            ConfigureOAuthTokenGeneration(app);

            ConfigureOAuthTokenConsumption(app);

            app.UseWebApi(httpConfig);

        }
        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request           
            app.CreatePerOwinContext(ApplicationUserManager.Create);// UserManager
            app.CreatePerOwinContext(ApplicationRoleManager.Create);// RoleManager

            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:59822")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = "http://localhost:59822";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
    }
}
