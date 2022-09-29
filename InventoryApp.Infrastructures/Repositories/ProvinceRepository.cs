using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class ProvinceRepository : GenericRepository<Provinces>, IProvinceRepository
    {
        public ProvinceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
