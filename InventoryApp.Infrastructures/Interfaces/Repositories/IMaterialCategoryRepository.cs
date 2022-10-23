using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Data.Models;
namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface IMaterialCategoryRepository : IGenericRepository<MaterialsCategory>
    {
        IQueryable GetAllMaterialByCategoryId(Guid categoryId);
        Task<string> GetLastCode();
    }
}
