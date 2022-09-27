using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        object Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}