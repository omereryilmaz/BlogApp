namespace BlogApp.WebUI.Utility
{
    public class FileUploadResult
    {
         public string FileUrl { get; set; }
         public string OriginalName { get; set; }
         public string Base64 { get; set; }
         public FileResult FileResult { get; set; }
         public string Message { get; set; }
    }
}
