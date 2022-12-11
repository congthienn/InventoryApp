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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IReturnedMaterialRepository _returnedMaterialRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public OrderService(IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _orderRepository = new OrderRepository(_unitOfWork);
            _materialRepository = new MaterialRepository(_unitOfWork);
            _returnedMaterialRepository = new ReturnedMaterialRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderModel> AddOrder(OrderModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Order order = _mapper.Map<Order>(model);
                string code = await _orderRepository.GetLastCode();
                order.Code = code == null ? "DH000001" : StringHelper.CreateCode(code);
                int PriceTotal = 0;
                foreach (var orderDetail in order.OrderDetail)
                {
                    var material = await _materialRepository.GetByID(orderDetail.MaterialId);
                    orderDetail.MaterialPrice = material.SalePrice;
                    PriceTotal += material.SalePrice * orderDetail.QuantityRequest;
                }
                order.PriceTotal = PriceTotal;
                order.CreateBy(userIdentity);
                order.UpdateBy(userIdentity);

                await _orderRepository.Insert(order);
             
                _unitOfWork.Save();
                _unitOfWork.Commit();
                return _mapper.Map<OrderModel>(order);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<OrderModel> GetAllOrder()
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.GetAllOrders());
        }

        public IEnumerable<OrderModel> GetAllOrderByStatus(int status)
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.GetOrderByStatus(status));
        }

        public async Task<OrderModel> GetOrderByCode(string code)
        {
            OrderModel orderModel =  _mapper.Map<OrderModel>(await _orderRepository.GetOrderByCode(code));
            orderModel.ReturnedMaterial = _mapper.Map<ReturnedMaterialModel>(await _returnedMaterialRepository.GetReturnedMaterialByOrderId(orderModel.Id));
            return orderModel;
        }

        public async Task<OrderModel> UpdateOrder(string code, OrderModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Order order = await _orderRepository.GetOrderByCode(code);
                if (order == null)
                    throw new NotImplementedException("Order not found");

                if (order.Status == (int)ORDER_STATUS.Delivering || order.Status == (int)ORDER_STATUS.Done)
                    throw new NotImplementedException("Can't update order");

                _mapper.Map(model, order);
                order.Code = code;
                order.UpdateBy(userIdentity);

                await _orderRepository.Update(order);
             
                _unitOfWork.Save();
                _unitOfWork.Commit();
                return _mapper.Map<OrderModel>(order);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
   
        public async Task<OrderModel> UpdateStatusOrder(string code, UserIdentity userIdentity)
        {
            Order order = await _orderRepository.GetOrderByCode(code);
            if (order == null)
                throw new NotImplementedException("Order not found");

            if (order.Status == (int)ORDER_STATUS.Done)
                throw new NotImplementedException("Can't update order");

            if (order.Status > 4)
                throw new NotFiniteNumberException("Can't update order");

            order.Status++;
            order.UpdateBy(userIdentity);
            await _orderRepository.Update(order);
            _unitOfWork.Save();
            return _mapper.Map<OrderModel>(order);
        }

        public async Task<bool> DeleteOrderDetail(int id)
        {
            try
            {
                OrderDetail orderDetail = await _orderRepository.GetOrderDetailById(id);
                if (orderDetail == null)
                    throw new NotImplementedException("Order detail not found");
                await _orderRepository.DeleteOrderDetail(orderDetail);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
            
        }

        public IEnumerable<OrderModel> GetAllOrderByBranchId(Guid branchId)
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.GetAllOrderByBranchId(branchId));
        }

        public IEnumerable<MaterialModelRq> GetAllMaterialOrderByOrderId(int orderId)
        {
            return _mapper.Map<IEnumerable<MaterialModelRq>>(_orderRepository.GetAllMaterialOrderByOrderId(orderId));
        }

        public async Task<OrderModel> UpdateOrderPayment(string code, UserIdentity userIdentity)
        {
            Order order = await _orderRepository.GetOrderByCode(code);
            if (order == null)
                throw new NotImplementedException("Order not found");

            if (order.Status != (int)ORDER_STATUS.Done)
                throw new NotImplementedException("Can't update order");

            order.Paid = true; ;
            order.UpdateBy(userIdentity);
            await _orderRepository.Update(order);
            _unitOfWork.Save();
            return _mapper.Map<OrderModel>(order);
        }

        public async Task<int> GetQuantityRequest(int orderId, Guid materialId)
        {
            return await _orderRepository.GetQuantityRequest(orderId, materialId);
        }

        public async Task AddReturnMaterial(ReturnedMaterialModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                ReturnedMaterial returnedMaterial = _mapper.Map<ReturnedMaterial>(model);
                returnedMaterial.CreateBy(userIdentity);
                returnedMaterial.UpdateBy(userIdentity);
                await _returnedMaterialRepository.Insert(returnedMaterial);
                Order order = await _orderRepository.GetByID(returnedMaterial.OrderId);
                if (order == null)
                    throw new NotImplementedException("Order not found");
                order.Status = (int)ORDER_STATUS.Returned;
                await _orderRepository.Update(order);
                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                _unitOfWork.Rollback();
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<OrderModel> GetOrderListByBranchId(Guid branchId)
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.GetOrderListByBranchId(branchId));
        }
    }
}
