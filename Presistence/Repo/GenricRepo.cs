using Doiman.Contracts;
using Doiman.Entites;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repo
{
    public class GenricRepo<TEntity,TKey> : IgenricREpo<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ordermangmentDb _db;

        public GenricRepo(ordermangmentDb context)
        {
            _db = context;
        }

        public async Task AddAsync(TEntity entity) => await _db.Set<TEntity>().AddAsync(entity);


        public  void Delete(TEntity entity)=>  _db.Set<TEntity>().Remove(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
          => trackChanges ? await _db.Set<TEntity>().AsNoTracking().ToListAsync() :
            await _db.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetAsync(TKey id)=>await _db.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity)=>_db.Set<TEntity>().Update(entity);

    }
}
