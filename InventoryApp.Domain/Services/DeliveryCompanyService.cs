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
    public class DeliveryCompanyService : IDeliveryCompanyService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryCompanyRepository _deliveryCompanyRepository;
        public DeliveryCompanyService(ILogger<DeliveryCompanyService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _deliveryCompanyRepository = new DeliveryCompanyRepository(_unitOfWork);
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<DeliveryCompanyModel> AddDeliveryCompany(DeliveryCompanyModel model, UserIdentity userIdentity)
        {
            try
            {
                DeliveryCompany deliveryCompany = _mapper.Map<DeliveryCompany>(model);
                string code = await _deliveryCompanyRepository.GetLastCode();
                deliveryCompany.Code = code == null ? "DVGH000001" : StringHelper.CreateCode(code);
                deliveryCompany.CodeName = StringHelper.NormalizeString(model.Name);
                deliveryCompany.CreateBy(userIdentity); deliveryCompany.UpdateBy(userIdentity);

                await _deliveryCompanyRepository.Insert(deliveryCompany);
                _unitOfWork.Save();
                return _mapper.Map<DeliveryCompanyModel>(deliveryCompany);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<DeliveryCompanyModel> GetAllDeliveryCompanyByBranchId(Guid branchId)
        {
            return _mapper.Map<IEnumerable<DeliveryCompanyModel>>(_deliveryCompanyRepository.GetAllDeliveryCompanyByBranchId(branchId));
        }
    }
}
