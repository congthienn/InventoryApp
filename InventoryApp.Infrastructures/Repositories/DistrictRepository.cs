﻿using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Repositories
{
    public class DistrictRepository : GenericRepository<Districts>, IDistrictRepository
    {
        public DistrictRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}