using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly WebStoreDbContext _context;

        public StoreController(WebStoreDbContext context)
        {
            _context = context;
        }

        // GET: Store
        public ActionResult Index()
        {
            var brand = _context.Brands.ToList();
            return View(brand);
        }

        public ActionResult Browse(string brand)
        {
            //Protection against outside users modifying code
            var brandModel = _context.Brands.Include("Phones")
                .Single(c => c.Name == brand);
            return View(brandModel);
        }

        public ActionResult Details(int id)
        {
            var phone = _context.Phones.Find(id);
            return View(phone);
        }

        public ActionResult Apple(string brand)
        {
            //Displays Apple Brand
            var phones = _context.Phones.Include("Brand")
                .Where(c => c.Brand.Name == "Apple");
            return View(phones);
        }

        public ActionResult Samsung(string brand)
        {
            //Displays Apple Brand
            var phones = _context.Phones.Include("Brand")
                .Where(c => c.Brand.Name == "Samsung");
            return View(phones);
        }



        public ActionResult Huawei(string brand)
        {
            //Displays Apple Brand
            var phones = _context.Phones.Include("Brand")
                .Where(c => c.Brand.Name == "Huawei");
            return View(phones);
        }

        public ActionResult Enchro(string brand)
        {
            //Displays Apple Brand
            var phones = _context.Phones.Include("Brand")
                .Where(c => c.Brand.Name == "Enchro");
            return View(phones);
        }

        public ActionResult Google(string brand)
        {
            //Displays Apple Brand
            var phones = _context.Phones.Include("Brand")
                .Where(c => c.Brand.Name == "Google");
            return View(phones);
        }


    }
}