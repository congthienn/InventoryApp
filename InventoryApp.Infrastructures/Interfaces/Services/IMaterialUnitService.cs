using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IMaterialUnitService
    {
        Task<MaterialUnitModelRq> AddMaterialUnit(MaterialUnitModelRq model, UserIdentity userIdentity);
        Task<MaterialUnitModelRq> UpdateMaterialUnit(Guid id, MaterialUnitModelRq model, UserIdentity userIdentity);
        Task<bool> DeleteMaterialUnit(Guid id);
    }
}