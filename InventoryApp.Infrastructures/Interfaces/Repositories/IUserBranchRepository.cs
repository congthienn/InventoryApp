﻿using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IUserBranchRepository : IGenericRepository<UserBranches>
    {
        IEnumerable<string> GetAllUsersOfTheBranch(Guid branchId);
        IEnumerable<string> GetAllBranchOfTheUser(Guid userId);
        IEnumerable<Guid> GetAllBranchByUserId(Guid userId);
    }
}
