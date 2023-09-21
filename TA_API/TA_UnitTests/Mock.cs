using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_UnitTests
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }

    public class Mock<T> : IRepository<T>
    {
        private List<T> _data = new List<T>();

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(_data.FirstOrDefault());
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_data.AsEnumerable());
        }

        public async Task AddAsync(T entity)
        {
            _data.Add(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.CompletedTask;
        }
    }
}
