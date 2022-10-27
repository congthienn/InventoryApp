using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class MaterialRepository : GenericRepository<Materials>, IMaterialRepository
    {
        private readonly DbSet<MaterialPicture> _dbSetMaterialPictures;
        public MaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbSetMaterialPictures = _context.Set<MaterialPicture>();
        }

        public async Task AddMaterialPicture(MaterialPicture materialPicture)
        {
            await _dbSetMaterialPictures.AddAsync(materialPicture);
        }

        public async Task DeleteAllPictureOfMaterial(Guid materialId)
        {
            List<MaterialPicture> materialPictures = _dbSetMaterialPictures.Where(x=>x.MaterialId == materialId).ToList();
            _dbSetMaterialPictures.RemoveRange(materialPictures);
        }

        public async Task DeleteMaterialPictureById(int materialPictureId)    
        {
            MaterialPicture materialPictures = await _dbSetMaterialPictures.FindAsync(materialPictureId);
            _dbSetMaterialPictures.Remove(materialPictures);
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x=>x.CreatedDate).Select(x=>x.Code).FirstOrDefault();
        }

        public async Task<Materials> GetMaterialById(Guid materialId)
        {
            return await _dbSet.Include(x => x.Pictures).Where(x => x.Id == materialId).FirstOrDefaultAsync();
        }
    }
}
