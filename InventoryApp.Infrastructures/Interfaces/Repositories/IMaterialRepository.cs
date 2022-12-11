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

        Task AddMaterialAttributeValue(MaterialAttributeValue materialAttributeValue);
        Task UpdateMaterialAttributeValue(MaterialAttributeValue materialAttributeValue);
        Task<MaterialAttributeValue> GetMaterialAttributeValue(Guid materialId, int materialAttributeId);
        Task DeleteMaterialAttributeValue(MaterialAttributeValue materialAttributeValue); 
        IEnumerable<MaterialAttributeValue> GetMaterialAttributeValueList(Guid materialId);
        Task DeleteAllMaterialAttributeValueByMaterialId(Guid materialId);
        Task<IEnumerable<MaterialAttributeValue>> GetMaterialAttributeValue(Guid materialId);

        Task AddMaterialPosition(MaterialPosition materialPosition);
        Task DeleteMaterialPositionById(MaterialPosition materialPosition);

        Task<MaterialPosition> GetMaterialPositionById(int id);
        IEnumerable<Materials> GetAllMaterials();
        IEnumerable<Materials> RelatedMaterial(Guid caterogyId, Guid materialId);
    }
}
