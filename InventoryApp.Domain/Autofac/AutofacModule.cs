using Autofac;
using InventoryApp.Infrastructures.Services;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Repositories;
using InventoryApp.Domain.JwtBearer;
using InventoryApp.Domain.Services.Identity;
using InventoryApp.Domain.Identity.IServices;
using InventoryApp.Domain.Services;
using InventoryApp.Domain.EmailSender;
using InventoryApp.Domain.Azure;

namespace InventoryApp.Infrastructures.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            RegisterRepository(builder);
            RegisterService(builder);
            RegisterIdentityService(builder);
        }
        private void RegisterRepository(ContainerBuilder builder)
        {
            builder.RegisterType<ProvinceRepository>().As<IProvinceRepository>();
            builder.RegisterType<DistrictRepository>().As<IDistrictRepository>();
            builder.RegisterType<WardRepository>().As<IWardRepository>();
            builder.RegisterType<EmailRepository>().As<IEmailRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
            builder.RegisterType<BranchReporitory>().As<IBranchRepository>();
            builder.RegisterType<UserBranchRepository>().As<IUserBranchRepository>();
            builder.RegisterType<SupplierGroupRepository>().As<ISupplierGroupRepository>();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<ShipmentRepository>().As<IShipmentRepository>();
            builder.RegisterType<MaterialCategoryRepository>().As<IMaterialCategoryRepository>();
            builder.RegisterType<TrademarkRepository>().As<ITrademarkRepository>();
            builder.RegisterType<MaterialUnitRepository>().As<IMaterialUnitRepository>();
            builder.RegisterType<MaterialRepository>().As<IMaterialRepository>();
            builder.RegisterType<AzureStorage>().As<IAzureStorage>();
            builder.RegisterType<MaterialAttributeRepository>().As<IMaterialAttributeRepository>();
            builder.RegisterType<CustomerGroupRepository>().As<ICustomerGroupRepository>();
        }
        private void RegisterService(ContainerBuilder builder)
        {
            builder.RegisterType<ProvinceService>().As<IProvinceService>();
            builder.RegisterType<JwtTokenService>().As<IJwtTokenService>();
            builder.RegisterType<GeneralService>().As<IGeneralService>();
            builder.RegisterType<BranchService>().As<IBranchService>();
            builder.RegisterType<UserBranchService>().As<IUserBranchService>();
            builder.RegisterType<SupplierGroupService>().As<ISupplierGroupService>();
            builder.RegisterType<SupplierService>().As<ISupplierService>();
            builder.RegisterType<ShipmentService>().As<IShipmentService>();
            builder.RegisterType<MaterialCategoryService>().As<IMaterialCategoryService>();
            builder.RegisterType<TrademarkService>().As<ITrademarkService>();
            builder.RegisterType<MaterialUnitService>().As<IMaterialUnitService>();
            builder.RegisterType<MaterialService>().As<IMaterialService>();
            builder.RegisterType<MaterialAttributeService>().As<IMaterialAttributeService>();
            builder.RegisterType<CustomerGroupService>().As<ICustomerGroupService>();
        }
        private void RegisterIdentityService(ContainerBuilder builder)
        {
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<EmailSender>().As<IEmailSender>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}