using CeremonyBazar.CQRS.Command.Contract;
using CeremonyBazar.CQRS.Command.Impelentation;
using CeremonyBazar.LogicLayer.Contract;
using CeremonyBazar.Repository.Contracts;
using CeremonyBazar.Event.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CeremonyBazar.Event.Contract;
using CeremonyBazar.Infrustructure.Identity;

namespace CeremonyBazar.LogicLayer.Implementation
{
    public class UserLogic : IUserLogic,
        ICommandHandler<CreateUserCommand>
    {
        public IUserRepository _userRepository { get; set; }
        private ApplicationUserManager _appUserManager {
            get
            {
                return ApplicationUserManager.Create();
            }
        }

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEvent Execute(CreateUserCommand command)
        {
           
            var result = _appUserManager.CreateAsync(command.UserToBeCreated, command.UserToBeCreated.Password);
            
            return new UserCreatedEvent() { CreatedUser = command.UserToBeCreated };
        }
        
    }
}