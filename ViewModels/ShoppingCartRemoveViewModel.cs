using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int PhoneCount { get; set; }
        public int DeleteId { get; set; }
    }
}