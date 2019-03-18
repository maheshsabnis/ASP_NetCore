using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebApp.Repositories
{
    /// <summary>
    /// TEnntity will always be class
    /// TPk will always be an input parameter
    /// CRUD Methods
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IRepository<TEntity,in TPk> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPk id);
        TEntity Create(TEntity entity);
        bool Update(TPk id, TEntity entity);
        bool Delete(TPk id);
    }
}
