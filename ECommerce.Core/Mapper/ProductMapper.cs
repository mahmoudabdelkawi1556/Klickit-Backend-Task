using AutoMapper;
using ECommerce.Core.Features.Product.Command.Dtos;
using ECommerce.Core.Features.Product.Query.Dtos;
using ECommerce.Core.Mapper.FileUrlResolver;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<AddProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, GetProductsDto>().ReverseMap();
            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ProductUrlFileResolver>())
                .ReverseMap();
        }
    }
}
