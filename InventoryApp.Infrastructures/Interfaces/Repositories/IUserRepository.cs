using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        IQueryable<Users> GetManagerUsers();
        IQueryable<Users> GetDirectorUsers();
        IQueryable<Users> GetEmployeeUsers();
        Task<Users> GetUserByPhoneNumber(string phoneNumber);
    }
}
