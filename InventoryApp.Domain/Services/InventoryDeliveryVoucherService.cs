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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public InventoryDeliveryVoucherService(IMapper mapper, ILogger<InventoryDeliveryVoucherService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _inventoryDeliveryVoucherRepository = new InventoryDeliveryVoucherRepository(_unitOfWork);
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

        public async Task<bool> ApproveInventoryDeliveryVoucher(string code, OrderStatusModel statusModel ,UserIdentity userIdentity)
        {
            try
            {
                InventoryDeliveryVoucher inventoryDeliveryVoucher = await _inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucherByCode(code);
                if (inventoryDeliveryVoucher == null)
                    throw new NotImplementedException("InventoryDeliveryVoucher not found");

                inventoryDeliveryVoucher.UserApproveId = userIdentity.Id;
                inventoryDeliveryVoucher.Status = statusModel.Status;
                inventoryDeliveryVoucher.UpdateBy(userIdentity);
                
                await _inventoryDeliveryVoucherRepository.Update(inventoryDeliveryVoucher);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> ConfirmGoodsIssueDate(string code, UserIdentity userIdentity)
        {
            try
            {
                InventoryDeliveryVoucher inventoryDeliveryVoucher = await _inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucherByCode(code);
                if (inventoryDeliveryVoucher == null)
                    throw new NotImplementedException("InventoryDeliveryVoucher not found");

                inventoryDeliveryVoucher.UpdateBy(userIdentity);
                inventoryDeliveryVoucher.GoodsIssueDate = inventoryDeliveryVoucher.UpdatedDate;

                await _inventoryDeliveryVoucherRepository.Update(inventoryDeliveryVoucher);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<InventoryDeliveryVoucherModel> GetAllInventoryDeliveryVoucher()
        {
            return _mapper.Map<IEnumerable<InventoryDeliveryVoucherModel>>(_inventoryDeliveryVoucherRepository.Get());
        }

        public async Task<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCode(string code)
        {
            return _mapper.Map<InventoryDeliveryVoucherModel>(await _inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucherByCode(code));
        }

        public IEnumerable<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCodeByPurpose(int purpose)
        {
            return _mapper.Map<IEnumerable<InventoryDeliveryVoucherModel>>(_inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucherByCodeByPurpose(purpose));
        }

        public IEnumerable<InventoryDeliveryVoucherModel> GetInventoryDeliveryVoucherByCodeByStatus(int status)
        {
            return _mapper.Map<IEnumerable<InventoryDeliveryVoucherModel>>(_inventoryDeliveryVoucherRepository.GetInventoryDeliveryVoucherByCodeByStatus(status));
        }
    }
}
