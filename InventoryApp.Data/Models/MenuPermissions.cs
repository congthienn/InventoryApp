using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data.Models
{
    [Table("MenuPermissions")]
    public class MenuPermissions
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PermissionGroupId { get; set; }
        [ForeignKey("PermissionGroupId")]
        public PermissionGroup? PermissionGroup { get; set; }
        public bool QuotationsMenu { get; set; }
        public bool CreateQuotationMenu { get; set; }
        public bool RulesQuotationMenu { get; set; }
        public bool CustomerQuotaionMenu { get; set; }
        public bool MonthlyReportQuotaionMenu { get; set; }
        public bool SummarizeReportQuotaionMenu { get; set; }
        public bool ShippingCostQuotationMenu { get; set; }
        public bool ContractsMenu { get; set; }
        public bool CreateContractMenu { get; set; }
        public bool ContractTemplateMenu { get; set; }
        public bool OrdersMenu { get; set; }
        public bool CreateOrderMenu { get; set; }
        public bool BillMenu { get; set; }
        public bool OrderReportMenu { get; set; }
        public bool LibraryMenu { get; set; }
        public bool CustomerLibraryMenu { get; set; }
        public bool OtherMenu { get; set; }
        public bool HRMMenu { get; set; }
        public bool UserMenu { get; set; }
        public bool AssetMenu { get; set; }
        public bool SystemMenu { get; set; }
        public bool StructureMenu { get; set; }
        public bool InventoryMenu { get; set; }
        public bool PurchaseMenu { get; set; }
        public bool ServiceMenu { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public Users? CreatedByUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUserId { get; set; }
        [ForeignKey("UpdatedByUserId")]
        public Users? UpdatedByUser { get; set; }
    }
}
