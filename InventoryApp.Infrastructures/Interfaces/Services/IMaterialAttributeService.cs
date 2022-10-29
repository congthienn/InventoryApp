using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IMaterialAttributeService
    {
        Task<MaterialAttributeModel> AddMaterialAttribute(MaterialAttributeModel model, UserIdentity userIdentity);
        Task<MaterialAttributeModel> UpdateMaterialAttribute(int id, MaterialAttributeModel model, UserIdentity userIdentity);
        Task<bool> DeleteMaterialAttribute(int id);
    }
}