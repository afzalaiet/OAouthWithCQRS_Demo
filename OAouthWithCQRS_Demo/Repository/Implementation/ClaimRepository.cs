using CeremonyBazar.Entity;
using CeremonyBazar.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CeremonyBazar.Infrustructure;
using Dapper;
using System.Data;

namespace CeremonyBazar.Repository.Implementation
{
    public class ClaimRepository : BaseRepository<Claim>, IClaimRepository
    {
        IConnectionFactory _connectionFactory;
        private const string getClaimByName_query = "select * from [Claim] where userid = ";
        private const string proc_account_deleteClaimBy_UserId_Type_Value = "account_deleteClaimBy_UserId_Type_Value";

        public ClaimRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Claim> GetByUserId(int userId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return SqlMapper.QueryAsync<Claim>(connection, getClaimByName_query + userId).Result;
            }
        }

        public override Claim Delete(Claim entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var param = new DynamicParameters();
                param.Add("@UserId", entity.UserId);
                param.Add("@ClaimType", entity.ClaimType);
                param.Add("@ClaimValue", entity.ClaimValue);

                var result = connection.Execute(proc_account_deleteClaimBy_UserId_Type_Value, param, commandType: CommandType.StoredProcedure);
            }

            return null;
        }
    }
}