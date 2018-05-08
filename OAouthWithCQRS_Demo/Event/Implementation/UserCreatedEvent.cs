using CeremonyBazar.Entity;
using CeremonyBazar.Event.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Event.Implementation
{
    public class UserCreatedEvent : IEvent
    {
        public User CreatedUser { get; set; }
    }
}