using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class TrademarkRepository : GenericRepository<Trademark>, ITrademarkRepository
    {
        public TrademarkRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
