using InventoryApp.Common;
using InventoryApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Data
{
    public class InventoryDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Appsetting.GetConnectionStringDatabase(), x=>x.MigrationsAssembly("InventoryApp.DbMigrations"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRoles>().HasKey(table => new { table.RoleId, table.UserId });
            builder.Entity<UserLogins>().HasKey(table => new { table.LoginProvider, table.ProviderKey });
            builder.Entity<UserTokens>().HasKey(table => new { table.UserId, table.LoginProvider,table.Name });
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<RoleClaims> RoleClaims { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }
        public DbSet<PermissionGroup> PermissionGroup { get; set; }
        public DbSet<PermissionMembership> PermissionMembership { get; set; }
        public DbSet<Branches> Branches { get; set; } 
        public DbSet<MenuPermissions> MenuPermissions { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Wards> Wards { get; set; }
        public DbSet<MaterialUnits> MaterialUnits { get; set; }
        public DbSet<CategoryMaterials> CategoryMaterials { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
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
    }
}