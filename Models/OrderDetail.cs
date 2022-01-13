using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class OrderDetail
    {
        [Key]
        public int OderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PhoneId { get; set; }
        public int Quantity { get; set; }
        
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public virtual Phone Phone { get; set; }
        public virtual Order Order { get; set; }
    }
}