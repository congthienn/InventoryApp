﻿using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class CustomerGroupRepository : GenericRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public CustomerGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
