using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.DbMigrations.Migrations
{
    public partial class Allter_Table_SupplierOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Company_CompaniesId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Districts_DistrictId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Provinces_ProvinceId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Users_CreatedByUserId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Users_UpdatedByUserId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Wards_WardId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMaterial_Users_CreatedByUserId",
                table: "CategoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMaterial_Users_UpdatedByUserId",
                table: "CategoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Districts_DistrictId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Provinces_ProvinceId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_CreatedByUserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_UpdatedByUserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Wards_WardId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Branches_BranchId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerGroup_CustomerGroupId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Districts_DistrictId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Provinces_ProvinceId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_CreatedByUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_UpdatedByUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Wards_WardId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroup_Users_CreatedByUserId",
                table: "CustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroup_Users_UpdatedByUserId",
                table: "CustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVoucher_Customer_CustomerId",
                table: "DeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVoucher_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "DeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVoucher_Users_DeliveryUserId",
                table: "DeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Branches_BranchId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Users_CreatedByUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Users_UpdatedByUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvinceId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplate_Users_CreatedByUserId",
                table: "EmailTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplate_Users_UpdatedByUserId",
                table: "EmailTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Districts_DistrictId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_BirthPlaceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_IdentityCardPlaceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_ProvinceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_CreatedByUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UpdatedByUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Wards_WardId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_CreatedByUserId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UpdatedByUserId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Warehouses_WarehouseId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Shipment_ShipmentId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_Materials_MaterialId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_Users_CreatedByUserId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_Users_UpdatedByUserId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_WarehouseLocation_WarehouseLocationId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriod_Employees_ConfirmedByEmployeesId",
                table: "InventoryMaterialPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_CreatedByUserId",
                table: "InventoryMaterialPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Materials_MaterialId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_CreatedByUserId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Warehouses_WarehouseId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Branches_BranchRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_CreatedByUserId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UpdatedByUserId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserReceiveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Warehouses_WarehouseId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucher_Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_Supplier_SupplierId",
                table: "InventoryReceivingVoucher_Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_CategoryMaterial_MaterialsCategoryId",
                table: "MaterialAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_Users_CreatedByUserId",
                table: "MaterialAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_Users_UpdatedByUserId",
                table: "MaterialAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_MaterialAttribute_MaterialAttributeId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_Materials_MaterialId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_Users_CreatedByUserId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_Users_UpdatedByUserId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPicture_Materials_MaterialId",
                table: "MaterialPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPosition_Materials_MaterialId",
                table: "MaterialPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPosition_WarehouseShelves_WarehouseShelveId",
                table: "MaterialPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialQuotation_Materials_MaterialId",
                table: "MaterialQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialQuotation_Users_CreatedByUserId",
                table: "MaterialQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialQuotation_Users_UpdatedByUserId",
                table: "MaterialQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_CategoryMaterial_CategoryMaterialId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Trademark_TrademarkId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Users_CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Users_UpdatedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Materials_MaterialId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Shipment_ShipmentId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Users_CreatedByUserId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Users_UpdatedByUserId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Materials_MaterialId",
                table: "MaterialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Users_CreatedByUserId",
                table: "MaterialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Users_UpdatedByUserId",
                table: "MaterialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_PermissionGroup_PermissionGroupId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_Users_CreatedByUserId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_Users_UpdatedByUserId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Branches_BranchId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_CreatedByUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UpdatedByUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Materials_MaterialId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionGroup_Users_CreatedByUserId",
                table: "PermissionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionGroup_Users_UpdatedByUserId",
                table: "PermissionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_Users_CreatedByUserId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_Users_UpdatedByUserId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_Users_UserId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedByUserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UpdatedByUserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Branches_BranchId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Users_CreatedByUserId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Users_UpdatedByUserId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Districts_DistrictId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Provinces_ProvinceId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Users_CreatedByUserId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Users_UpdatedByUserId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Wards_WardId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierGroup_Users_CreatedByUserId",
                table: "SupplierGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierGroup_Users_UpdatedByUserId",
                table: "SupplierGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Branches_BranchRequestId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Supplier_SupplierId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Users_CreatedByUserId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Users_UpdatedByUserId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrderDetail_Materials_MaterialId",
                table: "SupplierOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrderDetail_SupplierOrder_SupplierOrderId",
                table: "SupplierOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Trademark_Users_CreatedByUserId",
                table: "Trademark");

            migrationBuilder.DropForeignKey(
                name: "FK_Trademark_Users_UpdatedByUserId",
                table: "Trademark");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Branches_BranchId",
                table: "UserBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Districts_DistrictId",
                table: "Wards");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseArea_Users_CreatedByUserId",
                table: "WarehouseArea");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseArea_Users_UpdatedByUserId",
                table: "WarehouseArea");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseArea_Warehouses_WarehouseId",
                table: "WarehouseArea");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLine_Users_CreatedByUserId",
                table: "WarehouseLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLine_Users_UpdatedByUserId",
                table: "WarehouseLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLine_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_Users_CreatedByUserId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_Users_UpdatedByUserId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseLine_WarehouseLineId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehousePosition_WarehousePositionId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseRack_WarehouseRackId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_Warehouses_WarehouseId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousePosition_Users_CreatedByUserId",
                table: "WarehousePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousePosition_Users_UpdatedByUserId",
                table: "WarehousePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousePosition_WarehouseRack_WarehouseRackId",
                table: "WarehousePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRack_Users_CreatedByUserId",
                table: "WarehouseRack");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRack_Users_UpdatedByUserId",
                table: "WarehouseRack");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRack_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseRack");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Branches_BranchId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Users_CreatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Users_UpdatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseShelves_Users_CreatedByUserId",
                table: "WarehouseShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseShelves_Users_UpdatedByUserId",
                table: "WarehouseShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseShelves_WarehouseLine_WarehouseLineId",
                table: "WarehouseShelves");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Company_CompaniesId",
                table: "Branches",
                column: "CompaniesId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Districts_DistrictId",
                table: "Branches",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Provinces_ProvinceId",
                table: "Branches",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Users_CreatedByUserId",
                table: "Branches",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Users_UpdatedByUserId",
                table: "Branches",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Wards_WardId",
                table: "Branches",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMaterial_Users_CreatedByUserId",
                table: "CategoryMaterial",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMaterial_Users_UpdatedByUserId",
                table: "CategoryMaterial",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Districts_DistrictId",
                table: "Company",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Provinces_ProvinceId",
                table: "Company",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_CreatedByUserId",
                table: "Company",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_UpdatedByUserId",
                table: "Company",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Wards_WardId",
                table: "Company",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Branches_BranchId",
                table: "Customer",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerGroup_CustomerGroupId",
                table: "Customer",
                column: "CustomerGroupId",
                principalTable: "CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Districts_DistrictId",
                table: "Customer",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Provinces_ProvinceId",
                table: "Customer",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_CreatedByUserId",
                table: "Customer",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_UpdatedByUserId",
                table: "Customer",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Wards_WardId",
                table: "Customer",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroup_Users_CreatedByUserId",
                table: "CustomerGroup",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroup_Users_UpdatedByUserId",
                table: "CustomerGroup",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVoucher_Customer_CustomerId",
                table: "DeliveryVoucher",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVoucher_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "DeliveryVoucher",
                column: "InventoryDeliveryVoucherId",
                principalTable: "InventoryDeliveryVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVoucher_Users_DeliveryUserId",
                table: "DeliveryVoucher",
                column: "DeliveryUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Branches_BranchId",
                table: "Department",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Users_CreatedByUserId",
                table: "Department",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Users_UpdatedByUserId",
                table: "Department",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Provinces_ProvinceId",
                table: "Districts",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplate_Users_CreatedByUserId",
                table: "EmailTemplate",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplate_Users_UpdatedByUserId",
                table: "EmailTemplate",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Districts_DistrictId",
                table: "Employees",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_BirthPlaceId",
                table: "Employees",
                column: "BirthPlaceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_IdentityCardPlaceId",
                table: "Employees",
                column: "IdentityCardPlaceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_ProvinceId",
                table: "Employees",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_CreatedByUserId",
                table: "Employees",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UpdatedByUserId",
                table: "Employees",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Wards_WardId",
                table: "Employees",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchId",
                table: "InventoryDeliveryVoucher",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_CreatedByUserId",
                table: "InventoryDeliveryVoucher",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UpdatedByUserId",
                table: "InventoryDeliveryVoucher",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Warehouses_WarehouseId",
                table: "InventoryDeliveryVoucher",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail",
                column: "InventoryDeliveryVoucherId",
                principalTable: "InventoryDeliveryVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Shipment_ShipmentId",
                table: "InventoryDeliveryVoucherDetail",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterial",
                column: "InventoryMaterialPeriodId",
                principalTable: "InventoryMaterialPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_Materials_MaterialId",
                table: "InventoryMaterial",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_Users_CreatedByUserId",
                table: "InventoryMaterial",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_Users_UpdatedByUserId",
                table: "InventoryMaterial",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_WarehouseLocation_WarehouseLocationId",
                table: "InventoryMaterial",
                column: "WarehouseLocationId",
                principalTable: "WarehouseLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriod_Employees_ConfirmedByEmployeesId",
                table: "InventoryMaterialPeriod",
                column: "ConfirmedByEmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_CreatedByUserId",
                table: "InventoryMaterialPeriod",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriod",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterialPeriodDetail",
                column: "InventoryMaterialPeriodId",
                principalTable: "InventoryMaterialPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Materials_MaterialId",
                table: "InventoryMaterialPeriodDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_CreatedByUserId",
                table: "InventoryMaterialPeriodDetail",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriodDetail",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Warehouses_WarehouseId",
                table: "InventoryMaterialPeriodDetail",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Branches_BranchRequestId",
                table: "InventoryReceivingVoucher",
                column: "BranchRequestId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_CreatedByUserId",
                table: "InventoryReceivingVoucher",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UpdatedByUserId",
                table: "InventoryReceivingVoucher",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserReceiveId",
                table: "InventoryReceivingVoucher",
                column: "UserReceiveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Warehouses_WarehouseId",
                table: "InventoryReceivingVoucher",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucher_Supplier",
                column: "InventoryReceivingVoucherId",
                principalTable: "InventoryReceivingVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_Supplier_SupplierId",
                table: "InventoryReceivingVoucher_Supplier",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail",
                column: "InventoryReceivingVoucherId",
                principalTable: "InventoryReceivingVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialShipmentId",
                principalTable: "MaterialShipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_CategoryMaterial_MaterialsCategoryId",
                table: "MaterialAttribute",
                column: "MaterialsCategoryId",
                principalTable: "CategoryMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_Users_CreatedByUserId",
                table: "MaterialAttribute",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_Users_UpdatedByUserId",
                table: "MaterialAttribute",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_MaterialAttribute_MaterialAttributeId",
                table: "MaterialAttributeValues",
                column: "MaterialAttributeId",
                principalTable: "MaterialAttribute",
                principalColumn: "MaterialAttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_Materials_MaterialId",
                table: "MaterialAttributeValues",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_Users_CreatedByUserId",
                table: "MaterialAttributeValues",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_Users_UpdatedByUserId",
                table: "MaterialAttributeValues",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPicture_Materials_MaterialId",
                table: "MaterialPicture",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPosition_Materials_MaterialId",
                table: "MaterialPosition",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPosition_WarehouseShelves_WarehouseShelveId",
                table: "MaterialPosition",
                column: "WarehouseShelveId",
                principalTable: "WarehouseShelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialQuotation_Materials_MaterialId",
                table: "MaterialQuotation",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialQuotation_Users_CreatedByUserId",
                table: "MaterialQuotation",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialQuotation_Users_UpdatedByUserId",
                table: "MaterialQuotation",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_CategoryMaterial_CategoryMaterialId",
                table: "Materials",
                column: "CategoryMaterialId",
                principalTable: "CategoryMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Trademark_TrademarkId",
                table: "Materials",
                column: "TrademarkId",
                principalTable: "Trademark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Users_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Users_UpdatedByUserId",
                table: "Materials",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Materials_MaterialId",
                table: "MaterialShipment",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Shipment_ShipmentId",
                table: "MaterialShipment",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Users_CreatedByUserId",
                table: "MaterialShipment",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Users_UpdatedByUserId",
                table: "MaterialShipment",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Materials_MaterialId",
                table: "MaterialUnit",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Users_CreatedByUserId",
                table: "MaterialUnit",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Users_UpdatedByUserId",
                table: "MaterialUnit",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_PermissionGroup_PermissionGroupId",
                table: "MenuPermissions",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_Users_CreatedByUserId",
                table: "MenuPermissions",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_Users_UpdatedByUserId",
                table: "MenuPermissions",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Branches_BranchId",
                table: "Order",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_CreatedByUserId",
                table: "Order",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UpdatedByUserId",
                table: "Order",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Materials_MaterialId",
                table: "OrderDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionGroup_Users_CreatedByUserId",
                table: "PermissionGroup",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionGroup_Users_UpdatedByUserId",
                table: "PermissionGroup",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_Users_CreatedByUserId",
                table: "PermissionMembership",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_Users_UpdatedByUserId",
                table: "PermissionMembership",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_Users_UserId",
                table: "PermissionMembership",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedByUserId",
                table: "Roles",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UpdatedByUserId",
                table: "Roles",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Branches_BranchId",
                table: "Shipment",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Users_CreatedByUserId",
                table: "Shipment",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Users_UpdatedByUserId",
                table: "Shipment",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Districts_DistrictId",
                table: "Supplier",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Provinces_ProvinceId",
                table: "Supplier",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                table: "Supplier",
                column: "SupplierGroupId",
                principalTable: "SupplierGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Users_CreatedByUserId",
                table: "Supplier",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Users_UpdatedByUserId",
                table: "Supplier",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Wards_WardId",
                table: "Supplier",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierGroup_Users_CreatedByUserId",
                table: "SupplierGroup",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierGroup_Users_UpdatedByUserId",
                table: "SupplierGroup",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Branches_BranchRequestId",
                table: "SupplierOrder",
                column: "BranchRequestId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Supplier_SupplierId",
                table: "SupplierOrder",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Users_CreatedByUserId",
                table: "SupplierOrder",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Users_UpdatedByUserId",
                table: "SupplierOrder",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrderDetail_Materials_MaterialId",
                table: "SupplierOrderDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrderDetail_SupplierOrder_SupplierOrderId",
                table: "SupplierOrderDetail",
                column: "SupplierOrderId",
                principalTable: "SupplierOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trademark_Users_CreatedByUserId",
                table: "Trademark",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trademark_Users_UpdatedByUserId",
                table: "Trademark",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Branches_BranchId",
                table: "UserBranches",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Districts_DistrictId",
                table: "Wards",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseArea_Users_CreatedByUserId",
                table: "WarehouseArea",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseArea_Users_UpdatedByUserId",
                table: "WarehouseArea",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseArea_Warehouses_WarehouseId",
                table: "WarehouseArea",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLine_Users_CreatedByUserId",
                table: "WarehouseLine",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLine_Users_UpdatedByUserId",
                table: "WarehouseLine",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLine_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLine",
                column: "WarehouseAreaId",
                principalTable: "WarehouseArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_Users_CreatedByUserId",
                table: "WarehouseLocation",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_Users_UpdatedByUserId",
                table: "WarehouseLocation",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLocation",
                column: "WarehouseAreaId",
                principalTable: "WarehouseArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseLine_WarehouseLineId",
                table: "WarehouseLocation",
                column: "WarehouseLineId",
                principalTable: "WarehouseLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehousePosition_WarehousePositionId",
                table: "WarehouseLocation",
                column: "WarehousePositionId",
                principalTable: "WarehousePosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseRack_WarehouseRackId",
                table: "WarehouseLocation",
                column: "WarehouseRackId",
                principalTable: "WarehouseRack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_Warehouses_WarehouseId",
                table: "WarehouseLocation",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseLocation",
                column: "WarehouseShelvesId",
                principalTable: "WarehouseShelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousePosition_Users_CreatedByUserId",
                table: "WarehousePosition",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousePosition_Users_UpdatedByUserId",
                table: "WarehousePosition",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousePosition_WarehouseRack_WarehouseRackId",
                table: "WarehousePosition",
                column: "WarehouseRackId",
                principalTable: "WarehouseRack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRack_Users_CreatedByUserId",
                table: "WarehouseRack",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRack_Users_UpdatedByUserId",
                table: "WarehouseRack",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRack_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseRack",
                column: "WarehouseShelvesId",
                principalTable: "WarehouseShelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Branches_BranchId",
                table: "Warehouses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Users_CreatedByUserId",
                table: "Warehouses",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Users_UpdatedByUserId",
                table: "Warehouses",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseShelves_Users_CreatedByUserId",
                table: "WarehouseShelves",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseShelves_Users_UpdatedByUserId",
                table: "WarehouseShelves",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseShelves_WarehouseLine_WarehouseLineId",
                table: "WarehouseShelves",
                column: "WarehouseLineId",
                principalTable: "WarehouseLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Company_CompaniesId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Districts_DistrictId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Provinces_ProvinceId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Users_CreatedByUserId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Users_UpdatedByUserId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Wards_WardId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMaterial_Users_CreatedByUserId",
                table: "CategoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMaterial_Users_UpdatedByUserId",
                table: "CategoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Districts_DistrictId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Provinces_ProvinceId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_CreatedByUserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Users_UpdatedByUserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Wards_WardId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Branches_BranchId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerGroup_CustomerGroupId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Districts_DistrictId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Provinces_ProvinceId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_CreatedByUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_UpdatedByUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Wards_WardId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroup_Users_CreatedByUserId",
                table: "CustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroup_Users_UpdatedByUserId",
                table: "CustomerGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVoucher_Customer_CustomerId",
                table: "DeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVoucher_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "DeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVoucher_Users_DeliveryUserId",
                table: "DeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Branches_BranchId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Users_CreatedByUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Users_UpdatedByUserId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvinceId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplate_Users_CreatedByUserId",
                table: "EmailTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailTemplate_Users_UpdatedByUserId",
                table: "EmailTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Districts_DistrictId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_BirthPlaceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_IdentityCardPlaceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Provinces_ProvinceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_CreatedByUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UpdatedByUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Wards_WardId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_CreatedByUserId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UpdatedByUserId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucher_Warehouses_WarehouseId",
                table: "InventoryDeliveryVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Shipment_ShipmentId",
                table: "InventoryDeliveryVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_Materials_MaterialId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_Users_CreatedByUserId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_Users_UpdatedByUserId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterial_WarehouseLocation_WarehouseLocationId",
                table: "InventoryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriod_Employees_ConfirmedByEmployeesId",
                table: "InventoryMaterialPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_CreatedByUserId",
                table: "InventoryMaterialPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Materials_MaterialId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_CreatedByUserId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Warehouses_WarehouseId",
                table: "InventoryMaterialPeriodDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Branches_BranchRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_CreatedByUserId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UpdatedByUserId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserReceiveId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Warehouses_WarehouseId",
                table: "InventoryReceivingVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucher_Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_Supplier_SupplierId",
                table: "InventoryReceivingVoucher_Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_CategoryMaterial_MaterialsCategoryId",
                table: "MaterialAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_Users_CreatedByUserId",
                table: "MaterialAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttribute_Users_UpdatedByUserId",
                table: "MaterialAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_MaterialAttribute_MaterialAttributeId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_Materials_MaterialId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_Users_CreatedByUserId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributeValues_Users_UpdatedByUserId",
                table: "MaterialAttributeValues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPicture_Materials_MaterialId",
                table: "MaterialPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPosition_Materials_MaterialId",
                table: "MaterialPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialPosition_WarehouseShelves_WarehouseShelveId",
                table: "MaterialPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialQuotation_Materials_MaterialId",
                table: "MaterialQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialQuotation_Users_CreatedByUserId",
                table: "MaterialQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialQuotation_Users_UpdatedByUserId",
                table: "MaterialQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_CategoryMaterial_CategoryMaterialId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Trademark_TrademarkId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Users_CreatedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Users_UpdatedByUserId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Materials_MaterialId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Shipment_ShipmentId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Users_CreatedByUserId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialShipment_Users_UpdatedByUserId",
                table: "MaterialShipment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Materials_MaterialId",
                table: "MaterialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Users_CreatedByUserId",
                table: "MaterialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUnit_Users_UpdatedByUserId",
                table: "MaterialUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_PermissionGroup_PermissionGroupId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_Users_CreatedByUserId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermissions_Users_UpdatedByUserId",
                table: "MenuPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Branches_BranchId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_CreatedByUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UpdatedByUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Materials_MaterialId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionGroup_Users_CreatedByUserId",
                table: "PermissionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionGroup_Users_UpdatedByUserId",
                table: "PermissionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_Users_CreatedByUserId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_Users_UpdatedByUserId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionMembership_Users_UserId",
                table: "PermissionMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatedByUserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UpdatedByUserId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Branches_BranchId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Users_CreatedByUserId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Users_UpdatedByUserId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Districts_DistrictId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Provinces_ProvinceId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Users_CreatedByUserId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Users_UpdatedByUserId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Wards_WardId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierGroup_Users_CreatedByUserId",
                table: "SupplierGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierGroup_Users_UpdatedByUserId",
                table: "SupplierGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Branches_BranchRequestId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Supplier_SupplierId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Users_CreatedByUserId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrder_Users_UpdatedByUserId",
                table: "SupplierOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrderDetail_Materials_MaterialId",
                table: "SupplierOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrderDetail_SupplierOrder_SupplierOrderId",
                table: "SupplierOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Trademark_Users_CreatedByUserId",
                table: "Trademark");

            migrationBuilder.DropForeignKey(
                name: "FK_Trademark_Users_UpdatedByUserId",
                table: "Trademark");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Branches_BranchId",
                table: "UserBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Districts_DistrictId",
                table: "Wards");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseArea_Users_CreatedByUserId",
                table: "WarehouseArea");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseArea_Users_UpdatedByUserId",
                table: "WarehouseArea");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseArea_Warehouses_WarehouseId",
                table: "WarehouseArea");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLine_Users_CreatedByUserId",
                table: "WarehouseLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLine_Users_UpdatedByUserId",
                table: "WarehouseLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLine_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_Users_CreatedByUserId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_Users_UpdatedByUserId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseLine_WarehouseLineId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehousePosition_WarehousePositionId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseRack_WarehouseRackId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_Warehouses_WarehouseId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseLocation_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousePosition_Users_CreatedByUserId",
                table: "WarehousePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousePosition_Users_UpdatedByUserId",
                table: "WarehousePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehousePosition_WarehouseRack_WarehouseRackId",
                table: "WarehousePosition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRack_Users_CreatedByUserId",
                table: "WarehouseRack");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRack_Users_UpdatedByUserId",
                table: "WarehouseRack");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseRack_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseRack");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Branches_BranchId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Users_CreatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Users_UpdatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseShelves_Users_CreatedByUserId",
                table: "WarehouseShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseShelves_Users_UpdatedByUserId",
                table: "WarehouseShelves");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseShelves_WarehouseLine_WarehouseLineId",
                table: "WarehouseShelves");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Company_CompaniesId",
                table: "Branches",
                column: "CompaniesId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Districts_DistrictId",
                table: "Branches",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Provinces_ProvinceId",
                table: "Branches",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Users_CreatedByUserId",
                table: "Branches",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Users_UpdatedByUserId",
                table: "Branches",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Wards_WardId",
                table: "Branches",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMaterial_Users_CreatedByUserId",
                table: "CategoryMaterial",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMaterial_Users_UpdatedByUserId",
                table: "CategoryMaterial",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Districts_DistrictId",
                table: "Company",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Provinces_ProvinceId",
                table: "Company",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_CreatedByUserId",
                table: "Company",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Users_UpdatedByUserId",
                table: "Company",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Wards_WardId",
                table: "Company",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Branches_BranchId",
                table: "Customer",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerGroup_CustomerGroupId",
                table: "Customer",
                column: "CustomerGroupId",
                principalTable: "CustomerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Districts_DistrictId",
                table: "Customer",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Provinces_ProvinceId",
                table: "Customer",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_CreatedByUserId",
                table: "Customer",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_UpdatedByUserId",
                table: "Customer",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Wards_WardId",
                table: "Customer",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroup_Users_CreatedByUserId",
                table: "CustomerGroup",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroup_Users_UpdatedByUserId",
                table: "CustomerGroup",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVoucher_Customer_CustomerId",
                table: "DeliveryVoucher",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVoucher_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "DeliveryVoucher",
                column: "InventoryDeliveryVoucherId",
                principalTable: "InventoryDeliveryVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVoucher_Users_DeliveryUserId",
                table: "DeliveryVoucher",
                column: "DeliveryUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Branches_BranchId",
                table: "Department",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Users_CreatedByUserId",
                table: "Department",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Users_UpdatedByUserId",
                table: "Department",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Provinces_ProvinceId",
                table: "Districts",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplate_Users_CreatedByUserId",
                table: "EmailTemplate",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailTemplate_Users_UpdatedByUserId",
                table: "EmailTemplate",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Districts_DistrictId",
                table: "Employees",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_BirthPlaceId",
                table: "Employees",
                column: "BirthPlaceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_IdentityCardPlaceId",
                table: "Employees",
                column: "IdentityCardPlaceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Provinces_ProvinceId",
                table: "Employees",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_CreatedByUserId",
                table: "Employees",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UpdatedByUserId",
                table: "Employees",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Wards_WardId",
                table: "Employees",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Branches_BranchId",
                table: "InventoryDeliveryVoucher",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_CreatedByUserId",
                table: "InventoryDeliveryVoucher",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UpdatedByUserId",
                table: "InventoryDeliveryVoucher",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Users_UserRequestId",
                table: "InventoryDeliveryVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucher_Warehouses_WarehouseId",
                table: "InventoryDeliveryVoucher",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_InventoryDeliveryVoucher_InventoryDeliveryVoucherId",
                table: "InventoryDeliveryVoucherDetail",
                column: "InventoryDeliveryVoucherId",
                principalTable: "InventoryDeliveryVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDeliveryVoucherDetail_Shipment_ShipmentId",
                table: "InventoryDeliveryVoucherDetail",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterial",
                column: "InventoryMaterialPeriodId",
                principalTable: "InventoryMaterialPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_Materials_MaterialId",
                table: "InventoryMaterial",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_Users_CreatedByUserId",
                table: "InventoryMaterial",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_Users_UpdatedByUserId",
                table: "InventoryMaterial",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterial_WarehouseLocation_WarehouseLocationId",
                table: "InventoryMaterial",
                column: "WarehouseLocationId",
                principalTable: "WarehouseLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriod_Employees_ConfirmedByEmployeesId",
                table: "InventoryMaterialPeriod",
                column: "ConfirmedByEmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_CreatedByUserId",
                table: "InventoryMaterialPeriod",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriod_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriod",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_InventoryMaterialPeriod_InventoryMaterialPeriodId",
                table: "InventoryMaterialPeriodDetail",
                column: "InventoryMaterialPeriodId",
                principalTable: "InventoryMaterialPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Materials_MaterialId",
                table: "InventoryMaterialPeriodDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_CreatedByUserId",
                table: "InventoryMaterialPeriodDetail",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Users_UpdatedByUserId",
                table: "InventoryMaterialPeriodDetail",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryMaterialPeriodDetail_Warehouses_WarehouseId",
                table: "InventoryMaterialPeriodDetail",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Branches_BranchRequestId",
                table: "InventoryReceivingVoucher",
                column: "BranchRequestId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_CreatedByUserId",
                table: "InventoryReceivingVoucher",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UpdatedByUserId",
                table: "InventoryReceivingVoucher",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserApproveId",
                table: "InventoryReceivingVoucher",
                column: "UserApproveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserReceiveId",
                table: "InventoryReceivingVoucher",
                column: "UserReceiveId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Users_UserRequestId",
                table: "InventoryReceivingVoucher",
                column: "UserRequestId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Warehouses_WarehouseId",
                table: "InventoryReceivingVoucher",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucher_Supplier",
                column: "InventoryReceivingVoucherId",
                principalTable: "InventoryReceivingVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucher_Supplier_Supplier_SupplierId",
                table: "InventoryReceivingVoucher_Supplier",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_InventoryReceivingVoucher_InventoryReceivingVoucherId",
                table: "InventoryReceivingVoucherDetail",
                column: "InventoryReceivingVoucherId",
                principalTable: "InventoryReceivingVoucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryReceivingVoucherDetail_MaterialShipment_MaterialShipmentId",
                table: "InventoryReceivingVoucherDetail",
                column: "MaterialShipmentId",
                principalTable: "MaterialShipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_CategoryMaterial_MaterialsCategoryId",
                table: "MaterialAttribute",
                column: "MaterialsCategoryId",
                principalTable: "CategoryMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_Users_CreatedByUserId",
                table: "MaterialAttribute",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttribute_Users_UpdatedByUserId",
                table: "MaterialAttribute",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_MaterialAttribute_MaterialAttributeId",
                table: "MaterialAttributeValues",
                column: "MaterialAttributeId",
                principalTable: "MaterialAttribute",
                principalColumn: "MaterialAttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_Materials_MaterialId",
                table: "MaterialAttributeValues",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_Users_CreatedByUserId",
                table: "MaterialAttributeValues",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributeValues_Users_UpdatedByUserId",
                table: "MaterialAttributeValues",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPicture_Materials_MaterialId",
                table: "MaterialPicture",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPosition_Materials_MaterialId",
                table: "MaterialPosition",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialPosition_WarehouseShelves_WarehouseShelveId",
                table: "MaterialPosition",
                column: "WarehouseShelveId",
                principalTable: "WarehouseShelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialQuotation_Materials_MaterialId",
                table: "MaterialQuotation",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialQuotation_Users_CreatedByUserId",
                table: "MaterialQuotation",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialQuotation_Users_UpdatedByUserId",
                table: "MaterialQuotation",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_CategoryMaterial_CategoryMaterialId",
                table: "Materials",
                column: "CategoryMaterialId",
                principalTable: "CategoryMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Trademark_TrademarkId",
                table: "Materials",
                column: "TrademarkId",
                principalTable: "Trademark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Users_CreatedByUserId",
                table: "Materials",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Users_UpdatedByUserId",
                table: "Materials",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Materials_MaterialId",
                table: "MaterialShipment",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Shipment_ShipmentId",
                table: "MaterialShipment",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Users_CreatedByUserId",
                table: "MaterialShipment",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialShipment_Users_UpdatedByUserId",
                table: "MaterialShipment",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Materials_MaterialId",
                table: "MaterialUnit",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Users_CreatedByUserId",
                table: "MaterialUnit",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUnit_Users_UpdatedByUserId",
                table: "MaterialUnit",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_PermissionGroup_PermissionGroupId",
                table: "MenuPermissions",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_Users_CreatedByUserId",
                table: "MenuPermissions",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermissions_Users_UpdatedByUserId",
                table: "MenuPermissions",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Branches_BranchId",
                table: "Order",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_CreatedByUserId",
                table: "Order",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UpdatedByUserId",
                table: "Order",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Materials_MaterialId",
                table: "OrderDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionGroup_Users_CreatedByUserId",
                table: "PermissionGroup",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionGroup_Users_UpdatedByUserId",
                table: "PermissionGroup",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_PermissionGroup_PermissionGroupId",
                table: "PermissionMembership",
                column: "PermissionGroupId",
                principalTable: "PermissionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_Users_CreatedByUserId",
                table: "PermissionMembership",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_Users_UpdatedByUserId",
                table: "PermissionMembership",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionMembership_Users_UserId",
                table: "PermissionMembership",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedByUserId",
                table: "Roles",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UpdatedByUserId",
                table: "Roles",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Branches_BranchId",
                table: "Shipment",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Users_CreatedByUserId",
                table: "Shipment",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Users_UpdatedByUserId",
                table: "Shipment",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Districts_DistrictId",
                table: "Supplier",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Provinces_ProvinceId",
                table: "Supplier",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_SupplierGroup_SupplierGroupId",
                table: "Supplier",
                column: "SupplierGroupId",
                principalTable: "SupplierGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Users_CreatedByUserId",
                table: "Supplier",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Users_UpdatedByUserId",
                table: "Supplier",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Wards_WardId",
                table: "Supplier",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierGroup_Users_CreatedByUserId",
                table: "SupplierGroup",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierGroup_Users_UpdatedByUserId",
                table: "SupplierGroup",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Branches_BranchRequestId",
                table: "SupplierOrder",
                column: "BranchRequestId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Supplier_SupplierId",
                table: "SupplierOrder",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Users_CreatedByUserId",
                table: "SupplierOrder",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrder_Users_UpdatedByUserId",
                table: "SupplierOrder",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrderDetail_Materials_MaterialId",
                table: "SupplierOrderDetail",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrderDetail_SupplierOrder_SupplierOrderId",
                table: "SupplierOrderDetail",
                column: "SupplierOrderId",
                principalTable: "SupplierOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trademark_Users_CreatedByUserId",
                table: "Trademark",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trademark_Users_UpdatedByUserId",
                table: "Trademark",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Branches_BranchId",
                table: "UserBranches",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBranches_Users_UserId",
                table: "UserBranches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Districts_DistrictId",
                table: "Wards",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseArea_Users_CreatedByUserId",
                table: "WarehouseArea",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseArea_Users_UpdatedByUserId",
                table: "WarehouseArea",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseArea_Warehouses_WarehouseId",
                table: "WarehouseArea",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLine_Users_CreatedByUserId",
                table: "WarehouseLine",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLine_Users_UpdatedByUserId",
                table: "WarehouseLine",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLine_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLine",
                column: "WarehouseAreaId",
                principalTable: "WarehouseArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_Users_CreatedByUserId",
                table: "WarehouseLocation",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_Users_UpdatedByUserId",
                table: "WarehouseLocation",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseArea_WarehouseAreaId",
                table: "WarehouseLocation",
                column: "WarehouseAreaId",
                principalTable: "WarehouseArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseLine_WarehouseLineId",
                table: "WarehouseLocation",
                column: "WarehouseLineId",
                principalTable: "WarehouseLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehousePosition_WarehousePositionId",
                table: "WarehouseLocation",
                column: "WarehousePositionId",
                principalTable: "WarehousePosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseRack_WarehouseRackId",
                table: "WarehouseLocation",
                column: "WarehouseRackId",
                principalTable: "WarehouseRack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_Warehouses_WarehouseId",
                table: "WarehouseLocation",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseLocation_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseLocation",
                column: "WarehouseShelvesId",
                principalTable: "WarehouseShelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousePosition_Users_CreatedByUserId",
                table: "WarehousePosition",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousePosition_Users_UpdatedByUserId",
                table: "WarehousePosition",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehousePosition_WarehouseRack_WarehouseRackId",
                table: "WarehousePosition",
                column: "WarehouseRackId",
                principalTable: "WarehouseRack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRack_Users_CreatedByUserId",
                table: "WarehouseRack",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRack_Users_UpdatedByUserId",
                table: "WarehouseRack",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseRack_WarehouseShelves_WarehouseShelvesId",
                table: "WarehouseRack",
                column: "WarehouseShelvesId",
                principalTable: "WarehouseShelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Branches_BranchId",
                table: "Warehouses",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Users_CreatedByUserId",
                table: "Warehouses",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Users_UpdatedByUserId",
                table: "Warehouses",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseShelves_Users_CreatedByUserId",
                table: "WarehouseShelves",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseShelves_Users_UpdatedByUserId",
                table: "WarehouseShelves",
                column: "UpdatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseShelves_WarehouseLine_WarehouseLineId",
                table: "WarehouseShelves",
                column: "WarehouseLineId",
                principalTable: "WarehouseLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
