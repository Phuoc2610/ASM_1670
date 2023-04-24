using ASM_1670.Data;
using ASM_1670.Enums;
using ASM_1670.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ASM_1670.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext dbContext;
        UserManager<User> userManager;
        public CategoriesController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var categoriesInDb = dbContext.Categories.Where(c => c.UserId == currentUser.Id).ToList();
            
            return View(categoriesInDb); 
        }

       
    }
}
