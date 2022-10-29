using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Data.Models;
namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IMaterialCategoryRepository : IGenericRepository<MaterialsCategory>
    {
        IEnumerable<Materials> GetAllMaterialByCategoryId(Guid categoryId);
        Task<string> GetLastCode();
        IEnumerable<MaterialAttribute> GetAllMaterialAttributeByCategoryId(Guid categoryId);
    }
}
