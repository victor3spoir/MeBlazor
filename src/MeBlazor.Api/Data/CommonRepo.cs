using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeBlazor.Api.Data
{
    public class CommonRepo<T> : ICommonRepo<T> where T: Entity 
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;

        public CommonRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        // public Task Add(T item)
        // {
        //     throw new NotImplementedException();
        // }

        // public void Delete(T item)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<T>? Get(Guid Id)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<IList<T>> GetAll()
        // {
        //     throw new NotImplementedException();
        // }

        // public Task SaveAsync()
        // {
        //     throw new NotImplementedException();
        // }

        // public void Update(Guid Id, T item)
        // {
        //     throw new NotImplementedException();
        // }


        public async Task Add(T item) =>
            await _dbSet.AddAsync(item);


        public void Delete(T item) => _dbSet.Remove(item);


        public async Task<T>? Get(Guid Id)
        {
            return await _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<IList<T>> GetAll() => await _dbSet.ToListAsync();


        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();


        public void Update(Guid Id, T item)
        {
            var _existingItem = _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
            if (_existingItem == null) return;
            _dbSet.Attach(item);
            _dbSet.Entry(item).State = EntityState.Modified;
            throw new NotImplementedException();
        }
    }
}