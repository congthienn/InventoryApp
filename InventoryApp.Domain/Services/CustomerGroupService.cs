using AutoMapper;
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
    public class CustomerGroupService : ICustomerGroupService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICustomerGroupRepository _customerGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerGroupService(IMapper mapper, ILogger<CustomerGroupService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _customerGroupRepository = new CustomerGroupRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<CustomerGroupModel> AddCustomerGroup(CustomerGroupModel model, UserIdentity userIdentity)
        {
            try
            {
                CustomerGroup customerGroup = _mapper.Map<CustomerGroup>(model);
                customerGroup.CreateBy(userIdentity);
                customerGroup.UpdateBy(userIdentity);
                
                await _customerGroupRepository.Insert(customerGroup);
                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteCustomerGroup(Guid id)
        {
            try
            {
                CustomerGroup customerGroup = await _customerGroupRepository.GetByID(id);
                if (customerGroup == null)
                    throw new NotImplementedException("CustomerGroup not found");

                await _customerGroupRepository.Delete(customerGroup);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<CustomerGroupModel> GetAllCustomerGroups()
        {
            return _mapper.Map<IEnumerable<CustomerGroupModel>>(_customerGroupRepository.Get());
        }

        public async Task<CustomerGroupModel> GetCustomerGroupById(Guid id)
        {
            return _mapper.Map<CustomerGroupModel>(await _customerGroupRepository.GetByID(id));
        }

        public async Task<CustomerGroupModel> UpdateCustomerGroup(Guid id, CustomerGroupModel model, UserIdentity userIdentity)
        {
            try
            {
                CustomerGroup customerGroup = await _customerGroupRepository.GetByID(id);
                if (customerGroup == null)
                    throw new NotImplementedException("CustomerGroup not found");

                _mapper.Map(model, customerGroup);
                customerGroup.Id = id;
                customerGroup.UpdateBy(userIdentity);
                await _customerGroupRepository.Update(customerGroup);
                _unitOfWork.Save();

                return _mapper.Map<CustomerGroupModel>(customerGroup);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
