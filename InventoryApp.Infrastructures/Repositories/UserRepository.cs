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

        public IQueryable GetRoleByUser(Guid userId)
        {
            return _context.Set<UserRoles>().Include(x=>x.Role).Where(x=>x.UserId == userId).Select(x=>x.Role.Name);
        }
    }
}
