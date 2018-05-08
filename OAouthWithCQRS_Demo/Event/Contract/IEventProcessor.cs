using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.Event.Contract
{
    public interface IEventProcessor<TEvent> where TEvent : IEvent
    {
        bool Process(TEvent @event);
    }
}
