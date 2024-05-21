using ECommerce.Domain.Helpers.FileUpload;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public static class DomainCollections
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IFileUpload, FileUpload>();

            return services;
        }
    }
}
