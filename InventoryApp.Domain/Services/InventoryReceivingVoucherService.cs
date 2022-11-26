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
    public class InventoryReceivingVoucherService : IInventoryReceivingVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryReceivingVoucherRepository _inventoryReceivingVoucherRepository;
        private readonly ISupplierOrderRepository _supplierOrderRepository;
        private readonly IMaterialShipmentRepository _materialShipmentRepository;
        private readonly IMaterialPositionRepository _materialPositionRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public InventoryReceivingVoucherService(IMapper mapper, ILogger<InventoryReceivingVoucherService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _inventoryReceivingVoucherRepository = new InventoryReceivingVoucherRepository(_unitOfWork);
            _supplierOrderRepository = new SupplierOrderRepository(_unitOfWork);
            _materialPositionRepository = new MaterialPositionRepository(_unitOfWork);
            _warehouseRepository = new WarehouseRepository(_unitOfWork);
            _materialShipmentRepository = new MaterialShipmentRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InventoryReceivingVoucherModel> AddInventoryReceivingVoucher(InventoryReceivingVoucherModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                InventoryReceivingVoucher inventoryReceivingVoucher = _mapper.Map<InventoryReceivingVoucher>(model);
                string code = await _inventoryReceivingVoucherRepository.GetLastCode();
                inventoryReceivingVoucher.Code = code == null ? "PNK000001" : StringHelper.CreateCode(code);
                inventoryReceivingVoucher.CreateBy(userIdentity);
                inventoryReceivingVoucher.UpdateBy(userIdentity);

                await _inventoryReceivingVoucherRepository.Insert(inventoryReceivingVoucher);
                SupplierOrder supplierOrder = await _supplierOrderRepository.GetByID(model.SupplierOrderId);
                supplierOrder.Status++;
                await _supplierOrderRepository.Update(supplierOrder);
                int totalQuantity = 0;
                foreach(var item in model.Detail)
                {
                    totalQuantity += item.QuantityReceiving;
                    MaterialPosition materialPosition = new MaterialPosition()
                    {
                        MaterialId = item.MaterialId,
                        WarehouseShelveId = item.WarehouseShelveId
                    };
                    await _materialPositionRepository.Insert(materialPosition);

                    MaterialShipment materialShipment = new MaterialShipment()
                    {
                        MaterialId = item.MaterialId,
                        ShipmentId = item.ShipmentId,
                        MaterialQuantity = item.QuantityReceiving
                    };
                    materialShipment.CreateBy(userIdentity);
                    materialShipment.UpdateBy(userIdentity);
                    await _materialShipmentRepository.Insert(materialShipment);
                }

                Warehouses warehouse = await _warehouseRepository.GetByID(model.WarehouseId);
                warehouse.Blank -= totalQuantity;
                await _warehouseRepository.Update(warehouse);

                _unitOfWork.Save();
                _unitOfWork.Commit();
                return _mapper.Map<InventoryReceivingVoucherModel>(inventoryReceivingVoucher);
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<InventoryReceivingVoucherModel> GetInventoryReceivingVoucher()
        {
            return _mapper.Map<IEnumerable<InventoryReceivingVoucherModel>>(_inventoryReceivingVoucherRepository.GetInventoryReceivingVoucher());
        }

        public IEnumerable<InventoryReceivingVoucherModel> GetInventoryReceivingVoucherByBranchId(Guid branchId)
        {
            return _mapper.Map<IEnumerable<InventoryReceivingVoucherModel>>(_inventoryReceivingVoucherRepository.GetInventoryReceivingVoucherByBranchId(branchId));
        }
    }
}