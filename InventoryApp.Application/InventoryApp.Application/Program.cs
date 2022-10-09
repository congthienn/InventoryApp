using Autofac;
using Autofac.Extensions.DependencyInjection;
using InventoryApp.Data;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Helper;
using InventoryApp.Domain.Helper.SeedData;
using InventoryApp.Infrastructures.Autofac;
using InventoryApp.Infrastructures.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Add DbContext
builder.Services.AddDbContext<InventoryDBContext>();
builder.Services.AddIdentity<Users, Roles>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<InventoryDBContext>().AddDefaultUI().AddDefaultTokenProviders(); ;

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;

    // User settings
    options.User.RequireUniqueEmail = true;
});
////Add Automapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//AddController
builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
//Add Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serilog
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(LoggerHelper.GetConfig());
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

//Automatically create database
AutomaticCreateDatabase.Run(app);

//SeedData
SeedDataProvinces.Run();
SeedDataSystemAdmin.Run(builder.Services.BuildServiceProvider());
SeedDataRole.Run(builder.Services.BuildServiceProvider());


app.UseAuthorization();

app.MapControllers();

app.Run();
