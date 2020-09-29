using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MusicApplication.Data.Interfaces;
using MusicApplication.Models;
using System.IO;

namespace MusicApplication.Services
{
    public class FileService : IFileService
    {
        private readonly IGenericRepository<Album> _repository;
        private readonly IWebHostEnvironment _appEnvironment;
        public FileService(IGenericRepository<Album> repository, IWebHostEnvironment appEnvironment)
        {
            _repository = repository;
            _appEnvironment = appEnvironment;
        }

        public void UploadAlbumLogo(IFormFile uploadFile, int albumId)
        {
            var album = _repository.FindById(albumId);

            var path = "/images/" + albumId + ".png";

            album.LogoPath = path;
            _repository.Update(album);

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                uploadFile.CopyTo(fileStream);
            }
        }
        public string GetLogoPath(int albumId)
        {
            var logoPath = _repository.FindById(albumId).LogoPath;
            var path = Path.Combine(_appEnvironment.WebRootPath, "images", logoPath);

            return path;
        }
    }
}
