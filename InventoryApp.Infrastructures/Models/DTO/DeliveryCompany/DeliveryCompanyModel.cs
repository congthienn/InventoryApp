using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class DeliveryCompanyModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; private set; }
        public string CodeName { get; private set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string TaxCode { get; set; }

        public bool Status { get; set; } = true;
        public Guid BranchId { get; set; }
        public BranchModelRq Branch { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public ProvinceDTO Province { get; set; }
        public int DistrictId { get; set; }
        public DistrictDTO District { get; set; }
        public int WardId { get; set; }
        public WardDTO Ward { get; set; }
    }
}
