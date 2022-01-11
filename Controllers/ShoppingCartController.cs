using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Data;
using WebStore.Models;

using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ShoppingCartController : Controller
    {
      
        
            private readonly WebStoreDbContext _context;

            public ShoppingCartController(WebStoreDbContext context)
            {
                _context = context;
            }


            public ActionResult Index()
            {
                var cart = ShoppingCart.GetCart(_context);


                var viewModels = new ShoppingCartViewModel
                {
                    CartPhones = cart.GetCartPhones(),
                    CartTotal = cart.GetTotal()
                };

                return View(viewModels);
            }


        
    }
}