using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ICustomerGroupService
    {
        IEnumerable<CustomerGroupModel> GetAllCustomerGroups();
        Task<CustomerGroupModel> GetCustomerGroupById(Guid id);
        Task<CustomerGroupModel> AddCustomerGroup(CustomerGroupModel model, UserIdentity userIdentity);
        Task<CustomerGroupModel> UpdateCustomerGroup(Guid id, CustomerGroupModel model, UserIdentity userIdentity);
        Task<bool> DeleteCustomerGroup(Guid id);
    }
}
