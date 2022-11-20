using AutoMapper;
using InventoryApp.Common;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Domain.Identity.DTO.Users;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Web;

namespace InventoryApp.Domain.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<Roles> _roleManager;
        private readonly IUserBranchRepository _userBranchRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserService(UserManager<Users> userManager, RoleManager<Roles> roleManager, ILogger<UserService> logger, IMapper mapper, IEmailService emailSender)
        {
            _unitOfWork = new UnitOfWork();
            _userRepository = new UserRepository(_unitOfWork);
            _userBranchRepository = new UserBranchRepository(_unitOfWork);
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailSender;
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<bool> ActivateUserAccount(ConfirmEmailModelRq model)
        {
            try
            {
                var user =  await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return false;
                string token = HttpUtility.UrlDecode(model.Token);
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if(!result.Succeeded)
                    return false;
                user.Status = result.Succeeded;
                await _userManager.UpdateAsync(user);
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<UserModelRq> AddUserAsync(UserModelRq model, UserIdentity issuer)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                Users user = _mapper.Map<Users>(model);
                user.CreateBy(issuer);
                user.UpdateBy(issuer);

                var password = Appsetting.GetAppSettingValue("PasswordDefault");

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    throw new NotImplementedException(result.Errors.ToString());

                foreach (var branchId in model.BranchId)
                {
                    UserBranches userBranch = new UserBranches
                    {
                        BranchId = branchId,
                        UserId = user.Id
                    };
                    await _userBranchRepository.Insert(userBranch);
                }

                var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());

                var identityResult = await _userManager.AddToRoleAsync(user, role.Name);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                var tokenConfirmEmail = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _emailService.SendEmailCreateNewUserAsync(user.Email, user.UserName, password, tokenConfirmEmail);
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                _unitOfWork.Rollback();
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> CheckEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByID(id);
                if (user == null)
                    throw new NotImplementedException();
                
                await _userManager.DeleteAsync(user);
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<RoleModelRq> GetRoleByUser(Guid userId)
        {
            return _mapper.Map<IEnumerable<RoleModelRq>>(_userRepository.GetRoleByUser(userId));
        }

        public async Task<UserModelRq> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<UserModelRq>(user);
        }

        public IEnumerable<UserModelRq> GetUserList()
        {
            IEnumerable<UserModelRq> userList = _mapper.Map<IEnumerable<UserModelRq>>(_userRepository.Get());
            foreach(var userItem in userList)
            {
                userItem.Role = GetRoleByUser(userItem.Id).FirstOrDefault();
                userItem.Branch = _mapper.Map<IEnumerable<BranchModelRq>>(_userRepository.GetBranchByUser(userItem.Id));
            }
            return userList;
        }

        public async Task<bool> RemoveRoleToUserAsync(UserRoleModelRq model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                    return false;

                var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
                if (role == null)
                    return false;

                var identityResult = await _userManager.RemoveFromRoleAsync(user, role.Name);
                if (!identityResult.Succeeded)
                    return false;

                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> UpdateAccountStatus(UpdateAccountStatusModelRq model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null)
                return false;

            user.Status = model.Status;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<bool> UpdateRoleToUserAsync(UserRoleModelRq model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId.ToString());
                if (user == null)
                    return false;
                
               var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
                if (role == null)
                    return false;

                var identityResult = await _userManager.AddToRoleAsync(user, role.Name);
                if (!identityResult.Succeeded)
                    return false;

                return true;
                
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<UserModelRq> UpdateUserAsync(Guid id, UserUpdateRq model, UserIdentity issuer)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                    throw new NotImplementedException();
                _mapper.Map(model, user);
                user.UpdateBy(issuer);

                var resullt = await _userManager.UpdateAsync(user);
                if (!resullt.Succeeded)
                    throw new NotImplementedException(resullt.Errors.ToString());
                return _mapper.Map<UserModelRq>(user);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
