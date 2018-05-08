using CeremonyBazar.Entity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using CeremonyBazar.Repository.Contracts;

namespace CeremonyBazar.Infrustructure.Identity
{
    public class ApplicationRoleStore<T> : IRoleStore<ApplicationRole> where T : Role
    {
        private IRoleRepository _rolerRepository { get; set; }
        public ApplicationRoleStore(IRoleRepository roleRepository)
        {
            _rolerRepository = roleRepository;
        }
        public Task CreateAsync(ApplicationRole role)
        {
            return Task.Run(() => _rolerRepository.Add(role));
        }

        public Task DeleteAsync(ApplicationRole role)
        {
            return Task.Run(() => _rolerRepository.Delete(role));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationRole role)
        {
            return Task.Run(() => _rolerRepository.Update(role));
        }
    }
}