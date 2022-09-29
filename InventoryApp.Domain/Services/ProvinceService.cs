using AutoMapper;
using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.AutoMapper;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;

namespace InventoryApp.Infrastructures.Services
{
    public class ProvinceService : IProvinceService
    {
        private IProvinceRepository _provinceRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ProvinceService()
        {
            _unitOfWork = new UnitOfWork();
            _provinceRepository = new ProvinceRepository(_unitOfWork);
            _mapper = new Mapper(GetMapperConfiguration.Run());
        }
        public async Task AddProvince(ProvinceDTO provinceDTO)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Provinces province = new Provinces();
                _mapper.Map(provinceDTO, province);
                await _provinceRepository.Insert(province);
                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                _unitOfWork.Rollback();
                throw new NotImplementedException();
            }
        }
        public Task<IEnumerable<Districts>> GetDitrictsByProvinceId(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Provinces>> GetProvinces()
        {
            return await _provinceRepository.Get();
        }
    }
}
