using CeremonyBazar.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Infrustructure.Identity
{
    public class ApplicationRole : Role, IRole<string>
    {
        string IRole<string>.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IRole<string>.Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}