﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Routes
{
    public static class CategoryRoutes
    {
        public const string GetCategories = "api/categories";
        public const string GetCategoryById = "api/categories/{id}";
        public const string AddCategory = "api/categories";
        public const string UpdateCategory = "api/categories";
        public const string DeleteCategory = "api/categories/{id}";
    }
}
