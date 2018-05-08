using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.CQRS.Command.Contract
{
    public interface ICommandExecuter
    {
        void Enqueue<TCommand>(TCommand command) where TCommand : ICommand;

        // TODO: create the async version too.
    }
}
