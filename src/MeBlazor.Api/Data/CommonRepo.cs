using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeBlazor.Api.Data
{
    public class CommonRepo<T> : IEntityRepo<Entity> where T : Entity
    {
        private readonly DbContext _dbContext;
        private DbSet<Entity> _dbSet;

        public CommonRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Entity>();
        }
        public async Task Add(Entity item)=>
            await _dbSet.AddAsync(item);
        

        public void Delete(Entity item)=>_dbSet.Remove(item);
        

        public async Task<Entity>? Get(Guid Id)
        {
            return await _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<IList<Entity>> GetAll() => await _dbSet.ToListAsync();


        public async Task SaveAsync()=>await _dbContext.SaveChangesAsync();
        

        public void Update(Guid Id, Entity item)
        {
            var _existingItem = _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
            if (_existingItem == null) return;
            _dbSet.Attach( item);
            _dbSet.Entry(item).State=EntityState.Modified;
            throw new NotImplementedException();
        }
    }
}