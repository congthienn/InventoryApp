using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface ITrademarkService
    {
        IEnumerable<TrademarkModelRq> GetAllTrademarks();
        Task<TrademarkModelRq> AddTrademark(TrademarkModelRq model, UserIdentity userIdentity);
        Task<TrademarkModelRq> UpdateTrademark(Guid id, TrademarkModelRq model, UserIdentity userIdentity);
        Task<bool> DeleteTrademark(Guid id);
    }
}
