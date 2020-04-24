using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BlogApp.WebUI.Utility
{
    public class FileSystemFileUploader : IFileUpload
    {
        private readonly string _filePath;
        
        // * Farkli bir lokasyon secerse
        public FileSystemFileUploader(string filepath)
        {
            this._filePath = filepath;
        }

        // *  Default kayit lokasyonu
        public FileSystemFileUploader()
        {
            this._filePath = "images";
        }
        public FileUploadResult Upload(IFormFile file)
        {
            FileUploadResult result = new FileUploadResult();
            result.FileResult = FileResult.Error;
            result.Message = "Dosya yüklenmesi sırasında hata meydana geldi";
            if(file.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                result.OriginalName = file.FileName;
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(),
                    $"wwwroot/{_filePath}",fileName);

                if(File.Exists(physicalPath))
                {
                    result.Message = "Dizin icerisinde boyle bir dosya mevcuttur.";
                }
                else{
                    result.FileUrl = $"/{_filePath}/{fileName}";
                    result.Base64 = null;
                    try{
                        using var stream = new FileStream(physicalPath, FileMode.Create);
                        file.CopyTo(stream);
                        result.Message = "Dosya başarıyla kaydedildi.";
                        result.FileResult = FileResult.Succeeded;
                    }
                    catch{
                        result.Message = "Dosya kayıt işlemi sırasında hata meydana geldi.";
                        result.FileResult = FileResult.Error;
                    }
                }
            }
            return result;
        }
    }
}