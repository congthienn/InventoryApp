using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class WardRepository : GenericRepository<Wards>, IWardRepository
    {
        public WardRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
