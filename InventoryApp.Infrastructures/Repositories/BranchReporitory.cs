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
    public class BranchReporitory : GenericRepository<Branches>, IBranchRepository
    {
        public BranchReporitory(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable GetAllShipmentByBranch(Guid branchId)
        {
            return _dbSet.Include(x => x.Shipments).Where(x => x.Id == branchId).Select(x=>x.Shipments);
        }

        public async Task<bool> MainBranchAlreadyExists()
        {
            return await _dbSet.AnyAsync(x => x.BranchMain);
        }
    }
}
