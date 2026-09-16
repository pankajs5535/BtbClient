using BtbClient.Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BtbClient.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IRawMaterialRepository RawMaterials { get; }

        Task<int> SaveChangesAsync();

    }
}
