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
    public class DeliveryCompanyRepository : GenericRepository<DeliveryCompany>, IDeliveryCompanyRepository
    {
        public DeliveryCompanyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<DeliveryCompany> GetAllDeliveryCompanyByBranchId(Guid branchId)
        {
            return _dbSet.Include(x => x.Branch).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).Where(x => x.BranchId == branchId).OrderByDescending(x => x.UpdatedDate);
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}