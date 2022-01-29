using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using pixel_backend.Core.Settings;
using pixel_backend.DTO;
using Service;
using System;
using System.Threading.Tasks;
using Infastructure.Entities;

namespace pixel_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    { 
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        } 

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return new JsonResult(await _fileService.GetFileById(id));
        }
    }
}
