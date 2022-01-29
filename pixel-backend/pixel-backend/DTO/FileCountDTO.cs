using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pixel_backend.DTO
{
    public class FileCountDTO
    {
        [Required(ErrorMessage = "Please Enter Count")]
        [Range(1,20)]
        public int Count { get; set; }
    }
}
