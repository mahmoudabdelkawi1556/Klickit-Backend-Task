using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Routes
{
    public class ProductRoutes
    {
        public const string GetProducts = "api/products";
        public const string GetProductById = "api/products/{id}";
        public const string AddProduct = "api/products";
        public const string UpdateProduct = "api/products";
        public const string DeleteProduct = "api/products/{id}";
        public const string ApproveProduct = "api/products/approve/";
        public const string GetNotApproved = "api/products/get-not-approved/";
    }
}
