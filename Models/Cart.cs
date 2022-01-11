using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int PhoneId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Phone Phone { get; set; }


    }
}