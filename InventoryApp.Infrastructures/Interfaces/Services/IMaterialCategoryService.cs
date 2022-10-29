using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IMaterialCategoryService
    {
        IEnumerable<MaterialCategoryModelRq> GetAllCategory();
        Task<MaterialCategoryModelRq> AddMaterialCategory(MaterialCategoryModelRq model, UserIdentity userIdentity);
        Task<MaterialCategoryModelRq> UpdateMaterialCategory(Guid id, MaterialCategoryModelRq model, UserIdentity userIdentity);
        Task<bool> DeleteMaterialCategory(Guid id);
        IEnumerable<ShowMaterialModel> GetAllMaterialByCategoryId(Guid categoryId);
        IEnumerable<MaterialAttributeModel> GetAllMaterialAttributeByCategoryId(Guid categoryId);
    }
}
