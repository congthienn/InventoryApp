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
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Company GetCompanyInformation()
        {
            return _dbSet.Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).FirstOrDefault();
        }

        public async Task<bool> RepositoryIsNotEmpty()
        {
            return await _dbSet.AnyAsync();
        }
    }
}