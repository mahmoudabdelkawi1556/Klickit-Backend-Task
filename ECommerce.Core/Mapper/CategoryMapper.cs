using AutoMapper;
using ECommerce.Core.Features.Category.Command.Dtos;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
