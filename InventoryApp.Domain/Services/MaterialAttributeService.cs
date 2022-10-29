using AutoMapper;
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
    public class MaterialAttributeService : IMaterialAttributeService
    {
        private readonly IMaterialAttributeRepository _materialAttributeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MaterialAttributeService(ILogger<MaterialAttributeService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _materialAttributeRepository = new MaterialAttributeRepository(_unitOfWork);
        }

        public async Task<MaterialAttributeModel> AddMaterialAttribute(MaterialAttributeModel model, UserIdentity userIdentity)
        {
            try
            {
                MaterialAttribute materialAttribute = _mapper.Map<MaterialAttribute>(model);
                materialAttribute.CreateBy(userIdentity); materialAttribute.UpdateBy(userIdentity);

                await _materialAttributeRepository.Insert(materialAttribute);
                _unitOfWork.Save();
                return _mapper.Map<MaterialAttributeModel>(materialAttribute);
                
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteMaterialAttribute(int id)
        {
            try
            {
                MaterialAttribute materialAttribute = await _materialAttributeRepository.GetByID(id);
                if (materialAttribute == null)
                    throw new NotImplementedException("Material Attribute not found");
                
                await _materialAttributeRepository.Delete(materialAttribute);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<MaterialAttributeModel> UpdateMaterialAttribute(int id, MaterialAttributeModel model, UserIdentity userIdentity)
        {
            try
            {
                MaterialAttribute materialAttribute = await _materialAttributeRepository.GetByID(id);
                if(materialAttribute == null)
                    throw new NotImplementedException("Material Attribute not found");

                _mapper.Map(model, materialAttribute);

                materialAttribute.MaterialAttributeId = id;
                materialAttribute.UpdateBy(userIdentity);

                await _materialAttributeRepository.Update(materialAttribute);
                _unitOfWork.Save();

                return model;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
