using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Command.Dtos
{
    public class ApproveProductDto : IRequest<ApiResponse<string>>
    {
        public Guid? Id { get; set; }
    }
}
