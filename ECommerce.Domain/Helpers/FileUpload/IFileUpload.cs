using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Helpers.FileUpload
{
    public interface IFileUpload
    {
        public (string, string) UploadFile(IFormFile formFilestring, UploadDirectoriesEnum FileFor);
    }
}
