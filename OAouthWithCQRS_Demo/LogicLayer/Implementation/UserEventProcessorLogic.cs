using CeremonyBazar.Event.Contract;
using CeremonyBazar.Event.Implementation;
using CeremonyBazar.LogicLayer.Contract;
using CeremonyBazar.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.LogicLayer.Implementation
{
    // All Event Raised related to user operation can be handled here, one Event can be handled in ZERO or MULTIPLE Logic.
    public class UserEventProcessorLogic : IUserEventProcessorLogic,
        IEventProcessor<UserCreatedEvent>
    {
        public bool Process(UserCreatedEvent @event)
        {
            if (@event.CreatedUser == null)
            {
                throw new ArgumentNullException(EventProcessorExceptionMessage.UserInsertedEventProcess_ArgumentNullExceptionMessage);
            }
            return false;
        }
    }
}