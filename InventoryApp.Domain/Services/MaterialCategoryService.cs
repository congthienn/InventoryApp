using AutoMapper;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services
{
    public class MaterialCategoryService : IMaterialCategoryService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialCategoryRepository _materialCategoryRepository;
        public MaterialCategoryService(ILogger<MaterialCategoryService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _materialCategoryRepository = new MaterialCategoryRepository(_unitOfWork);
        }
        public async Task<MaterialCategoryModelRq> AddMaterialCategory(MaterialCategoryModelRq model, UserIdentity userIdentity)
        {
            try
            {
                MaterialsCategory materialsCategory = _mapper.Map<MaterialsCategory>(model);
                string code = await _materialCategoryRepository.GetLastCode();
                materialsCategory.Code = code == null ? "NH000001" : StringHelper.CreateCode(code);
                materialsCategory.CodeName = StringHelper.NormalizeString(model.Name);
                materialsCategory.CreateBy(userIdentity);
                materialsCategory.UpdateBy(userIdentity);

                await _materialCategoryRepository.Insert(materialsCategory);
                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteMaterialCategory(Guid id)
        {
            try
            {
                MaterialsCategory materialsCategory = await _materialCategoryRepository.GetByID(id);
                await _materialCategoryRepository.Delete(materialsCategory);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<MaterialCategoryModelRq> GetAllCategory()
        {
            return _mapper.Map<IEnumerable<MaterialCategoryModelRq>>(_materialCategoryRepository.Get());
        }

        public async Task<MaterialCategoryModelRq> UpdateMaterialCategory(Guid id, MaterialCategoryModelRq model, UserIdentity userIdentity)
        {
            try
            {
                MaterialsCategory materialsCategory = await _materialCategoryRepository.GetByID(id);
                if (materialsCategory == null)
                    throw new NotImplementedException("Material category not found");

                string code = materialsCategory.Code;
                _mapper.Map(model, materialsCategory);
                materialsCategory.Id = id;
                materialsCategory.UpdateBy(userIdentity);
                materialsCategory.Code = code;
                await _materialCategoryRepository.Update(materialsCategory);
                _unitOfWork.Save();

                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
