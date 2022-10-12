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
                Provinces province = new Provinces(); _mapper.Map(provinceDTO, province);
                if (!ProvinceExist(province.Code).Result)
                    await _provinceRepository.Insert(province);

                Districts district = new Districts(); _mapper.Map(districtDTO, district);
                district.ProvinceId = province.Code;
                await _districtRepository.Insert(district);
                foreach(WardDTO wardDTO in wardsDTO)
                {
                    Wards ward = new Wards(); _mapper.Map(wardDTO, ward);
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
                throw new NotImplementedException();
            }
        }

        public IQueryable GetDistrictById(int districtId)
        {
            return _districtRepository.GetDistrictById(districtId);
        }

        public async Task<IEnumerable<Districts>> GetDitrictsByProvinceId(int provinceId)
        {
            return await _districtRepository.Get(x=>x.ProvinceId == provinceId);
        }

        public IQueryable GetProvinceById(int provinceId)
        {
            return _provinceRepository.GetProvinceById(provinceId);
        }

        public async Task<IEnumerable<Provinces>> GetProvinces()
        {
            return await _provinceRepository.Get();
        }

        public async Task<IEnumerable<Wards>> GeWardsByDistrictId(int districtId)
        {
            return await _wardRepository.Get(x => x.DistrictId == districtId);
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
