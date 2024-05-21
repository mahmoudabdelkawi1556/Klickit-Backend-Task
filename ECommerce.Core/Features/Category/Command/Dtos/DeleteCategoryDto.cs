using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Command.Dtos
{
    public class DeleteCategoryDto : IRequest<ApiResponse<string>>
    {
        public Guid? Id { get; set; }
    }
}
