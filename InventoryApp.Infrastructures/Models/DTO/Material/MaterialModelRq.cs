using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class MaterialModelRq
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; set; }
        public int SalePrice { get; set; }
        public int CostPrice { get; set; }
        public string BaseMaterialUnit { get; set; }
        public Guid CategoryMaterialId { get; set; }
        public MaterialCategoryModelRq CategoryMaterial { get; set; }
        public Guid TrademarkId { get; set; }
        public TrademarkModelRq Trademark { get; set; }
        public int MinimumInventory { get; set; }
        public int MaximumInventory { get; set; }
        public double Weight { get; set; }
        public string DetailedDescription { get; set; }
        public List<IFormFile> Prictures { get; set; }
    }
    public class MaterialModelValidator : AbstractValidator<MaterialModelRq>
    {
        public MaterialModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.SalePrice).NotEmpty();
            RuleFor(p => p.CostPrice).NotEmpty();
            RuleFor(p => p.BaseMaterialUnit).NotEmpty();
            RuleFor(p => p.CategoryMaterialId).NotEmpty();
            RuleFor(p => p.TrademarkId).NotEmpty();
            RuleFor(p => p.MinimumInventory).NotEmpty();
            RuleFor(p => p.MaximumInventory).NotEmpty();
        }
    }
}
