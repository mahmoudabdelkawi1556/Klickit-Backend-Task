﻿using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.UserProfile.Query.Dtos
{
    public class GetMeDto : IRequest<ApiResponse<UserDto>>
    {
    }
}