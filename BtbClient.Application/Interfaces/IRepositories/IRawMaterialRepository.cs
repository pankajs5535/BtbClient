using BtbClient.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BtbClient.Application.Interfaces.IRepositories
{
    public interface IRawMaterialRepository:IGenericRepository<RawMaterial>
    {
        // Get Raw Material by Material Code
         public Task<RawMaterial> GetBycodeAsync(string code);


        // Get Raw Materials by Material Type
        public Task<IEnumerable<RawMaterial>> GetByMaterialTypeAsync();

        // Search by Code, Name, Grade, Specification, HSN, Country, Quality Standard
        public Task<IEnumerable<RawMaterial>> SearchByStringAsync(string text);

        // Get Active Raw Materials
        public Task<IEnumerable<RawMaterial>> IsActiveAsync();


        // Get Inactive Raw Materials
        public Task<IEnumerable<RawMaterial>> IsInactive();


        // Get Raw Materials created between two dates
        public Task<IEnumerable<RawMaterial>> FromToDate(string fromDate, string toDate);


        // Check duplicate Material Code
        public Task<IEnumerable<RawMaterial>> CheckDeuplicate(int no);


        // Get Raw Materials below Reorder Point
        public Task<IEnumerable<RawMaterial>> GetByOrder();


        // Get Raw Materials supplied by a specific Supplier
        public Task<IEnumerable<RawMaterial>> SpecificSupplier(string supplier);


        // Get Controlled Substance Raw Materials
        public Task<IEnumerable<RawMaterial>> GetUsb();


    }
}
