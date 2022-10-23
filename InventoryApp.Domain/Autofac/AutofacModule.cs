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

namespace InventoryApp.Infrastructures.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepository(builder);
            RegisterService(builder);
            RegisterIdentityService(builder);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
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