﻿using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class MaterialCategoryController : BaseController
    {
        private readonly IMaterialCategoryService _materialCategoryService;
        public MaterialCategoryController(IMaterialCategoryService materialCategoryService) 
        {
            _materialCategoryService = materialCategoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<MaterialCategoryModelRq> GetAllCategory()
        {
            return _materialCategoryService.GetAllCategory();
        }
        [AllowAnonymous]
        [Route("GetMaterialCategoryById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMaterialCategoryById(Guid id)
        {
            return Ok(await _materialCategoryService.GetMaterialCategoryById(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> AddMaterialCategory([FromBody]MaterialCategoryModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialCategoryService.AddMaterialCategory(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialCategory(Guid id, [FromBody]MaterialCategoryModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _materialCategoryService.UpdateMaterialCategory(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialCategory(Guid id)
        {
            try
            {
                return Ok(await _materialCategoryService.DeleteMaterialCategory(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [Route("{categoryId}/GetAllMaterials")]
        [HttpGet]
        public async Task<IActionResult> GetAllMaterialByCategoryId(Guid categoryId)
        {
            return Ok(await _materialCategoryService.GetAllMaterialByCategoryId(categoryId));
        }

        [Route("{categoryId}/GetAllMaterialAttribute")]
        [HttpGet]
        public IEnumerable<MaterialAttributeModel> GetAllMaterialAttributeByCategoryId(Guid categoryId)
        {
            return _materialCategoryService.GetAllMaterialAttributeByCategoryId(categoryId);
        }
    }
}
