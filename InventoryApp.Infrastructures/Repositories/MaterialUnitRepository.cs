using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;

namespace InventoryApp.Infrastructures.Repositories
{
    public class MaterialUnitRepository : GenericRepository<MaterialUnits>, IMaterialUnitRepository
    {
        public MaterialUnitRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
