using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investeer.Models.ViewModels
{
    public class FileUploadViewModel
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public List<IFormFile> Files { get; set; }
    }
}
