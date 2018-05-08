using CeremonyBazar.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.Repository.Contracts
{
    public interface IClaimRepository : IRepositoryBase<Claim>
    {
        IEnumerable<Claim> GetByUserId(int userId);
    }
}
