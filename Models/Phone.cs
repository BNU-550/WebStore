using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Models
{
    [Bind]
    public class Phone
    {
        [ScaffoldColumn(false)]
        public int PhoneId { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; }

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = " A Phone title is required.")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = " A Phone title is required.")]
        [Range(100, 2000, ErrorMessage = " Price must not be less than 100 or exceed 2000")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName="money")]
        public decimal Price { get; set; }

        [DisplayName("Phone Image URL")]
        [StringLength(1024)]
        public string PhoneArtUrl { get; set; }

        // Navigation properties

        public virtual Brand Brand { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}