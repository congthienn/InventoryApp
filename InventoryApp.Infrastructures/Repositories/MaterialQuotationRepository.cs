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
    public class MaterialQuotationRepository : GenericRepository<MaterialQuotation>, IMaterialQuotationRepository
    {
        public MaterialQuotationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<MaterialQuotation> GetAllMaterialQuotationByMaterialId(Guid materialId)
        {
            return _dbSet.Where(x=>x.MaterialId == materialId);
        }

        public async Task<string> GetLastCode()
        {
            return await _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefaultAsync();
        }

        public async Task<MaterialQuotation> GetMaterialQuotationByCode(string code)
        {
            return await _dbSet.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<MaterialQuotation> GetMaterialQuotationByMaterialIdAndQuantity(Guid materialId, int quantity)
        {
            return await _dbSet.Where(x => x.MaterialId == materialId && x.MinimumQuantity <= quantity && x.MaximumQuantity >= quantity).FirstOrDefaultAsync();
        }
    }
}