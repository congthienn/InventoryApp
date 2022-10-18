using AutoMapper;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Identity.DTO.Roles;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services.Identity
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<Roles> _roleManagement;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public RoleService(RoleManager<Roles> roleManager, ILogger<RoleService> logger, IMapper mapper)
        {
            _roleManagement = roleManager;
            _logger = logger;
            _unitOfWork = new UnitOfWork();
            _roleRepository = new RoleRepository(_unitOfWork);
            _mapper = mapper;
        }
     
        public async Task<RoleModelRq> AddRoleAsync(RoleModelRq model, UserIdentity issuer)
        {
            try
            {
                Roles role = _mapper.Map<Roles>(model);
                role.CreateBy(issuer);
                role.UpdateBy(issuer);

                var result = await _roleManagement.CreateAsync(role);
                if (!result.Succeeded)
                    throw new NotImplementedException();

                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            try
            {
                var role = await _roleRepository.GetByID(id);
                if (role == null)
                    return false;

                await _roleManagement.DeleteAsync(role);
                _unitOfWork.Save();
                return true;        
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<RoleModelRq> GetRoleList()
        {
            return _mapper.Map<IEnumerable<RoleModelRq>>(_roleRepository.Get());
        }

        public async Task<RoleModelRq> GetRoleById(Guid id)
        {
            return _mapper.Map<RoleModelRq>(await _roleRepository.GetByID(id));
        }

        public IQueryable GetListUserRole(Guid userId)
        {
            return _roleRepository.GetUserRole(userId);
        }

        public async Task<RoleModelRq> UpdateRoleAsync(Guid id, RoleModelRq model, UserIdentity issuer)
        {
            try
            {
                var role = await _roleRepository.GetByID(id);
                if (role == null)
                    throw new NotImplementedException();

                role.Name = model.Name;
                role.UpdateBy(issuer);
                await _roleManagement.UpdateAsync(role);
                _unitOfWork.Save();
                return _mapper.Map<RoleModelRq>(role);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException();
            }
        }

        public async Task<RoleModelRq> GetRoleByName(string name)
        {
            var role = await _roleManagement.FindByNameAsync(name);
            if (role == null)
                throw new NotImplementedException();

            return _mapper.Map<RoleModelRq>(role);
        }
    }
}