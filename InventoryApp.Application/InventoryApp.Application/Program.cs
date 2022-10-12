using Autofac;
using Autofac.Extensions.DependencyInjection;
using InventoryApp.Data;
using InventoryApp.Data.Models;
using InventoryApp.Domain.EmailSender;
using InventoryApp.Domain.Helper;
using InventoryApp.Domain.Helper.SeedData;
using InventoryApp.Domain.JwtBearer;
using InventoryApp.Domain.ServiceCollection;
using InventoryApp.Infrastructures.Autofac;
using InventoryApp.Infrastructures.Helper;
using Microsoft.AspNetCore.Identity;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Config EmailSettings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

//Add DbContext
builder.Services.AddDbContext<InventoryDBContext>();
builder.Services.AddIdentity<Users, Roles>()
        .AddEntityFrameworkStores<InventoryDBContext>().AddDefaultUI().AddDefaultTokenProviders();

//Identity configuration
builder.Services.IdentityConfiguration();

//Add JwtBearer
builder.Services.AddJwtBearerAuthentication();

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

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
