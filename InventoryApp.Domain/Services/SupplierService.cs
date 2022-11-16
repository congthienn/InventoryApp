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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public SupplierService(ILogger<SupplierService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _supplierRepository = new SupplierRepository(_unitOfWork);
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<SupplierModelRq> AddSupplier(SupplierModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Supplier supplier = _mapper.Map<Supplier>(model);
                string lastCode = await _supplierRepository.GetLastCode();
                supplier.Code = lastCode == null ? "NCC000001" : StringHelper.CreateCode(lastCode);
                supplier.CodeName = StringHelper.NormalizeString(model.SupplierName);
                supplier.CreateBy(userIdentity);
                supplier.UpdateBy(userIdentity);

                await _supplierRepository.Insert(supplier);
                _unitOfWork.Save();

                return _mapper.Map<SupplierModelRq>(supplier);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteSupplier(Guid supplierId)
        {
            try
            {
                Supplier supplier = await _supplierRepository.GetByID(supplierId);
                await _supplierRepository.Delete(supplier);
                _unitOfWork.Save();

                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<SupplierModelRq> GetAllSuppliers()
        {
            return _mapper.Map<IEnumerable<SupplierModelRq>>(_supplierRepository.GetAllSupplier());
        }

        public async Task<SupplierModelRq> UpdateSupplier(Guid id, SupplierModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Supplier supplier = await _supplierRepository.GetByID(id);
                if (supplier == null)
                    throw new NotImplementedException("Supplier not found");

                string code = supplier.Code;
                _mapper.Map(model, supplier);
                supplier.Id = id;
                supplier.UpdateBy(userIdentity);
                supplier.CodeName = StringHelper.NormalizeString(model.SupplierName);
                supplier.Code = code;
                await _supplierRepository.Update(supplier);
                _unitOfWork.Save();

                return _mapper.Map<SupplierModelRq>(supplier);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
