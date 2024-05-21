using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Authentication.Command.Dtos
{
    public class ChangePasswordDto : IRequest<ApiResponse<string>>
    {
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
    }
}
