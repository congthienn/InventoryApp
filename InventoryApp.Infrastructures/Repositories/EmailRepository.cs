using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.GenericRepository;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Infrastructures.Repositories
{
    public class EmailRepository : GenericRepository<EmailTemplate>, IEmailRepository
    {
        public EmailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<bool> CheckNameExistsAsync(string name)
        {
            return await _dbSet.AnyAsync(x=>x.Name == name);
        }
    }
}
