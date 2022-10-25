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
    public class MaterialUnitService : IMaterialUnitService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialUnitRepository _materialUnitRepository;

        public MaterialUnitService(ILogger<MaterialUnitService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _materialUnitRepository = new MaterialUnitRepository(_unitOfWork);
        }
        public async Task<MaterialUnitModelRq> AddMaterialUnit(MaterialUnitModelRq model, UserIdentity userIdentity)
        {
            try
            {
                MaterialUnits materialUnit = _mapper.Map<MaterialUnits>(model);
                materialUnit.CreateBy(userIdentity);
                materialUnit.UpdateBy(userIdentity);
                await _materialUnitRepository.Insert(materialUnit);
                _unitOfWork.Save();
                return model;

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteMaterialUnit(Guid id)
        {
            try
            {
                MaterialUnits materialUnits = await _materialUnitRepository.GetByID(id);
                await _materialUnitRepository.Delete(materialUnits);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<MaterialUnitModelRq> UpdateMaterialUnit(Guid id, MaterialUnitModelRq model, UserIdentity userIdentity)
        {
            try
            {
                MaterialUnits materialUnit = await _materialUnitRepository.GetByID(id);
                if (materialUnit == null)
                    throw new NotImplementedException("MaterialUnit not found");

                materialUnit.Id = id;
                materialUnit.UpdateBy(userIdentity);
                await _materialUnitRepository.Update(materialUnit);
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
