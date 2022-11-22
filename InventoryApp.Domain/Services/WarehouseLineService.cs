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
    public class WarehouseLineService : IWarehouseLineService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseLineRepository _warehouseLineRepository;
        public WarehouseLineService(ILogger<WarehouseLineService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _warehouseLineRepository = new WarehouseLineRepository(_unitOfWork);
        }
        public async Task<WarehouseLineModel> AddWarehouseLine(WarehouseLineModel model, UserIdentity userIdentity)
        {
            try
            {
                WarehouseLine warehouseLine = _mapper.Map<WarehouseLine>(model);
                string code = await _warehouseLineRepository.GetLastCode(model.WarehouseAreaId);
                warehouseLine.Code = code == null ? "H0000001" : StringHelper.CreateCode(code);
                warehouseLine.CreateBy(userIdentity);
                warehouseLine.UpdateBy(userIdentity);
                await _warehouseLineRepository.Insert(warehouseLine);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseLineModel>(warehouseLine);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteWarehouseLine(Guid id)
        {
            try
            {
                WarehouseLine warehouseLine = await _warehouseLineRepository.GetByID(id);
                if (warehouseLine == null)
                    throw new NotImplementedException("WarehouseLine not found");
                await _warehouseLineRepository.Delete(warehouseLine);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<WarehouseLineModel> GetAllWarehouseLine(Guid warehouseAreaId)
        {
            return _mapper.Map<IEnumerable<WarehouseLineModel>>(_warehouseLineRepository.GetAllWarehouseLine(warehouseAreaId));
        }

        public IEnumerable<WarehouseShelveModel> GetAllWarehouseShelve(Guid warehouseLineId)
        {
            return _mapper.Map<IEnumerable<WarehouseShelveModel>>(_warehouseLineRepository.GetAllWarehouseShelve(warehouseLineId));
        }

        public async Task<WarehouseLineModel> GetWarehouseLineById(Guid id)
        {
            return _mapper.Map<WarehouseLineModel>(await _warehouseLineRepository.GetByID(id));
        }

        public async Task<WarehouseLineModel> UpdateWarehouseLine(Guid id, WarehouseLineModel model, UserIdentity userIdentity)
        {
            try
            {
                WarehouseLine warehouseLine = await _warehouseLineRepository.GetByID(id);
                if (warehouseLine == null)
                    throw new NotImplementedException("WarehouseLine not found");

                string code = warehouseLine.Code;
                _mapper.Map(model, warehouseLine);
                warehouseLine.Id = id;
                warehouseLine.Code = code;
                warehouseLine.UpdateBy(userIdentity);
                await _warehouseLineRepository.Update(warehouseLine);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseLineModel>(warehouseLine);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
