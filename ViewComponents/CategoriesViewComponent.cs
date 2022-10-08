using EfCoreExample.Controllers;
using EfCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreExample.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        AppDbContext dbContext; // = new AppDbContext();
		public CategoriesViewComponent(AppDbContext _dbContext)
		{
			dbContext = _dbContext;
		}
		public IViewComponentResult Invoke()
        {
            //AppDbContext dbContext= new AppDbContext();
            var result = dbContext.Categories.ToList();

            return View(result);
        }
    }
}
