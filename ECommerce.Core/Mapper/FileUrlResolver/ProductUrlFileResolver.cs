using AutoMapper;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Mapper.FileUrlResolver
{
    public class ProductUrlFileResolver : IValueResolver<Product, ProductResponseDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductUrlFileResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
        {
            if (source.ImageUrl is not null)
                return Path.Combine(configuration["MainServerUrl"], UploadDirectoriesEnum.Product.ToString(), source.ImageUrl);
            return null;
        }
    }
}
