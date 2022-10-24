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
    public class TrademarkService : ITrademarkService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ITrademarkRepository _trademarkRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TrademarkService(ILogger<TrademarkService> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = new UnitOfWork();
            _trademarkRepository = new TrademarkRepository(_unitOfWork);
        }

        public async Task<TrademarkModelRq> AddTrademark(TrademarkModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Trademark trademark = _mapper.Map<Trademark>(model);
                trademark.CodeName = StringHelper.NormalizeString(model.Name);
                trademark.CreateBy(userIdentity);
                trademark.UpdateBy(userIdentity);
                await _trademarkRepository.Insert(trademark);
                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteTrademark(Guid id)
        {
            try
            {
                Trademark trademark = await _trademarkRepository.GetByID(id);
                await _trademarkRepository.Delete(trademark);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<TrademarkModelRq> GetAllTrademarks()
        {
            return _mapper.Map<IEnumerable<TrademarkModelRq>>(_trademarkRepository.Get());
        }

        public async Task<TrademarkModelRq> UpdateTrademark(Guid id, TrademarkModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Trademark trademark = await _trademarkRepository.GetByID(id);
                if (trademark == null)
                    throw new NotImplementedException("Trademark not found");

                _mapper.Map(model, trademark);
                trademark.Id = id;
                trademark.CodeName = StringHelper.NormalizeString(model.Name);
                trademark.UpdateBy(userIdentity);
                await _trademarkRepository.Update(trademark);
                _unitOfWork.Save();

                return model;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
