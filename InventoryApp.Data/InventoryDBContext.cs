using InventoryApp.Common;
using InventoryApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Data
{
    public class InventoryDBContext : IdentityDbContext<Users, Roles, Guid, UserClaims, UserRoles, UserLogins, RoleClaims, UserTokens>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Appsetting.GetConnectionStringDatabase(), x=>x.MigrationsAssembly("InventoryApp.DbMigrations"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserBranches>().HasKey(table => new { table.UserId, table.BranchId });
            builder.Entity<UserRoles>().HasKey(table => new { table.UserId, table.RoleId });
            builder.Entity<UserLogins>().HasKey(table => new { table.LoginProvider, table.ProviderKey });
            builder.Entity<UserTokens>().HasKey(table => new { table.UserId, table.LoginProvider,table.Name });
            builder.Entity<MaterialAttributeValue>().HasKey(table => new { table.MaterialId, table.MaterialAttributeId });
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserBranches> UserBranches { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<RoleClaims> RoleClaims { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }
        public DbSet<PermissionMembership> PermissionMembership { get; set; }
        public DbSet<Branches> Branches { get; set; } 
        public DbSet<MenuPermissions> MenuPermissions { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Wards> Wards { get; set; }
        public DbSet<MaterialUnits> MaterialUnits { get; set; }
        public DbSet<MaterialsCategory> CategoryMaterials { get; set; }
        public DbSet<Trademark> Manufacturer { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierGroup> SupplierGroup { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
        public DbSet<MaterialAttribute> MaterialAttribute { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<WarehouseArea> WarehouseAreas { get; set; }
        public DbSet<WarehouseLine> WarehouseLines { get; set; }
        public DbSet<WarehouseShelves> WarehouseShelves { get; set; }
        public DbSet<WarehouseRack> WarehouseRack { get; set; }
        public DbSet<WarehousePosition> WarehousePosition { get; set; }
        public DbSet<WarehouseLocation> WarehouseLocation { get; set; }
        public DbSet<InventoryDeliveryVoucher> InventoryDeliveryVouchers { get; set; }
        public DbSet<InventoryReceivingVoucher> InventoryReceivingVouchers { get; set; }
        public DbSet<InventoryDeliveryVoucherDetail> InventoryDeliveryVoucherDetails { get; set; }
        public DbSet<InventoryReceivingVoucherDetail> InventoryReceivingVoucherDetails { get; set; }
        public DbSet<InventoryMaterialPeriod> InventoryMaterialPeriod { get; set; }
        public DbSet<InventoryMaterial> InventoryMaterials { get; set; }
        public DbSet<InventoryMaterialPeriodDetail> InventoryMaterialPeriodDetails { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<MaterialAttributeValue> MaterialAttributeValues { get; set; }
        public DbSet<CustomerGroup> CustomerGroup { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MaterialPosition> MaterialPosition { get; set; }
        public DbSet<MaterialShipment> MaterialShipment { get; set; }
        public DbSet<DeliveryVoucher> InventoryDeliveryVoucher_Customers { get; set; }
        public DbSet<InventoryReceivingVoucher_Supplier> InventoryReceivingVoucher_Shipments { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<SupplierOrder> SupplierOrder { get; set; }
        public DbSet<SupplierOrderDetail> SupplierOrderDetail { get; set; }
        public DbSet<MaterialQuotation> MaterialQuotation { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ReturnedMaterial> ReturnedMaterial { get; set; }
        public DbSet<ReturnedMaterialDetail> ReturnedMaterialDetail { get; set; }
    }
}