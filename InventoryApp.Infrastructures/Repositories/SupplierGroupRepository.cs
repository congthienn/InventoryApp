using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Interfaces.Repositories;
namespace InventoryApp.Infrastructures.Repositories
{
    public class SupplierGroupRepository : GenericRepository<SupplierGroup>, ISupplierGroupRepository
    {
        public SupplierGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
