using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IInventoryDeliveryVoucherRepository : IGenericRepository<InventoryDeliveryVoucher>
    {
        Task<string> GetLastCode();
        Task<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherByCode(string code);
        IEnumerable<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherByCodeByStatus(int status);
        IEnumerable<InventoryDeliveryVoucher> GetInventoryDeliveryVoucherByCodeByPurpose(int purpose);
    }
}