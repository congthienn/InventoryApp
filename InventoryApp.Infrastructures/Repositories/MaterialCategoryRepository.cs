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

        public IEnumerable<MaterialAttribute> GetAllMaterialAttributeByCategoryId(Guid categoryId)
        {
            return _dbSet.Include(x => x.Materials).Where(x => x.Id == categoryId).Select(x => x.MaterialAttributes).FirstOrDefault();
        }

        public IEnumerable<Materials> GetAllMaterialByCategoryId(Guid categoryId)
        {
            return _dbSet.Include(x => x.Materials).Where(x => x.Id == categoryId).Select(x=>x.Materials).FirstOrDefault();
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x => x.CreatedDate).Select(x => x.Code).FirstOrDefault();
        }
    }
}
