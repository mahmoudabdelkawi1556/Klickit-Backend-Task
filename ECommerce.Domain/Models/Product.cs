using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsApproved { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
