using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IMaterialQuotationRepository : IGenericRepository<MaterialQuotation>
    {
        Task<string> GetLastCode();
        Task<MaterialQuotation> GetMaterialQuotationByCode(string code);
        IEnumerable<MaterialQuotation> GetAllMaterialQuotationByMaterialId(Guid materialId);
        Task<MaterialQuotation> GetMaterialQuotationByMaterialIdAndQuantity(Guid materialId, int quantity);
    }
}
