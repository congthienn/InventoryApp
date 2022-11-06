using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IMaterialQuotationService
    {
        IEnumerable<MaterialQuotationModel> GetAllMaterialQuotationByMaterialId(Guid materialId);
        Task<MaterialQuotationModel> GetMaterialQuotationByMaterialIdAndQuantity(Guid materialId, int quantity);
        Task<MaterialQuotationModel> AddMaterialQuotation(MaterialQuotationModel model, UserIdentity userIdentity);
        Task<MaterialQuotationModel> UpdateMaterialQuotation(string code, MaterialQuotationModel model, UserIdentity userIdentity);
        Task<bool> DeleteMaterialQuotation(string code);
    }
}
