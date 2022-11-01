using InventoryApp.Infrastructures.Interfaces.Services;
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
        public async Task<ShowMaterialModel> AddMaterial(MaterialModelRq model, List<MaterialAttributeValueModel> attributeValue, List<IFormFile> prictures, UserIdentity userIdentity)
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
                await AddMaterialPicture(prictures, material.Id);
                await AddMaterialAttributeValue(attributeValue, material.Id, userIdentity);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                await UploadMultipleFilesToAzureStorage(prictures, material.Id);
                return _mapper.Map<ShowMaterialModel>(material);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
        private async Task AddMaterialPicture(List<IFormFile> prictures, Guid materialId)
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
        private async Task UploadMultipleFilesToAzureStorage(List<IFormFile> prictures, Guid materialId)
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
                await _materialRepository.DeleteAllMaterialAttributeValueByMaterialId(materialId);
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
        public async Task<ShowMaterialModel> UpdateMaterial(Guid materialId, MaterialModelRq model, List<MaterialAttributeValueModel> attributeValue, List<IFormFile> prictures, UserIdentity userIdentity)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Materials material = await _materialRepository.GetByID(materialId);
                if (material == null)
                    throw new NotImplementedException("Material not found");

                _mapper.Map(model, material);
                material.Id = materialId;
                material.CodeName = StringHelper.NormalizeString(model.Name);
                material.UpdateBy(userIdentity);

                await _materialRepository.Update(material);
                await AddMaterialPicture(prictures, materialId);
                await UpdateMaterialAttributeValue(attributeValue, materialId, userIdentity);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                await UploadMultipleFilesToAzureStorage(prictures, materialId);
                return _mapper.Map<ShowMaterialModel>(material);
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
        public async Task<bool> DeleteMaterialPictureById(int pictureId)
        {
            try
            {
                MaterialPicture materialPicture = await _materialRepository.GetMaterialPictureById(pictureId);
                if (materialPicture == null)
                    throw new NotImplementedException("Picture not found");

                await _materialRepository.DeleteMaterialPictureById(pictureId);
                _unitOfWork.Save();
                await _azureStorage.DeleteAsync(materialPicture.PictureURL);
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
        public async Task<bool> SetMaterialStatus(Guid materialId, StatusModel status, UserIdentity userIdentity)
        {
            Materials material = await _materialRepository.GetByID(materialId);
            if (material == null)
                throw new NotImplementedException("Material not found");

            material.StopBusiness = status.Status;
            material.UpdateBy(userIdentity);
            _unitOfWork.Save();

            return true;
        }
        private async Task AddMaterialAttributeValue(List<MaterialAttributeValueModel> attributeValue, Guid materialId, UserIdentity userIdentity)
        {
            foreach(var model in attributeValue)
            {
                MaterialAttributeValue materialAttributeValue = _mapper.Map<MaterialAttributeValue>(model);
                materialAttributeValue.MaterialId = materialId;
                materialAttributeValue.CreateBy(userIdentity); materialAttributeValue.UpdateBy(userIdentity);
                await _materialRepository.AddMaterialAttributeValue(materialAttributeValue);
            }
        }
        private async Task UpdateMaterialAttributeValue(List<MaterialAttributeValueModel> attributeValue, Guid materialId, UserIdentity userIdentity)
        {
            foreach (var model in attributeValue)
            {
                MaterialAttributeValue materialAttributeValue = await _materialRepository.GetMaterialAttributeValue(materialId, model.MaterialAttributeId);
                _mapper.Map(model, materialAttributeValue);
                materialAttributeValue.UpdateBy(userIdentity);
                await _materialRepository.UpdateMaterialAttributeValue(materialAttributeValue);
            }
        }

        public async Task<IEnumerable<ShowMaterialAttributeValue>> GetMaterialAttributeValue(Guid materialId)
        {
            return _mapper.Map<IEnumerable<ShowMaterialAttributeValue>>(await _materialRepository.GetMaterialAttributeValue(materialId));
        }

        public async Task<MaterialPositionModel> AddMaterialPosition(MaterialPositionModel model)
        {
            try
            {
                MaterialPosition materialPosition = _mapper.Map<MaterialPosition>(model);
                await _materialRepository.AddMaterialPosition(materialPosition);
                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task DeleteMaterialPositionById(int materialPositionId)
        {
            try
            {
                MaterialPosition materialPosition = await _materialRepository.GetMaterialPositionById(materialPositionId);
                if (materialPosition == null)
                    throw new NotImplementedException("Material Position not found");

                await _materialRepository.Delete(materialPosition);
                _unitOfWork.Save();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<MaterialPositionModel> UpdateMaterialPosition(int id, MaterialPositionModel model)
        {
            await DeleteMaterialPositionById(id);
            return await AddMaterialPosition(model);
        }
    }
}   