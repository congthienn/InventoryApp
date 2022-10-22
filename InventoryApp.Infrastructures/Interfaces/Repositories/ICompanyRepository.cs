﻿using InventoryApp.Infrastructures.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Data.Models;

namespace InventoryApp.Infrastructures.Interfaces.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Companies>
    {
        public Task<bool> RepositoryIsNotEmpty();
    }
}
