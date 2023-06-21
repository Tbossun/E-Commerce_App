using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace E_Coms_Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Product Type")]
        public string ProductType { get; set; }

        [ValidateNever]
        public string? ProductImage { get; set; }

        [Required]
        [DisplayName("Batch Number")]
        public string BatchNumber { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("List")]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [DisplayName("Price 1 - 50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Price 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [DisplayName("Price 100+")]
        [Range(1, 5000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
