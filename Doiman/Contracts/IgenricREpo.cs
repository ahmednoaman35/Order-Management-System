using Doiman.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doiman.Contracts
{
    public interface IgenricREpo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);


     
        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

    }
}
