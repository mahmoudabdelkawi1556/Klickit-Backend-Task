using ECommerce.Core.Features.Category.Command.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Mapper.MapperDtos
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = null!;
        public UpdateCategoryDto Category { get; set; } = null!;
    }
}
