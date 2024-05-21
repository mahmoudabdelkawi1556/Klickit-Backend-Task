using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Interfaces;
using ECommerce.Infrastructure.Specification;
using ECommerce.Infrastructure.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAsNoTracking(ProductSpecification productSpec)
        {
            return SpecificationEvaluator<Product>.GetQueryWithSpec(base.GetAsNoTracking(), productSpec).ToList();
        }
    }
}
