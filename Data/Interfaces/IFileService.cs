using Microsoft.AspNetCore.Http;

namespace MusicApplication.Data.Interfaces
{
    public interface IFileService
    {
        void UploadAlbumLogo(IFormFile uploadedFile, int albumId);
        string GetLogoPath(int albumId);
    }
}
