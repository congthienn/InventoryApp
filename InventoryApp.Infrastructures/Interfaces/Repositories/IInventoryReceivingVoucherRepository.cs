using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IInventoryReceivingVoucherRepository : IGenericRepository<InventoryReceivingVoucher>
    {
        Task<string> GetLastCode();
        IEnumerable<InventoryReceivingVoucher> GetInventoryReceivingVoucherByBranchId(Guid branchId);
        IEnumerable<InventoryReceivingVoucher> GetInventoryReceivingVoucher();
    }
}
