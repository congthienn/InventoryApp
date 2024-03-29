﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Http;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IMaterialService
    {
        IEnumerable<ShowMaterialModel> GetAllMaterials();
        Task<ShowMaterialModel> GetMaterialById(Guid materialId);
        Task<ShowMaterialModel> AddMaterial(MaterialModelRq model, List<MaterialAttributeValueModel> attributeValue, List<IFormFile> prictures, UserIdentity userIdentity);
        Task<ShowMaterialModel> UpdateMaterial(Guid materialId, MaterialModelRq model, List<MaterialAttributeValueModel> attributeValue, List<IFormFile> prictures, UserIdentity userIdentity);
        Task<bool> DeleteMaterial(Guid materialId);
        Task<bool> DeleteMaterialPictureById(int pictureId);
        Task<bool> SetMaterialStatus(Guid materialId, StatusModel status, UserIdentity userIdentity);
        Task<IEnumerable<ShowMaterialAttributeValue>> GetMaterialAttributeValue(Guid materialId);
    }
}