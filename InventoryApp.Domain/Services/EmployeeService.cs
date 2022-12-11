using AutoMapper;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Azure;
using InventoryApp.Domain.Identity.DTO.Users;
using InventoryApp.Domain.Identity.IServices;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAzureStorage _azureStorage;
        private readonly IUserService _userService;
        public EmployeeService(ILogger<MaterialService> logger, IMapper mapper, IAzureStorage azureStorage, IUserService userService)
        {
            _unitOfWork = new UnitOfWork();
            _employeeRepository = new EmployeeRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
            _azureStorage = azureStorage;
            _userService = userService;
        }
        public async Task AddEmployee(EmployeeModel model, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Employee employee = _mapper.Map<Employee>(model);
                string code = await _employeeRepository.GetLastCode();
                employee.Code = code == null ? "NV000001" : StringHelper.CreateCode(code);
                UserModelRq user = new UserModelRq()
                {
                    Email = employee.Email,
                    UserName = employee.Code,
                    RoleId = model.RoleId,
                    Employee = model.Name,
                    BranchId = new List<Guid> { employee.BranchId }
                };
                employee.CardImage = $"{employee.Id}-{model.Image.FileName}";
                employee.CreateBy(userIdentity);
                employee.UpdateBy(userIdentity);
                employee.UserId = user.Id;
               
                await _employeeRepository.Insert(employee);
                await _azureStorage.UploadAsync(model.Image, employee.Id);
                
                await _userService.AddUserAsync(user, userIdentity);


                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
          
        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            Employee employee = await _employeeRepository.GetByID(employeeId);
            if (employee == null)
                throw new NotImplementedException("Employee not found");
            await _employeeRepository.Delete(employee);
            _unitOfWork.Save();
            await _azureStorage.DeleteAsync(employee.CardImage);
            
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(_employeeRepository.GetAllEmployee());
        }

        public IEnumerable<EmployeeModel> GetEmployeeByBranchId(Guid branchId)
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(_employeeRepository.GetEmployeeByBranchId(branchId));
        }

        public async Task<EmployeeModel> GetEmployeeById(Guid employeeId)
        {
            EmployeeModel employee = _mapper.Map<EmployeeModel>(await _employeeRepository.GetEmployeeById(employeeId));
            employee.CardImage = await _azureStorage.DisplayPicture(employee.CardImage);
            return employee;
        }
    }
}
