using AutoMapper;
using InventoryApp.Common;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.DTO.Users;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
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
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserService(UserManager<Users> userManager, RoleManager<Roles> roleManager, ILogger<UserService> logger, IMapper mapper, IEmailService emailSender)
        {
            _unitOfWork = new UnitOfWork();
            _userRepository = new UserRepository(_unitOfWork);
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
                Users user = _mapper.Map<Users>(model);
                user.CreateBy(issuer);
                user.UpdateBy(issuer);

                var password = Appsetting.GetAppSettingValue("PasswordDefault");

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    throw new NotImplementedException(result.Errors.ToString());
                var tokenConfirmEmail = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _emailService.SendEmailCreateNewUserAsync(user.Email, user.UserName, password, tokenConfirmEmail);
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
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

        public IQueryable GetRoleByUser(Guid userId)
        {
            return _userRepository.GetRoleByUser(userId);
        }

        public async Task<UserModelRq> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<UserModelRq>(user);
        }

        public IEnumerable<UserModelRq> GetUserList()
        {
            return _mapper.Map<IEnumerable<UserModelRq>>(_userRepository.Get());
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
