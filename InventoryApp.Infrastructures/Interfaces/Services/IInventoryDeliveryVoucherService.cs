using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IInventoryDeliveryVoucherService
    {
        IEnumerable<InventoryDeliveryVoucherModel> GetAllInventoryDeliveryVoucher();
        Task<InventoryDeliveryVoucherModel> AddInventoryDeliveryVoucher(InventoryDeliveryVoucherModel model, UserIdentity userIdentity);
        Task<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCode(string code);
        IEnumerable<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCodeByStatus(int status);
        IEnumerable<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCodeByPurpose(int purpose);
        Task<bool> ApproveInventoryDeliveryVoucher(string code, OrderStatusModel statusModel, UserIdentity userIdentity);
        Task<bool> ConfirmGoodsIssueDate(string code, UserIdentity userIdentity);
    }
}