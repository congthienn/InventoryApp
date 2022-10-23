using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;


namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ISupplierGroupService
    {
        Task<SupplierGroupModelRq> AddSupplierGroup(SupplierGroupModelRq model, UserIdentity userIdentity);
        IEnumerable<SupplierGroupModelRq> GetAllSupplierGroup();
        Task<SupplierGroupModelRq> UpdateSupplierGroup(Guid supplierGroupId, SupplierGroupModelRq model, UserIdentity userIdentity);
        Task<bool> DeleteSupplierGroup(Guid supplierGroupId);
        IQueryable GetAllSupplierByGroupId(Guid supplierGroupId);
    }
}
