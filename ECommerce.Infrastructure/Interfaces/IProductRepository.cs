using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Implementation;
using ECommerce.Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IEnumerable<Product> GetAsNoTracking(ProductSpecification productSpec);
    }
}
