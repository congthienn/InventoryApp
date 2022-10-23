using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class MaterialCategoryRepository : GenericRepository<MaterialsCategory>, IMaterialCategoryRepository
    {
        public MaterialCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable GetAllMaterialByCategoryId(Guid categoryId)
        {
            return _dbSet.Include(x => x.Materials).Where(x => x.Id == categoryId);
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}
