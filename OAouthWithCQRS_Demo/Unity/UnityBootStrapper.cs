using CeremonyBazar.CQRS.Command.Contract;
using CeremonyBazar.CQRS.Command.Impelentation;
using CeremonyBazar.Infrustructure;
using CeremonyBazar.LogicLayer.Implementation;
using CeremonyBazar.Repository.Contracts;
using CeremonyBazar.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace CeremonyBazar.Unity
{
    public class UnityBootStrapper
    {
        public static IUnityContainer RegisterTypes()
        {
            IUnityContainer container = new UnityContainer();
            // Register all application Types here...
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICommandExecuter, CommandExecuter>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<ICommandHandler<CreateUserCommand>, UserLogic>();
            return container;
        }
    }
}