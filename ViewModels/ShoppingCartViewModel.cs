using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartPhones { get; set; }
        public decimal CartTotal { get; set; }
    }
}