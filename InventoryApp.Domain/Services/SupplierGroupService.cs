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
    public class SupplierGroupService : ISupplierGroupService
    {
        private readonly ISupplierGroupRepository _supplierGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public SupplierGroupService(ILogger<SupplierGroupService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _supplierGroupRepository = new SupplierGroupRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SupplierGroupModelRq> AddSupplierGroup(SupplierGroupModelRq model, UserIdentity userIdentity)
        {
            try
            {
                SupplierGroup supplierGroup = _mapper.Map<SupplierGroup>(model);
                supplierGroup.CreateBy(userIdentity);
                supplierGroup.UpdateBy(userIdentity);

                await _supplierGroupRepository.Insert(supplierGroup);
                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteSupplierGroup(Guid supplierGroupId)
        {
            try
            {
                SupplierGroup supplierGroup =  await _supplierGroupRepository.GetByID(supplierGroupId);
                await _supplierGroupRepository.Delete(supplierGroup);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IQueryable GetAllSupplierByGroupId(Guid supplierGroupId)
        {
            return _supplierGroupRepository.GetAllSupplierByGroupId(supplierGroupId);
        }

        public IEnumerable<SupplierGroupModelRq> GetAllSupplierGroup()
        {
            return _mapper.Map<IEnumerable<SupplierGroupModelRq>>(_supplierGroupRepository.Get());
        }

        public async Task<SupplierGroupModelRq> UpdateSupplierGroup(Guid supplierGroupId, SupplierGroupModelRq model, UserIdentity userIdentity)
        {
            try
            {
                SupplierGroup supplierGroup = await _supplierGroupRepository.GetByID(supplierGroupId);
                if(supplierGroup == null)
                    throw new NotImplementedException("SupplierGroup not found");    

                _mapper.Map(model, supplierGroup);
                supplierGroup.Id = supplierGroupId;
                supplierGroup.UpdateBy(userIdentity);

                await _supplierGroupRepository.Update(supplierGroup);
                _unitOfWork.Save();

                return _mapper.Map<SupplierGroupModelRq>(supplierGroup);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
