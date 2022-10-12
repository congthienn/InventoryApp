using AutoMapper;
using InventoryApp.Infrastructures;
using Serilog;

namespace InventoryApp.Domain.Services
{
    public abstract class ServiceBase
    {
        protected IMapper _mapper;
        protected ILogger _logger;
        protected IUnitOfWork _unitOfWork;
        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
    }
}