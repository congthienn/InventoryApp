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
    public class ProvinceRepository : GenericRepository<Provinces>, IProvinceRepository
    {
        public ProvinceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IQueryable GetProvinceById(int provinceId)
        {
            return _context.Provinces.Include(x => x.District).Where(x => x.Code == provinceId);
        }

        public async Task<bool> ObjectAlreadyExists(int provinceId)
        {
            return await _dbSet.AnyAsync(x => x.Code == provinceId);
        }

        public async Task<bool> RepositoryIsNotEmpty()
        {
            return await _dbSet.AnyAsync();
        }
    }
}
