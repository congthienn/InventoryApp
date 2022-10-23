using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ISupplierGroupService
    {
        Task<SupplierGroupModelRq> AddSupplierGroup(SupplierGroupModelRq model, UserIdentity userIdentity);
        IEnumerable<SupplierGroupModelRq> GetAllSupplierGroup();
        Task<SupplierGroupModelRq> UpdateSupplierGroup(Guid supplierGroupId, SupplierGroupModelRq model, UserIdentity userIdentity);
        Task<bool> DeleteSupplierGroup(Guid supplierGroupId);
    }
}
