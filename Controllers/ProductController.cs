using EfCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreExample.Controllers
{
    public class ProductController : Controller
    {
        // readonly => üyelere atama sadece sınıfın constructor'inda yapılır
        readonly AppDbContext dbContext;
        readonly string deneme;
        public ProductController(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
            deneme = "Selam";
        }

        public IActionResult Index(int CatId)
        {
            // deneme = "Selam"; // sadece sınıfın ctorunda atama yapılabilir...
            var result = dbContext.Products.Where(c => c.CategoryId == CatId).ToList();
            return View(result);
        }

        public IActionResult Detay(int ProductId)
		{
            // Find geriye tek bir nesne döner.Nesnenin tipi entity tipindedir. Verilern parametre ile PK'da arama yapar. eğer farklı bir alanda arama yapılacaksa First, FirstOrDefault,Single,SingleOrDefault metotlarından birisi ile lambda ifadesi kullanılabilir..

            var result = dbContext.Products.Find(ProductId);
            return View(result);
		}
    }
}