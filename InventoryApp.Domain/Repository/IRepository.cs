using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Repository
{
    public interface IRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
    }
}