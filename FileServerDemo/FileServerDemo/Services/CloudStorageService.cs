using FileServerDemo.Utilities;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Options;

namespace FileServerDemo.Services
{
    public class CloudStorageService : ICloudStorageService
    {
        private readonly GCSConfigOptions options;
        private readonly GoogleCredential credential;


        public CloudStorageService(IOptions<GCSConfigOptions> options)
        {
            this.options = options.Value;
            try
            {
                credential = GoogleCredential.FromFile(this.options.GCPStorageAuthFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteFileAsync(string fileName)
        {
            try
            {
                using var storageClient = StorageClient.Create(credential);
                await storageClient.DeleteObjectAsync(options.GoogleCloudStorageBucketName, fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<string> GetSignedUrlAsync(string fileName, int timeOut = 30)
        {
            try
            {
                var sac = credential.UnderlyingCredential as ServiceAccountCredential;
                var urlSigner = UrlSigner.FromServiceAccountCredential(sac);
                var singedUrl = await urlSigner.SignAsync(options.GoogleCloudStorageBucketName, fileName, TimeSpan.FromMinutes(timeOut));
                return singedUrl;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file, string fileName)
        {
            try
            {
                using MemoryStream ms = new();
                await file.CopyToAsync(ms);
                using var storageClient = StorageClient.Create(credential);
                var uploadFile = await storageClient.UploadObjectAsync(options.GoogleCloudStorageBucketName, fileName, file.ContentType, ms);
                return uploadFile.MediaLink;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
