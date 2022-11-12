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

        public IEnumerable<Shipment> GetAllShipmentByBranch(Guid branchId)
        {
            return _dbSet.Include(x => x.Shipments).Where(x => x.Id == branchId).Select(x=>x.Shipments).FirstOrDefault();
        }

        public async Task<Branches> GetBranchByCode(string code)
        {
            return await _dbSet.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }

        public async Task<bool> MainBranchAlreadyExists()
        {
            return await _dbSet.AnyAsync(x => x.BranchMain);
        }
    }
}
