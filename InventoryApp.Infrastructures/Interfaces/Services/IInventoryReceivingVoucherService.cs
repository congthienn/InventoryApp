using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IInventoryReceivingVoucherService
    {
        Task<InventoryReceivingVoucherModel> AddInventoryReceivingVoucher(InventoryReceivingVoucherModel model, UserIdentity userIdentity);
        IEnumerable<InventoryReceivingVoucherModel> GetInventoryReceivingVoucherByBranchId(Guid branchId);
        IEnumerable<InventoryReceivingVoucherModel> GetInventoryReceivingVoucher();
    }
}
