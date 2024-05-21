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
    public class LoginDto : IRequest<ApiResponse<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
