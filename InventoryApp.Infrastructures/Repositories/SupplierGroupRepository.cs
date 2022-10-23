using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class SupplierGroupRepository : GenericRepository<SupplierGroup>, ISupplierGroupRepository
    {
        public SupplierGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable GetAllSupplierByGroupId(Guid groupSupplierId)
        {
            return _dbSet.Include(x=>x.Suppliers).Where(x=>x.Id == groupSupplierId).Select(x=>x.Suppliers);
        }
    }
}
