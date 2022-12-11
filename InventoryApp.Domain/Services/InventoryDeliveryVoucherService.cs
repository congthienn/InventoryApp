using AutoMapper;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Helper;
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
    public class InventoryDeliveryVoucherService : IInventoryDeliveryVoucherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryDeliveryVoucherRepository _inventoryDeliveryVoucherRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMaterialShipmentRepository _materialShipmentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public InventoryDeliveryVoucherService(IMapper mapper, ILogger<InventoryDeliveryVoucherService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _inventoryDeliveryVoucherRepository = new InventoryDeliveryVoucherRepository(_unitOfWork);
            _orderRepository = new OrderRepository(_unitOfWork);
            _warehouseRepository = new WarehouseRepository(_unitOfWork);
            _materialShipmentRepository = new MaterialShipmentRepository(_unitOfWork);
            _employeeRepository = new EmployeeRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InventoryDeliveryVoucherModel> AddInventoryDeliveryVoucher(InventoryDeliveryVoucherModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                InventoryDeliveryVoucher inventoryDeliveryVoucher = _mapper.Map<InventoryDeliveryVoucher>(model);
                string code = await _inventoryDeliveryVoucherRepository.GetLastCode();
                inventoryDeliveryVoucher.Code = code == null ? "PXK000001" : StringHelper.CreateCode(code);
                inventoryDeliveryVoucher.CreateBy(userIdentity);
                inventoryDeliveryVoucher.UpdateBy(userIdentity);

                await _inventoryDeliveryVoucherRepository.Insert(inventoryDeliveryVoucher);
                Order order = await _orderRepository.GetByID(model.OrderId);
                if (order == null)
                    throw new NotImplementedException("Order not found");
                order.Status++;
                await _orderRepository.Update(order);

                int totalQuantity = 0;

                foreach (var item in model.Details)
                {
                    MaterialShipment materialShipment = _materialShipmentRepository.GetMaterialShipmentByShipmentIdAndMaterialId(item.ShipmentId, item.MaterialId);
                    if (materialShipment == null)
                        throw new NotImplementedException("Material Shipment not found");

                    if (materialShipment.QuantityInStock < item.QuantityDelivery)
                        throw new NotImplementedException("Invalid quantity");

                    materialShipment.QuantityInStock -= item.QuantityDelivery;
                    await _materialShipmentRepository.Update(materialShipment);

                    totalQuantity += item.QuantityDelivery;
                }

                Warehouses warehouses = await _warehouseRepository.GetByID(model.WarehouseId);
                if (warehouses == null)
                    throw new NotImplementedException("Warehouse not found");
                warehouses.Blank += totalQuantity;
                await _warehouseRepository.Update(warehouses);

                _unitOfWork.Save();
                _unitOfWork.Commit();
                return _mapper.Map<InventoryDeliveryVoucherModel>(inventoryDeliveryVoucher);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        
        public IEnumerable<InventoryDeliveryVoucherModel> GetAllInventoryDeliveryVoucher()
        {
            IEnumerable<InventoryDeliveryVoucherModel> inventoryDeliveriesList = _mapper.Map<IEnumerable<InventoryDeliveryVoucherModel>>(_inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucher());
            foreach (var item in inventoryDeliveriesList)
            {
                Employee employee = _employeeRepository.GetEmployeeByUserId(item.CreatedByUserId).Result;
                item.EmployeeName = $"{employee.Code} - {employee.Name}";
            }
            return inventoryDeliveriesList;
        }

        public async Task<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherById(Guid inventoryDeliveryVoucherId)
        {
            return _mapper.Map<InventoryDeliveryVoucherModel>(await _inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucherById(inventoryDeliveryVoucherId));
        }
    }
}
