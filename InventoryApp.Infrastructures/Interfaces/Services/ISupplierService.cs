using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<SupplierModelRq> AddSupplier(SupplierModelRq model, UserIdentity userIdentity);
        IEnumerable<SupplierModelRq> GetAllSuppliers();
        Task<SupplierModelRq> UpdateSupplier(Guid id, SupplierModelRq model, UserIdentity userIdentity);
        Task<bool> DeleteSupplier(Guid supplierId);
    }
}
