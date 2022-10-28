using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IMaterialRepository : IGenericRepository<Materials>
    {
        Task AddMaterialPicture(MaterialPicture materialPicture);
        Task DeleteMaterialPictureById(int materialPictureId);
        Task<MaterialPicture> GetMaterialPictureById(int pictureId);
        Task DeleteAllPictureOfMaterial(Guid materialId);
        Task<Materials> GetMaterialById(Guid materialId);
        Task<string> GetLastCode();
    }
}
