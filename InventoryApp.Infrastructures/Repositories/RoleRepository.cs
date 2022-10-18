using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class RoleRepository : GenericRepository<Roles>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable GetUserRole(Guid userId)
        {
            return _context.Set<UserRoles>().Include(x => x.Role).Where(x=>x.UserId == userId).Select(x=>x.Role);
        }
    }
}
