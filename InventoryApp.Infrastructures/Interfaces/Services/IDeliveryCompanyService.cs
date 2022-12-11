using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IDeliveryCompanyService
    {
        Task<DeliveryCompanyModel> AddDeliveryCompany(DeliveryCompanyModel model, UserIdentity userIdentity);
        IEnumerable<DeliveryCompanyModel> GetAllDeliveryCompanyByBranchId(Guid branchId);
    }
}
