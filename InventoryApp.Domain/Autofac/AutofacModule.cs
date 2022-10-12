﻿using Autofac;
using InventoryApp.Infrastructures.Services;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Repositories;
using InventoryApp.Domain.JwtBearer;
using InventoryApp.Domain.Services.Identity;
using InventoryApp.Domain.Identity.IServices;

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
        }
        private void RegisterService(ContainerBuilder builder)
        {
            builder.RegisterType<ProvinceService>().As<IProvinceService>();
            builder.RegisterType<JwtTokenService>().As<IJwtTokenService>();
        }
        private void RegisterIdentityService(ContainerBuilder builder)
        {
            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}