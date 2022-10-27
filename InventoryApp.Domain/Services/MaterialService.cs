using InventoryApp.Infrastructures.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Http;
using InventoryApp.Data.Helper;
using Microsoft.Extensions.Logging;
using InventoryApp.Infrastructures;
using AutoMapper;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Repositories;
using InventoryApp.Common.Helper;
using InventoryApp.Domain.Azure;

namespace InventoryApp.Domain.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAzureStorage _azureStorage;
        public MaterialService(ILogger<MaterialService> logger, IMapper mapper, IAzureStorage azureStorage) 
        {
            _unitOfWork = new UnitOfWork();
            _materialRepository = new MaterialRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
            _azureStorage = azureStorage;
        }
        public async Task<ShowMaterialModel> AddMaterial(MaterialModelRq model, List<IFormFile> prictures, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Materials material = _mapper.Map<Materials>(model);

                string code = await _materialRepository.GetLastCode();
                material.Code = code == null ? "SP000001" : StringHelper.CreateCode(code);
                material.CodeName = StringHelper.NormalizeString(model.Name);
                material.CreateBy(userIdentity); material.UpdateBy(userIdentity);

                await _materialRepository.Insert(material);
                AddMaterialPicture(prictures, material.Id);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                await UploadFileToAzureStorage(prictures, material.Id);
                return _mapper.Map<ShowMaterialModel>(material);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        private async void AddMaterialPicture(List<IFormFile> prictures, Guid materialId)
        {
            foreach (IFormFile file in prictures)
            {
                MaterialPicture materialPicture = new MaterialPicture
                {
                    PictureURL = $"{materialId}-{file.FileName}",
                    MaterialId = materialId
                };
                await _materialRepository.AddMaterialPicture(materialPicture);
            }
        }

        private async Task UploadFileToAzureStorage(List<IFormFile> prictures, Guid materialId)
        {
            foreach (IFormFile file in prictures)
            {
                await _azureStorage.UploadAsync(file, materialId);
            }
        }
        private async Task DeleteFileToAzureStorage(List<MaterialPicture> materialPictureList)
        {
            foreach(var picture in materialPictureList)
            {
                await _azureStorage.DeleteAsync(picture.PictureURL);
            }
        }
        public async Task<bool> DeleteMaterial(Guid materialId)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Materials material = await _materialRepository.GetMaterialById(materialId);
                
                if (material == null)
                    throw new NotImplementedException("Material not found");

                await _materialRepository.DeleteAllPictureOfMaterial(materialId);
                await _materialRepository.Delete(material);
                _unitOfWork.Save();
                _unitOfWork.Commit();

                List<MaterialPicture> materialPictureList = new List<MaterialPicture>(material.Pictures);
                await DeleteFileToAzureStorage(materialPictureList);

                return true;
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<ShowMaterialModel> GetAllMaterials()
        {
            return _mapper.Map<IEnumerable<ShowMaterialModel>>(_materialRepository.Get());
        }

        public async Task<ShowMaterialModel> GetMaterialById(Guid materialId)
        {
            Materials material = await _materialRepository.GetMaterialById(materialId);
            return _mapper.Map<ShowMaterialModel>(material);
        }

        public Task<ShowMaterialModel> UpdateMaterial(Guid materialId, MaterialModelRq model, List<IFormFile> prictures, UserIdentity userIdentity)
        {
            throw new NotImplementedException();
        }
    }
}
