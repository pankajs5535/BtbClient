using BtbClient.Application.Interfaces.IRepositories;
using BtbClient.Domain.Entities;
using BtbClient.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BtbClient.Persistence.Repositories
{
    public class RawMaterialRepository : GenericRepository<RawMaterial>, IRawMaterialRepository
    {
        public RawMaterialRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<RawMaterial?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.MaterialCode == code);
        }

        public async Task<IEnumerable<RawMaterial>> GetByTypeAsync(string type)
        {
            return await _dbSet.Where(x => x.MaterialType == type && x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<RawMaterial>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.MaterialCode.ToLower().Contains(keyword) ||
                x.MaterialName.ToLower().Contains(keyword) ||
                (x.Grade ?? "").ToLower().Contains(keyword) ||
                (x.Specification ?? "").ToLower().Contains(keyword) ||
                (x.Hsncode ?? "").ToLower().Contains(keyword) ||
                (x.CountryOfOrigin ?? "").ToLower().Contains(keyword) ||
                (x.QualityStandard ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<RawMaterial>> GetActiveAsync()
        {
            return await _dbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<RawMaterial>> GetInactiveAsync()
        {
            return await _dbSet.Where(x => !x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<RawMaterial>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _dbSet.Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate).ToListAsync();
        }

        public async Task<bool> IsMaterialCodeExistsAsync(string materialCode)
        {
            return await _dbSet.AnyAsync(x => x.MaterialCode == materialCode);
        }

        public async Task<IEnumerable<RawMaterial>> GetLowStockAsync()
        {
            return await _dbSet.Where(x => x.CurrentStock <= x.ReorderPoint).ToListAsync();
        }

        public async Task<IEnumerable<RawMaterial>> GetBySupplierAsync(int supplierId)
        {
            return await _dbSet.Where(x => x.PrimarySupplierId == supplierId).ToListAsync();
        }

        public async Task<IEnumerable<RawMaterial>> GetControlledSubstancesAsync()
        {
            return await _dbSet.Where(x => x.IsControlledSubstance).ToListAsync();
        }
    }
}
