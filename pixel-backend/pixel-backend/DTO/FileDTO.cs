using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pixel_backend.DTO
{
    public class FileDTO
    {
        public int FileId { get; set; }
        public string Name { get; set; }
        public string RawImageUrl { get; set; }
        public string Src { get; set; }
        public long Views { get; set; }
        public long Likes { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
