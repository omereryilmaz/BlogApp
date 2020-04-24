using Microsoft.AspNetCore.Http;

namespace BlogApp.WebUI.Utility
{
    public interface IFileUpload
    {
        public FileUploadResult Upload(IFormFile file);
    }
}