using System.Collections.Generic;

namespace CeremonyBazar.Repository.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllActive();
        IEnumerable<TEntity> GetAllDeActive();
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddMultiple(IEnumerable<TEntity> entityList);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> DeleteMultiple(IEnumerable<TEntity> entityList);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateMultiple(IEnumerable<TEntity> entityList);
    }
}
