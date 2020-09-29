using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApplication.Data.Interfaces;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {

        private readonly IFileService _service;
        public FileController(IFileService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLogo(int id)
        {
            var path = _service.GetLogoPath(id);
            return File(path, "image/png");
        }

        [HttpPost]
        public void Add([FromForm] IFormFile uploadFile) => _service.UploadAlbumLogo(uploadFile, 2);
    }
}