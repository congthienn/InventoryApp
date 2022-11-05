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

namespace InventoryApp.Domain.Services
{
    public class SupplierOrderService : ISupplierOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierOrderRepository _supplierOrderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SupplierOrderService(IMapper mapper, ILogger<SupplierOrderService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _supplierOrderRepository = new SupplierOrderRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<SupplierOrderModel> AddSupplierOrder(SupplierOrderModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                SupplierOrder supplierOrder = _mapper.Map<SupplierOrder>(model);
                string code = await _supplierOrderRepository.GetLastCode();
                supplierOrder.Code = code == null ? "DDH00001" : StringHelper.CreateCode(code);
                supplierOrder.CreateBy(userIdentity);
                supplierOrder.UpdateBy(userIdentity);
                await _supplierOrderRepository.Insert(supplierOrder);

                _unitOfWork.Save();
                _unitOfWork.Commit();
                return _mapper.Map<SupplierOrderModel>(supplierOrder);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteSupplierOrderDetail(int id)
        {
            try
            {
                SupplierOrderDetail supplierOrderDetail = await _supplierOrderRepository.GetSupplierOrderDetailById(id);
                if (supplierOrderDetail == null)
                    throw new NotImplementedException("Supplier order detail not found");

                await _supplierOrderRepository.DeleteSupplierOrderDetail(supplierOrderDetail);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
        

        public IEnumerable<SupplierOrderModel> GetAllSupplierOrder()
        {
            return _mapper.Map<IEnumerable<SupplierOrderModel>>(_supplierOrderRepository.Get());
        }

        public IEnumerable<SupplierOrderModel> GetAllSupplierOrderByStatus(int status)
        {
            return _mapper.Map<IEnumerable<SupplierOrderModel>>(_supplierOrderRepository.GetSupplierOrderByStatus(status));
        }

        public async Task<SupplierOrderModel> GetSupplierOrderByCode(string code)
        {
            return _mapper.Map<SupplierOrderModel>(await _supplierOrderRepository.GetSupplierOrderByCode(code));
        }

        public async Task<SupplierOrderModel> UpdateStatusSupplierOrder(string code, OrderStatusModel status, UserIdentity userIdentity)
        {
            try
            {
                SupplierOrder supplierOrder = await _supplierOrderRepository.GetSupplierOrderByCode(code);
                if (supplierOrder == null)
                    throw new NotImplementedException("Supplier Order not found");

                supplierOrder.Status = status.Status;
                supplierOrder.UpdateBy(userIdentity);

                await _supplierOrderRepository.Update(supplierOrder);
                _unitOfWork.Save();
                return _mapper.Map<SupplierOrderModel>(supplierOrder);

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<SupplierOrderModel> UpdateSupplierOrder(string code, SupplierOrderModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                SupplierOrder supplierOrder = await _supplierOrderRepository.GetSupplierOrderByCode(code);

                if (supplierOrder == null)
                    throw new NotImplementedException("Supplier Order not found");

                if(supplierOrder.Status != (int)SUPPLIER_ORDER_STATUS.WaitForConfirmation)
                    throw new NotImplementedException("Cann't update supplier order");

                _mapper.Map(model, supplierOrder);
                supplierOrder.Code = code;
                supplierOrder.UpdateBy(userIdentity);

                await _supplierOrderRepository.Update(supplierOrder);
                _unitOfWork.Save();
                _unitOfWork.Commit();
                return _mapper.Map<SupplierOrderModel>(supplierOrder);
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
