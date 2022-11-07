using System.ComponentModel.DataAnnotations;

namespace Lesson5.Validation.Models.ModelMetadataTypes
{
    public class ProductValidator
    {
        [Required(ErrorMessage = "Quantity is Not Null")] 
        public int Quantity { get; set; }

        [EmailAddress(ErrorMessage = "You should use '@' and '.'")]
        public string Mail { get; set; }

        [StringLength(10)]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
