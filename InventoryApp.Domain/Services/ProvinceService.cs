using AutoMapper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.Helper;
using InventoryApp.Domain.Services;
using InventoryApp.Infrastructures.AutoMapper;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Infrastructures.Repositories;
using Serilog;

namespace InventoryApp.Infrastructures.Services
{
    public class ProvinceService : IProvinceService
    {
        private IProvinceRepository _provinceRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IDistrictRepository _districtRepository;
        private IWardRepository _wardRepository;
        private ILogger _log;

        public ProvinceService()
        {
            _unitOfWork = new UnitOfWork();
            _provinceRepository = new ProvinceRepository(_unitOfWork);
            _districtRepository = new DistrictRepository(_unitOfWork);
            _wardRepository = new WardRepository(_unitOfWork);
            _mapper = new Mapper(AutoMapperHelper.GetMapperConfiguration());
            _log = LoggerHelper.GetConfig();
        }
        public async Task AddProvince(ProvinceDTO provinceDTO, DistrictDTO districtDTO, IEnumerable<WardDTO> wardsDTO)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                Provinces province = _mapper.Map<Provinces>(provinceDTO);
                if (!ProvinceExist(province.Code).Result)
                    await _provinceRepository.Insert(province);

                Districts district = _mapper.Map<Districts>(districtDTO);
                district.ProvinceId = province.Code;
                await _districtRepository.Insert(district);
                foreach(WardDTO wardDTO in wardsDTO)
                {
                    Wards ward = _mapper.Map<Wards>(wardDTO);
                    ward.DistrictId = district.Code;
                    await _wardRepository.Insert(ward);
                }
                _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                _log.Error(e.Message);
                _unitOfWork.Rollback();
                throw new NotImplementedException(e.Message);
            }
        }

        public IQueryable GetDistrictById(int districtId)
        {
            return _districtRepository.GetDistrictById(districtId);
        }

        public IEnumerable<Districts> GetDitrictsByProvinceId(int provinceId)
        {
            return _districtRepository.Get(x=>x.ProvinceId == provinceId);
        }

        public IQueryable GetProvinceById(int provinceId)
        {
            return _provinceRepository.GetProvinceById(provinceId);
        }

        public IEnumerable<Provinces> GetProvinces()
        {
            return _provinceRepository.Get();
        }

        public IEnumerable<Wards> GeWardsByDistrictId(int districtId)
        {
            return _wardRepository.Get(x => x.DistrictId == districtId);
        }

        public async Task<bool> RepositoryIsNotEmpty()
        {
            return await _provinceRepository.RepositoryIsNotEmpty();
        }

        private async Task<bool> ProvinceExist(int provinceId)
        {
            return await _provinceRepository.ObjectAlreadyExists(provinceId);
        }
    }
}
