using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllCustomers();
        Task<CustomerModel> GetCustomerById(Guid id);
        Task<CustomerModel> AddCustomer(CustomerModel model, UserIdentity userIdentity);
        Task<CustomerModel> UpdateCustomer(Guid id, CustomerModel model, UserIdentity userIdentity);
        Task<bool> DeleteCustomer(Guid id);
    }
}
