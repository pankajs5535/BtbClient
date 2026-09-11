using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BtbClient.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Get All
        Task<IEnumerable<T>> GetAllAsync();

        // Get By Id

        Task<T> GetById(int id);

        // Find
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Exists
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

        // Count
        Task<int> CountAsync();

        // Add
        Task AddAsync(T entity);

        // Add Multiple
        Task AddRangeAsync(IEnumerable<T> entites);

        // Update
        Task Update(T entity);

        // Delete
        Task Delete(T entity);

        // Delete Multiple
        Task DeleteRange(IEnumerable<T> entites);


    }
}
