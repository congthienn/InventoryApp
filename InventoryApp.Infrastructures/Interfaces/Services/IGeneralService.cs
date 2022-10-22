using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IGeneralService
    {
        public CompanyModelRq GetCompanyInformation();
        public Task<bool> CompanyInformationAlreadyExists();
        public Task<CompanyModelRq> AddCompanyInformation(CompanyModelRq model, UserIdentity userIdentity);
        public Task<CompanyModelRq> UpdateCompanyInformation(CompanyUpdateModelRq model, UserIdentity userIdentity);
    }
}