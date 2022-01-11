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
            var Brand = _context.Brands.ToList();
            return View(Brand);
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
            var Phone = _context.Phones.Find(id);
            return View(Phone);
        }
    }
}