using Lesson5.Validation.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lesson5.Validation.Models
{
    //[ModelMetadataType(typeof(ProductValidator))]
    public class Product
    {
        public int Quantity { get; set; }

        public string Mail { get; set; }

        public string Name { get; set; }
    }
}
