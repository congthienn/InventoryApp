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
    public class WarehouseShelveService : IWarehouseShelveService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseShelveRepository _warehouseShelveRepository;
        public WarehouseShelveService(ILogger<WarehouseShelveService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _warehouseShelveRepository = new WarehouseShelveRepository(_unitOfWork);
        }
        public async Task<WarehouseShelveModel> AddWarehouseShelve(WarehouseShelveModel model, UserIdentity userIdentity)
        {
            try
            {
                WarehouseShelves warehouseShelve = _mapper.Map<WarehouseShelves>(model);
                string code = await _warehouseShelveRepository.GetLastCode(model.WarehouseLineId);
                warehouseShelve.Code = code == null ? "KE000001" : StringHelper.CreateCode(code);
                warehouseShelve.CreateBy(userIdentity);
                warehouseShelve.UpdateBy(userIdentity);
                await _warehouseShelveRepository.Insert(warehouseShelve);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseShelveModel>(warehouseShelve);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteWarehouseShelve(Guid id)
        {
            try
            {
                WarehouseShelves warehouseShelve = await _warehouseShelveRepository.GetByID(id);
                if (warehouseShelve == null)
                    throw new NotImplementedException("WarehouseShelves not found");

                _warehouseShelveRepository.Delete(warehouseShelve);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<WarehouseShelveModel> GetWarehouseShelveById(Guid id)
        {
            return _mapper.Map<WarehouseShelveModel>(await _warehouseShelveRepository.GetByID(id));
        }

        public IEnumerable<WarehouseShelveModel> GetWarehouseShelveByWarehouseLineId(Guid warehouseLineId)
        {
            return _mapper.Map<IEnumerable<WarehouseShelveModel>>(_warehouseShelveRepository.GetWarehouseShelveByWarehouseLineId(warehouseLineId));
        }

        public async Task<WarehouseShelveModel> UpdateWarehouseShelve(Guid id, WarehouseShelveModel model, UserIdentity userIdentity)
        {
            try
            {
                WarehouseShelves warehouseShelve = await _warehouseShelveRepository.GetByID(id);
                if (warehouseShelve == null)
                    throw new NotImplementedException("WarehouseShelves not found");

                string code = warehouseShelve.Code;
                _mapper.Map(model, warehouseShelve);
                warehouseShelve.Code = code;
                warehouseShelve.Id = id;
                warehouseShelve.UpdateBy(userIdentity);
                
                await _warehouseShelveRepository.Update(warehouseShelve);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseShelveModel>(warehouseShelve);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
