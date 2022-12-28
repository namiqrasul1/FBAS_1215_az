using System.ComponentModel.DataAnnotations.Schema;

namespace FileServerDemo.Models
{
    public class Product
    {
        private static int staticId = 0;
        public int? Id { get; set; } = staticId++;
        public string? Name { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string? SavedUrl { get; set; }
        [NotMapped]
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }
    }
}
