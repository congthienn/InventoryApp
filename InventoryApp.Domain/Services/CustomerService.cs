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
    public class CustomerService : ICustomerService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ILogger<CustomerService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _customerRepository = new CustomerRepository(_unitOfWork);
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<CustomerModel> AddCustomer(CustomerModel model, UserIdentity userIdentity)
        {
            try
            {
                Customer customer = _mapper.Map<Customer>(model);
                string code = await _customerRepository.GetLastCode();
                customer.Code = code == null ? "KH000001" : StringHelper.CreateCode(code);
                customer.CodeName = StringHelper.NormalizeString(model.CustomerName);
                customer.CreateBy(userIdentity); customer.UpdateBy(userIdentity);
                 
                await _customerRepository.Insert(customer);
                _unitOfWork.Save();
                return _mapper.Map<CustomerModel>(customer);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteCustomer(Guid id)
        {
            try
            {
                Customer customer = await _customerRepository.GetByID(id);
                if (customer == null)
                    throw new NotImplementedException("Customer not found");

                await _customerRepository.Delete(customer);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerModel>>(_customerRepository.Get());
        }

        public async Task<CustomerModel> GetCustomerById(Guid id)
        {
            return _mapper.Map<CustomerModel>(await _customerRepository.GetByID(id));
        }

        public async Task<CustomerModel> UpdateCustomer(Guid id, CustomerModel model, UserIdentity userIdentity)
        {
            try
            {
                Customer customer = await _customerRepository.GetByID(id);
                if (customer == null)
                    throw new NotImplementedException("Customer not found");
                string code = customer.Code;

                _mapper.Map(model, customer);
                customer.Id = id;
                customer.Code = code;
                customer.CodeName = StringHelper.NormalizeString(model.CustomerName);
                customer.UpdateBy(userIdentity);
                await _customerRepository.Update(customer);
                _unitOfWork.Save();
                return _mapper.Map<CustomerModel>(customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}