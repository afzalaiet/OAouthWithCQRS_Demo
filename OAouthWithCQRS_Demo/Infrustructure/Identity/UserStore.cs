using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using CeremonyBazar.Repository.Contracts;
using System.Threading;
using CeremonyBazar.Entity;
using System.Security.Claims;
using CeremonyBazar.Repository.Implementation;

namespace CeremonyBazar.Infrustructure.Identity
{
    public class UserStore<T> : IUserStore<User,int> , IUserPasswordStore<User,int>, IUserClaimStore<User, int>, IUserSecurityStampStore<User, int> where T: User
    {
        private IUserRepository _userRepository { get; set; }
        private IClaimRepository _claimRepository { get; set; }
        public UserStore(IUserRepository userRepository, IClaimRepository claimRepository)
        {
            _userRepository = userRepository;
            _claimRepository = claimRepository;
        }


        public Task CreateAsync(User user)
        {
            return Task.Run(() => {
                _userRepository.AddUser(user);
                return Task.FromResult(0);
                });
        
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() => {
                _userRepository.Delete(user as User);
                return Task.FromResult(0);
            });
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public Task<User> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
      
        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Run(() => {
                var user = _userRepository.GetByName(userName).Result;
                return Task.FromResult(user);
            });
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() => _userRepository.Update(user as User));
        }
        #region IUserPasswordStore
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.Password != null);
        }


        #endregion

        #region IUserClaimStore
        public Task<IList<System.Security.Claims.Claim>> GetClaimsAsync(User user)
        {
            var userEnity = user as User; 
           var result = _claimRepository.GetByUserId(userEnity.Id).Select(c => new System.Security.Claims.Claim(c.ClaimType,c.ClaimValue)).ToList();
           return Task.FromResult<IList<System.Security.Claims.Claim>>(result);           
        }

        public Task AddClaimAsync(User user, System.Security.Claims.Claim claim)
        {
            var newClaim = new Entity.Claim() { UserId = user.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
            _claimRepository.Add(newClaim);
            return Task.FromResult(0);
        }

        public Task RemoveClaimAsync(User user, System.Security.Claims.Claim claim)
        {
           
            var newClaim = new Entity.Claim() { UserId = user.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
            _claimRepository.Delete(newClaim);

            return Task.FromResult(0);
        }

        #endregion

        #region IUserSecurityStampStore

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.SecurityStamp);
        }

        
        #endregion
    }
}