using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Data;
using WebStore.Models;
using System.Text.Encodings.Web;

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

        public ActionResult AddToCart(int id)
        {

            var addedPhone = _context.Phones
                .Single(phone => phone.PhoneId == id);


            var cart = ShoppingCart.GetCart(_context);

            cart.AddToCart(addedPhone);


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = ShoppingCart.GetCart(_context);


            string phoneName = _context.Carts
                .Single(phone => phone.RecordId == id).Phone.Title;


            int phoneCount = cart.RemoveFromCart(id);


            var results = new ShoppingCartRemoveViewModel
            {
                Message = HtmlEncoder.Default.Encode(phoneName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = phoneCount,
                DeleteId = id
            };
            return Json(results);
        }

        
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(_context);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }


    }
}
        
    