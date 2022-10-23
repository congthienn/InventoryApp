using AutoMapper;
using InventoryApp.Data.Helper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;
using Microsoft.Extensions.Logging;

namespace InventoryApp.Domain.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public ShipmentService(ILogger<ShipmentService> logger, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _shipmentRepository = new ShipmentRepository(_unitOfWork);
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ShipmentModelRq> AddShipment(ShipmentModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Shipment shipment = _mapper.Map<Shipment>(model);
                shipment.Id = Guid.NewGuid();
                shipment.CreateBy(userIdentity);
                shipment.UpdateBy(userIdentity);
                await _shipmentRepository.Insert(shipment);
                _unitOfWork.Save();
                return model;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public async Task<bool> DeleteShipment(string shipmentId)
        {
            try
            {
                Shipment shipment = _shipmentRepository.Get(x => x.Code == shipmentId).FirstOrDefault();
                await _shipmentRepository.Delete(shipment);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<ShipmentModelRq> GetAllShipments()
        {
            return _mapper.Map<IEnumerable<ShipmentModelRq>>(_shipmentRepository.Get());
        }

        public async Task<ShipmentModelRq> UpdateShipment(string shipmentId, ShipmentModelRq model, UserIdentity userIdentity)
        {
            try
            {
                Shipment shipment = _shipmentRepository.Get(x=>x.Code == shipmentId).FirstOrDefault();
                if (shipment == null)
                    throw new NotImplementedException("Shipment not found");

                _mapper.Map(model, shipment);
                await _shipmentRepository.Update(shipment);
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
