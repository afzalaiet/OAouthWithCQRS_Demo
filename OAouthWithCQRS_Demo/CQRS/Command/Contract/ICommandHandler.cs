using CeremonyBazar.Event.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.CQRS.Command.Contract
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand 
    {
        IEvent Execute(TCommand command);
    }
}
