using CeremonyBazar.CQRS.Command.Contract;
using CeremonyBazar.CQRS.Command.Impelentation;
using CeremonyBazar.Entity;
using CeremonyBazar.Infrustructure.Identity;
using CeremonyBazar.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CeremonyBazar.Controller
{
    [RoutePrefix("user")]
    public class UserController : BaseApiController
    {
        ICommandExecuter _commandExecuter { get; set; }
        public UserController(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }

        [AllowAnonymous]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(UserRegistartionModel createUserModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                UserName = createUserModel.UserName,
                Password = createUserModel.Password,
                //DOB = null,
                //Address = null,
                //CreatedOn = DateTime.Now,
                //AdditedOn = DateTime.Now
                                
            };
            //switch (createUserModel.UserNameType)
            //{
            //    case Comman.Enum.UserNameTypes.UserName:
            //        break;
            //    case Comman.Enum.UserNameTypes.Mobile:
            //        user.Mobile = createUserModel.UserName;
            //        break;
            //    case Comman.Enum.UserNameTypes.Email:
            //        user.Email = createUserModel.UserName;
            //        break;
            //    default:
            //        break;
            //}

            CreateUserCommand command = new CreateUserCommand() { UserToBeCreated = user };
            _commandExecuter.Enqueue(command);

           
            string code = await AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

            await AppUserManager.SendEmailAsync(user.Id,
                                                    "Confirm your account",
                                                    "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, "User Created Successfully!");

        }

        [Route("ok")]
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult OK()
        {
            //var obj = RequestContext.Configuration.DependencyResolver.GetService(typeof(Repository.Contracts.IUserRepository));

           // _commandExecuter.Enqueue(new CreateUserCommand() { UserToBeCreated = new Entity.User() { UserName = "test", Password = "Test@123"} });
            return Ok("OK");
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}