namespace FileServerDemo.Services
{
    public interface ICloudStorageService
    {
        Task<string> GetSignedUrlAsync(string fileName, int timeOut = 30);
        Task<string> UploadFileAsync(IFormFile file, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
