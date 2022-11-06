using AutoMapper;
using InventoryApp.Common.Helper;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Services
{
    public class MaterialQuotationService : IMaterialQuotationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMaterialQuotationRepository _materialQuotationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public MaterialQuotationService(IMapper mapper, ILogger<MaterialQuotationService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _materialQuotationRepository = new MaterialQuotationRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MaterialQuotationModel> AddMaterialQuotation(MaterialQuotationModel model, UserIdentity userIdentity)
        {
            try
            {
                MaterialQuotation materialQuotation = _mapper.Map<MaterialQuotation>(model);
                string code = await _materialQuotationRepository.GetLastCode();
                materialQuotation.Code = code == null ? "GBS000001" : StringHelper.CreateCode(code);
                materialQuotation.CreateBy(userIdentity);
                materialQuotation.UpdateBy(userIdentity);

                await _materialQuotationRepository.Insert(materialQuotation);
                _unitOfWork.Save();
                return _mapper.Map<MaterialQuotationModel>(materialQuotation);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteMaterialQuotation(string code)
        {
            try
            {
                MaterialQuotation materialQuotation = await _materialQuotationRepository.GetMaterialQuotationByCode(code);
                if (materialQuotation == null)
                    throw new NotImplementedException("MaterialQuotation not found");

                await _materialQuotationRepository.Delete(materialQuotation);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<MaterialQuotationModel> GetAllMaterialQuotationByMaterialId(Guid materialId)
        {
            return _mapper.Map<IEnumerable<MaterialQuotationModel>>(_materialQuotationRepository.GetAllMaterialQuotationByMaterialId(materialId));
        }

        public async Task<MaterialQuotationModel> GetMaterialQuotationByMaterialIdAndQuantity(Guid materialId, int quantity)
        {
            return _mapper.Map<MaterialQuotationModel>(await _materialQuotationRepository.GetMaterialQuotationByMaterialIdAndQuantity(materialId, quantity));
        }

        public async Task<MaterialQuotationModel> UpdateMaterialQuotation(string code, MaterialQuotationModel model, UserIdentity userIdentity)
        {
            try
            {
                MaterialQuotation materialQuotation = await _materialQuotationRepository.GetMaterialQuotationByCode(code);
                if (materialQuotation == null)
                    throw new NotImplementedException("MaterialQuotation not found");

                model.MaterialId = materialQuotation.MaterialId;
                _mapper.Map(model, materialQuotation);

                materialQuotation.Code = code;
                materialQuotation.UpdateBy(userIdentity);
                await _materialQuotationRepository.Update(materialQuotation);
                _unitOfWork.Save();

                return _mapper.Map<MaterialQuotationModel>(materialQuotation);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
