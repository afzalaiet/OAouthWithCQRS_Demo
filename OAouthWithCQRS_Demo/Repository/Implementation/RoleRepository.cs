using CeremonyBazar.Entity;
using CeremonyBazar.Infrustructure;
using CeremonyBazar.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Repository.Implementation
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}