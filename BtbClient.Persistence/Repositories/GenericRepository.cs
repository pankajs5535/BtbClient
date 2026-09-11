using BtbClient.Application.Interfaces.IRepositories;
using BtbClient.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BtbClient.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get All
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Get By Id
        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Find
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        // Exists
        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        // Count
        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        // Add
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Add Multiple
        public virtual async Task AddRangeAsync(IEnumerable<T> entites)
        {
            await _dbSet.AddRangeAsync(entites);
        }

        // Update
        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }


        public virtual async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        // Delete Multiple
        public virtual async Task DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }


    }

}
