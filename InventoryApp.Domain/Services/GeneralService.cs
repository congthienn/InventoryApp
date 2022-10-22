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
    public class GeneralService : IGeneralService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public GeneralService(ILogger<GeneralService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _companyRepository = new CompanyRepository(_unitOfWork);
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<CompanyModelRq> AddCompanyInformation(CompanyModelRq model, UserIdentity userIdentity)
        {
            try
            {
                if (await CompanyInformationAlreadyExists())
                    throw new NotImplementedException();

                Company companies = _mapper.Map<Company>(model);
                companies.CodeName = StringHelper.NormalizeString(companies.CompanyName);
                companies.CreateBy(userIdentity);
                companies.UpdateBy(userIdentity);

                await _companyRepository.Insert(companies);
                _unitOfWork.Save();

                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> CompanyInformationAlreadyExists()
        {
            return await _companyRepository.RepositoryIsNotEmpty();
        }

        public CompanyModelRq GetCompanyInformation()
        {
            return _mapper.Map<CompanyModelRq>(_companyRepository.Get().FirstOrDefault());
        }

        public async Task<CompanyModelRq> UpdateCompanyInformation(CompanyUpdateModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Company company = await _companyRepository.GetByID(model.Id);
                _mapper.Map(model, company);
                company.CodeName = StringHelper.NormalizeString(company.CompanyName);
                company.UpdateBy(userIdentity);

                await _companyRepository.Update(company);
                _unitOfWork.Save();

                return _mapper.Map<CompanyModelRq>(company);

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message); ;
            }
        }
    }
}
