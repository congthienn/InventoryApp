using Autofac;
using Autofac.Extensions.DependencyInjection;
using InventoryApp.Data;
using InventoryApp.Infrastructures.Autofac;
using InventoryApp.Infrastructures.HttpClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Add DbContext
builder.Services.AddDbContext<InventoryDBContext>();

////Add Automapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//AddController
builder.Services.AddControllers();

//Add Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
CreateProvinceTable test = new CreateProvinceTable();
test.Run();
app.UseAuthorization();

app.MapControllers();

app.Run();
