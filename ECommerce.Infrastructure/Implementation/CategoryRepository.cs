using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _context.Categories.Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();
        }
    }
}
