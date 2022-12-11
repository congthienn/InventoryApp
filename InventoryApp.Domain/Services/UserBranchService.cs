using AutoMapper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
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
    public class UserBranchService : IUserBranchService
    {
        private readonly ILogger _looger;
        private readonly IMapper _mapper;
        private readonly IUserBranchRepository _userBranchRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserBranchService(ILogger<UserBranchService> logger, IMapper mapper)
        {
            _looger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _userBranchRepository = new UserBranchRepository(_unitOfWork);
        }
        public async Task<bool> DeleteBranchToUser(UserBranchModelRq model)
        {
            try
            {
                UserBranches userBranch = _userBranchRepository.Get(x => x.BranchId == model.BranchId && x.UserId == model.UserId).FirstOrDefault();
                _userBranchRepository.Delete(userBranch);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _looger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<Guid> GetAllBranchByUserId(Guid userId)
        {
            return _userBranchRepository.GetAllBranchByUserId(userId);
        }

        public IEnumerable<string> GetAllBranchOfTheUser(Guid userId)
        {
            return _userBranchRepository.GetAllBranchOfTheUser(userId);
        }

        public IEnumerable<string> GetAllUsersOfTheBranch(Guid branchId)
        {
            return _userBranchRepository.GetAllUsersOfTheBranch(branchId);
        }

        public async Task<bool> UpdateBranchToUser(UserBranchModelRq model)
        {
            try
            {
                UserBranches userBranch = _mapper.Map<UserBranches>(model);
                await _userBranchRepository.Insert(userBranch);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _looger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
