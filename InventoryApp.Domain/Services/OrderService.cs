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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public OrderService(IMapper mapper, ILogger<OrderService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _orderRepository = new OrderRepository(_unitOfWork);
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
            return _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.Get());
        }

        public IEnumerable<OrderModel> GetAllOrderByStatus(int status)
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_orderRepository.GetOrderByStatus(status));
        }

        public async Task<OrderModel> GetOrderByCode(string code)
        {
            return _mapper.Map<OrderModel>(await _orderRepository.GetOrderByCode(code));
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
   
        public async Task<OrderModel> UpdateStatusOrder(string code, OrderStatusModel status, UserIdentity userIdentity)
        {
            Order order = await _orderRepository.GetOrderByCode(code);
            if (order == null)
                throw new NotImplementedException("Order not found");

            if (order.Status == (int)ORDER_STATUS.Delivering || order.Status == (int)ORDER_STATUS.Done)
                throw new NotImplementedException("Can't update order");

            order.Status = status.Status;
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
    }
}
