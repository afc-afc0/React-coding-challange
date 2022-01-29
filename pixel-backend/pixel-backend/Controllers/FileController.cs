using Microsoft.AspNetCore.Mvc;
using pixel_backend.DTO;
using Service;
using System.Threading.Tasks;

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

        [HttpGet("Random")]
        public IActionResult GetRandomImageFiles([FromQuery]FileCountDTO fileCountDTO)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(BadRequest("Count should be between 1 - 20"));
            }
            
            return new JsonResult(_fileService.GetRandomImageFiles(fileCountDTO.Count));
        }
    }
}
