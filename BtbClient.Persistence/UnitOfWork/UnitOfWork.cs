using BtbClient.Application.Interfaces.IRepositories;
using BtbClient.Application.Interfaces.IUnitOfWork;
using BtbClient.Persistence.Data;
using BtbClient.Persistence.Repositories;

namespace BtbClient.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRawMaterialRepository RawMaterials { get; }

        public UnitOfWork(ApplicationDbContext context,IRawMaterialRepository rawMaterialRepository)
        {
            _context = context;
            RawMaterials = new RawMaterialRepository(context);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}