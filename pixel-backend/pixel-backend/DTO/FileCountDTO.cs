﻿using System;
using System.ComponentModel.DataAnnotations;

namespace pixel_backend.DTO
{
    public class FileCountDTO
    {
        [Required(ErrorMessage = "Please Enter Count")]
        [Range(1,20)]
        public int Count { get; set; }
    }
}
