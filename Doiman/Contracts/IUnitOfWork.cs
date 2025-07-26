using Doiman.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doiman.Contracts
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync();

      IgenricREpo<TEntity, TKey> GetRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
