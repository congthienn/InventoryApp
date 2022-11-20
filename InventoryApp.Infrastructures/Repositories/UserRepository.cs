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

        public IEnumerable<Branches> GetBranchByUser(Guid userId)
        {
            return _context.Set<UserBranches>().Include(x => x.Branch).Where(x => x.UserId == userId).Select(x => x.Branch);
        }

        public IEnumerable<Roles> GetRoleByUser(Guid userId)
        {
            return _context.Set<UserRoles>().Include(x=>x.Role).Where(x=>x.UserId == userId).Select(x=>x.Role);
        }
    }
}
