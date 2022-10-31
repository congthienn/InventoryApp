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


namespace InventoryApp.Domain.Services
{
    public class WarehouseAreaService : IWarehouseAreaService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseAreaRepository _warehouseAreaRepository;
        public WarehouseAreaService(ILogger<WarehouseAreaService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _warehouseAreaRepository = new WarehouseAreaRepository(_unitOfWork);
        }

        public async Task<WarehouseAreaModel> AddWarehouseArea(WarehouseAreaModel model, UserIdentity userIdentity)
        {
            try
            {
                WarehouseArea warehouseArea = _mapper.Map<WarehouseArea>(model);
                string code = await _warehouseAreaRepository.GetLastCode(model.WarehouseId);
                warehouseArea.Code = code == null ? "KV000001" : StringHelper.CreateCode(code);
                warehouseArea.CreateBy(userIdentity);
                warehouseArea.UpdateBy(userIdentity);
                await _warehouseAreaRepository.Insert(warehouseArea);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseAreaModel>(warehouseArea);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteWarehouseArea(Guid id)
        {
            try
            {
                WarehouseArea warehouseArea = await _warehouseAreaRepository.GetByID(id);
                if (warehouseArea == null)
                    throw new NotImplementedException("Warehouse Area not found");

                await _warehouseAreaRepository.Delete(warehouseArea);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<WarehouseAreaModel> GetWarehouseAreaById(Guid id)
        {
            return _mapper.Map<WarehouseAreaModel>( await _warehouseAreaRepository.GetByID(id));
        }

        public async Task<WarehouseAreaModel> UpdateWarehouseArea(Guid id, WarehouseAreaModel model, UserIdentity userIdentity)
        {
            try
            {
                WarehouseArea warehouseArea = await _warehouseAreaRepository.GetByID(id);
                if (warehouseArea == null)
                    throw new NotImplementedException("Warehouse Area not found");

                string code = warehouseArea.Code;
                _mapper.Map(model, warehouseArea);
                warehouseArea.Id = id;
                warehouseArea.Code = code;
                warehouseArea.UpdateBy(userIdentity);
                await _warehouseAreaRepository.Update(warehouseArea);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseAreaModel>(warehouseArea);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
