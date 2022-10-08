using EfCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreExample.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext dbContext;// = new AppDbContext();
		public HomeController(AppDbContext _dbContext)
		{
			dbContext = _dbContext;
		}

		public IActionResult Index()
        {
            //AppDbContext dbContext = new AppDbContext();
            var result = dbContext.Products.Take(10).ToList();
            return View(result); // view'a modeli bind et...
        }

        public IActionResult List(int? Id)
        {
            //AppDbContext dbContext = new AppDbContext();
            var result = dbContext.Products.Where(c => c.CategoryId == Id).ToList();
            return View(result);
        }
    }
}

// uygulamadıki instancleri yönetmek için IOC kütüphaneleri kullanılır. bu kütüphaneler uygulama içerisindeki instancelerin yönetiminden sorumludur. instanceler tek bir yerden oluşturulup (seviyeleri) program içerisinde kullanılır. Kullanılan bazı IOC framework;
// autofac
// ninject
// unity

// .net core'de bu kütüphaneler bkullanılabileceği gibi built-in gelen ioc yapısa kullanılabilir. başka bir deyişler ioc yapısı asp.net core'da built-in (dahili) gelmektedir


 // Dependency Inversion Prensib (DIP) => bağımlılığı tersine çevir.
 // Dependency Injection         (DI)  => bağımlılığı enjecte et..
 // IoC container                      => DI uygula