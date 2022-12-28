using FileServerDemo.Models;
using FileServerDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileServerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private static List<Product> products = new();
        private readonly ICloudStorageService cloudStorageService;

        public FileController(ICloudStorageService cloudStorageService)
        {
            this.cloudStorageService = cloudStorageService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            try
            {
                if (product.Photo != null)
                {
                    product.SavedFileName = GenerateFileName(product.Photo.FileName);
                    product.SavedUrl = await cloudStorageService.UploadFileAsync(product.Photo, product.SavedFileName);
                }
                products.Add(product);
                return Ok();
            }
            catch (Exception)
            {
                // log
            }
            return BadRequest();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || products.Count == 0)
                return BadRequest();
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product == null)
                return NotFound();
            await GenerateSignedUrl(product);
            return Ok(product.SignedUrl);
        }

        private async Task GenerateSignedUrl(Product product)
        {
            if (!string.IsNullOrWhiteSpace(product.SavedFileName))
                product.SignedUrl = await cloudStorageService.GetSignedUrlAsync(product.SavedFileName);

        }

        private string? GenerateFileName(string fileName)
        {
            var fn = Path.GetFileNameWithoutExtension(fileName);
            var ex = Path.GetExtension(fileName);
            return $"{fn}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{ex}";
        }
    }
}
