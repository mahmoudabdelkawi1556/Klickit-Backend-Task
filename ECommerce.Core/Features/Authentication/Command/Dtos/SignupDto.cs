using ECommerce.Core.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace ECommerce.Core.Features.Authentication.Command.Dtos
{
    public class SignupDto : IRequest<ApiResponse<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
    }
}
