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
    public class UserBranchRepository : GenericRepository<UserBranches>, IUserBranchRepository
    {
        public UserBranchRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<string> GetAllBranchOfTheUser(Guid userId)
        {
            return _dbSet.Include(x => x.User).Where(x => x.UserId == userId).Select(x => x.Branch.CompanyName);
        }

        public IEnumerable<string> GetAllUsersOfTheBranch(Guid branchId)
        {
            return _dbSet.Include(x => x.User).Where(x => x.BranchId == branchId).Select(x => x.User.UserName);
        }
    }
}
