using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Specification
{
    public class ProductSpecification 
        : BaseSpecification<Product>
    {
        public ProductSpecification(Guid?id, string? name, string? description, decimal? price, Guid? categoryId, string? categoryName, int? quantity, bool IsApproved, int pageSize = 10, int pageNumber = 1)
        {
            if (id.HasValue)
            {
                AddCriteria(p => p.Id == id);
            }
            if (!string.IsNullOrEmpty(name))
            {
                AddCriteria(p => p.Name == name);
            }
            if (!string.IsNullOrEmpty(description))
            {
                AddCriteria(p => p.Description == description);
            }
            if (price.HasValue)
            {
                AddCriteria(p => p.Price == price);
            }
            if (categoryId.HasValue)
            {
                AddCriteria(p => p.CategoryId == categoryId);
            }
            if (quantity.HasValue)
            {
                AddCriteria(p => p.Quantity == quantity);
            }
            if (!string.IsNullOrEmpty(categoryName))
            {
                AddInclude(p => p.Category);
                AddCriteria(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()) || categoryName.ToLower().Contains(p.Category.Name.ToLower()));
            }
            if (IsPaginationEnabled)
            {
                ApplyPagination(pageSize, pageNumber);
            }
            AddCriteria(p => p.IsApproved == IsApproved);

            AddInclude(p => p.Category);

            AddOrderByDesc(x => x.CreatedAt);
        }
    }
}
