using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeBlazor.Shared.Entities;

namespace MeBlazor.Shared.Repo
{
    public interface IEntityRepo<T> where T : Entity
    {
        Task<IList<T>> GetAll();
        Task<T>? Get(Guid Id);
        Task Add(T item);
        void Delete(T item);
        void Update(Guid Id, T item);
        Task SaveAsync();
    }
}