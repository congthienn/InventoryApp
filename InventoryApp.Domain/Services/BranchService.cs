using AutoMapper;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;
using Microsoft.Extensions.Logging;
using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Helper;

namespace InventoryApp.Domain.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public BranchService(ILogger<BranchService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _branchRepository = new BranchReporitory(_unitOfWork);
            _logger = logger;
            _mapper = mapper;

        }
        public async Task<BranchModelRq> AddBranch(BranchModelRq model, UserIdentity userIdentity)
        {
            try
            {
                
                Branches branch = _mapper.Map<Branches>(model);
                branch.CodeName = StringHelper.NormalizeString(branch.CompanyName);
                branch.CreateBy(userIdentity);
                branch.UpdateBy(userIdentity);
                branch.BranchMain = !MainBranchAlreadyExists().Result ? branch.BranchMain : false;
                
                await _branchRepository.Insert(branch);
                _unitOfWork.Save();

                return model;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteBranch(Guid branchId)
        {
            try
            {
                Branches branch = await _branchRepository.GetByID(branchId);
                await _branchRepository.Delete(branch);
                _unitOfWork.Save();

                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<BranchModelRq> GetAllBranches()
        {
            return _mapper.Map<IEnumerable<BranchModelRq>>(_branchRepository.Get());
        }

        public IEnumerable<ShipmentModelRq> GetAllShipmentByBranch(Guid branchId)
        {
            return  _mapper.Map<IEnumerable<ShipmentModelRq>>(_branchRepository.GetAllShipmentByBranch(branchId));
        }

        public async Task<BranchModelRq> GetBranchById(Guid branchId)
        {
            return _mapper.Map<BranchModelRq>(await _branchRepository.GetByID(branchId));
        }

        public async Task<bool> MainBranchAlreadyExists()
        {
            return await _branchRepository.MainBranchAlreadyExists();
        }

        public async Task<BranchModelRq> UpdateBranch(BranchUpdateModel model, UserIdentity userIdentity)
        {
            try
            {
                Branches branch = await _branchRepository.GetByID(model.Id);
                _mapper.Map(model, branch);

                branch.CodeName = StringHelper.NormalizeString(branch.CompanyName);
                branch.UpdateBy(userIdentity);
                branch.BranchMain = !MainBranchAlreadyExists().Result ? branch.BranchMain : false;

                await _branchRepository.Update(branch);
                _unitOfWork.Save();

                return _mapper.Map<BranchModelRq>(branch);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
