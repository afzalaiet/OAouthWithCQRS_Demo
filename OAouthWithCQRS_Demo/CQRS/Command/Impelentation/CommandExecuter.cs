using CeremonyBazar.CQRS.Command.Contract;
using CeremonyBazar.Event.Implementation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
namespace CeremonyBazar.CQRS.Command.Impelentation
{
    public class CommandExecuter : ICommandExecuter
    {
        public void Enqueue<TCommand>(TCommand command) where TCommand : ICommand
        {
            var obj = DependencyResolver.UnityContainer.Resolve<ICommandHandler<TCommand>>();
            var ReturnedEvent = obj.Execute(command);
            // TODO : handle this event too...
        }
    }
}