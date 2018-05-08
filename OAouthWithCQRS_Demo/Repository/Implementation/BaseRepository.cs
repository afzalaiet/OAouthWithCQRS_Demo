using CeremonyBazar.Infrustructure;
using CeremonyBazar.Repository.Contracts;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CeremonyBazar.Event.Contract;
using CeremonyBazar.Entity;

namespace CeremonyBazar.Repository.Implementation
{
    public abstract class some : IDisposable
    {
        public abstract void Dispose();
        
    }
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        IConnectionFactory _connectionFactory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #region Query 
        public virtual TEntity Get(int Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {                 
                return connection.Get<TEntity>(Id);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {                 
                return connection.GetAll<TEntity>();
            }
        }

        public IEnumerable<TEntity> GetAllActive()
        {
            using (var connection = _connectionFactory.GetConnection)
            {                 
                return connection.Query<TEntity>(Query.Query.GetAllActive);
            }
        }

        public IEnumerable<TEntity> GetAllDeActive()
        {
            using (var connection = _connectionFactory.GetConnection)
            {                 
                return connection.Query<TEntity>(Query.Query.GetAllDeactive);
            }
        }
        #endregion

        #region Command
        public virtual TEntity Add(TEntity entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Insert(entity);
                return entity;
            }
        }
        public IEnumerable<TEntity> AddMultiple(IEnumerable<TEntity> entityList)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Insert(entityList);
                return entityList;
            }
        }

        public virtual TEntity Delete(TEntity entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Delete(entity);
                return entity;
            }
        }

        public IEnumerable<TEntity> DeleteMultiple(IEnumerable<TEntity> entityList)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Delete(entityList);
                return entityList;
            }
        }
        public virtual TEntity Update(TEntity entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Update(entity);
                return entity;
            }
        }
        public virtual IEnumerable<TEntity> UpdateMultiple(IEnumerable<TEntity> entityList)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Update(entityList);
                return entityList;
            }
        }
        #endregion
    }
}