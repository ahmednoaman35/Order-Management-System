using Doiman.Contracts;
using Doiman.Entites;
using Presistence.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repo
{
    internal class UnitofWork: IUnitOfWork  
    {
        private readonly ordermangmentDb _db;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public IgenricREpo<TEntity, TKey> GetRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>
       => (IgenricREpo<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name,
                  _ => new GenricRepo<TEntity, TKey>(_db));

        public async Task<int> SaveChangesAsync() => await _db.SaveChangesAsync();

    }
}

