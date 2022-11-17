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
        private readonly DbSet<MaterialAttributeValue> _dbSetMaterialAttributeValue;
        private readonly DbSet<MaterialPosition> _dbMaterialPosition;
        public MaterialRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbSetMaterialPictures = _context.Set<MaterialPicture>();
            _dbSetMaterialAttributeValue = _context.Set<MaterialAttributeValue>();
            _dbMaterialPosition = _context.Set<MaterialPosition>();
        }

        public async Task AddMaterialAttributeValue(MaterialAttributeValue materialAttributeValue)
        {
            await _dbSetMaterialAttributeValue.AddAsync(materialAttributeValue);
        }

        public async Task AddMaterialPicture(MaterialPicture materialPicture)
        {
            await _dbSetMaterialPictures.AddAsync(materialPicture);
        }

        public async Task AddMaterialPosition(MaterialPosition materialPosition)
        {
            _dbMaterialPosition.Add(materialPosition);
        }

        public async Task DeleteAllMaterialAttributeValueByMaterialId(Guid materialId)
        {
            IEnumerable<MaterialAttributeValue> materialAttributeValues = GetMaterialAttributeValueList(materialId);
            _dbSetMaterialAttributeValue.RemoveRange(materialAttributeValues);
        }

        public async Task DeleteAllPictureOfMaterial(Guid materialId)
        {
            List<MaterialPicture> materialPictures = _dbSetMaterialPictures.Where(x=>x.MaterialId == materialId).ToList();
            _dbSetMaterialPictures.RemoveRange(materialPictures);
        }

        public async Task DeleteMaterialAttributeValue(MaterialAttributeValue materialAttributeValue)
        {
           _dbSetMaterialAttributeValue.Remove(materialAttributeValue);
        }

        public async Task DeleteMaterialPictureById(int materialPictureId)    
        {
            MaterialPicture materialPictures = await GetMaterialPictureById(materialPictureId);
            _dbSetMaterialPictures.Remove(materialPictures);
        }

        public async Task DeleteMaterialPositionById(MaterialPosition materialPosition)
        {
            _dbMaterialPosition.Remove(materialPosition);
        }

        public IEnumerable<Materials> GetAllMaterials()
        {
            return _dbSet.Include(x => x.Trademark).Include(x => x.CategoryMaterial).OrderByDescending(x=>x.UpdatedDate).ToList();
        }

        public async Task<string> GetLastCode()
        {
            return _dbSet.OrderByDescending(x=>x.CreatedDate).Select(x=>x.Code).FirstOrDefault();
        }

        public async Task<MaterialAttributeValue> GetMaterialAttributeValue(Guid materialId, int materialAttributeId)
        {
            return await _dbSetMaterialAttributeValue.Where(x => x.MaterialId == materialId && x.MaterialAttributeId == materialAttributeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MaterialAttributeValue>> GetMaterialAttributeValue(Guid materialId)
        {
            return await _dbSetMaterialAttributeValue.Include(x=>x.MaterialAttribute).Where(x=>x.MaterialId == materialId).ToListAsync();
        }

        public IEnumerable<MaterialAttributeValue> GetMaterialAttributeValueList(Guid materialId)
        {
            return _dbSetMaterialAttributeValue.Where(x => x.MaterialId == materialId);
        }

        public async Task<Materials> GetMaterialById(Guid materialId)
        {
            return await _dbSet.Include(x => x.Pictures).Where(x => x.Id == materialId).FirstOrDefaultAsync();
        }

        public async Task<MaterialPicture> GetMaterialPictureById(int pictureId)
        {
            return await _dbSetMaterialPictures.FindAsync(pictureId);
        }

        public async Task<MaterialPosition> GetMaterialPositionById(int id)
        {
            return await _dbMaterialPosition.FindAsync(id);
        }

        public async Task UpdateMaterialAttributeValue(MaterialAttributeValue materialAttributeValue)
        {
            _dbSetMaterialAttributeValue.Update(materialAttributeValue);
        }
    }
}
