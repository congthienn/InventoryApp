using InventoryApp.Data;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Helper;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
           
        }

        public IQueryable<Users> GetDirectorUsers()
        {
            return (IQueryable<Users>)_context.UserRoles.Include(x => x.Role).Where(x => x.Role.Name == ROLE_CONSTANT.DIRECTOR);
        }

        public IQueryable<Users> GetEmployeeUsers()
        {
            return (IQueryable<Users>)_context.UserRoles.Include(x => x.Role).Where(x => x.Role.Name == ROLE_CONSTANT.EMPLOYEE);
        }

        public IQueryable<Users> GetManagerUsers()
        {
            return (IQueryable<Users>)_context.UserRoles.Include(x => x.Role).Where(x => x.Role.Name == ROLE_CONSTANT.MANAGER);
        }

        public async Task<Users> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _dbSet.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }
    }
}
