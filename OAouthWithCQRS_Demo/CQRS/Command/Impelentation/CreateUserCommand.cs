using CeremonyBazar.CQRS.Command.Contract;
using CeremonyBazar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.CQRS.Command.Impelentation
{
    public class CreateUserCommand : ICommand
    {
        public User UserToBeCreated { get; set; }
    }
}