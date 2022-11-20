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
    public class WarehouseService : IWarehouseService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(ILogger<WarehouseService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _warehouseRepository = new WarehouseRepository(_unitOfWork);
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<WarehouseModel> AddWarehouse(WarehouseModel model, UserIdentity userIdentity)
        {
            try
            {
                Warehouses warehouse = _mapper.Map<Warehouses>(model);
                string code = await _warehouseRepository.GetLastCode();
                warehouse.Code = code == null ? "KHO00001" : StringHelper.CreateCode(code);
                warehouse.CreateBy(userIdentity);
                warehouse.UpdateBy(userIdentity);
                warehouse.Blank = warehouse.MaximumCapacity;
                await _warehouseRepository.Insert(warehouse);
                _unitOfWork.Save();
                return _mapper.Map<WarehouseModel>(warehouse);
                
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteWarehouse(Guid id)
        {
            try
            {
                Warehouses warehouse = await _warehouseRepository.GetByID(id);
                if (warehouse == null)
                    throw new NotImplementedException("Warehouse not found");
                await _warehouseRepository.Delete(warehouse);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<WarehouseAreaModel> GetAllWarehouseAreas(Guid warehouseId)
        {
            return _mapper.Map<IEnumerable<WarehouseAreaModel>>(_warehouseRepository.GetAllWarehouseAreas(warehouseId));
        }

        public IEnumerable<WarehouseModel> GetAllWarehouseByBranchId(Guid branchId)
        {
            return _mapper.Map<IEnumerable<WarehouseModel>>(_warehouseRepository.GetAllWarehouseByBranchId(branchId));
        }

        public IEnumerable<WarehouseModel> GetAllWarehouses()
        {
            return _mapper.Map<IEnumerable<WarehouseModel>>(_warehouseRepository.GetAllWarehouse());
        }

        public async Task<WarehouseModel> GetWarehouseById(Guid id)
        {
            return _mapper.Map<WarehouseModel>(await _warehouseRepository.GetByID(id));
        }

        public async Task<WarehouseModel> UpdateWarehouse(Guid id, WarehouseModel model, UserIdentity userIdentity)
        {
            try
            {
                Warehouses warehouse = await _warehouseRepository.GetByID(id);
                if (warehouse == null)
                    throw new NotImplementedException("Warehouse not found");
                string code = warehouse.Code;
                _mapper.Map(model, warehouse);
                warehouse.Id = id;
                warehouse.Code = code;
                warehouse.UpdateBy(userIdentity);
                await _warehouseRepository.Update(warehouse);
                _unitOfWork.Save();

                return _mapper.Map<WarehouseModel>(warehouse);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
