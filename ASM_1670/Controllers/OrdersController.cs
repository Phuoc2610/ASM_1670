using ASM_APP_DEV.Data;
using ASM_APP_DEV.Enums;
using ASM_APP_DEV.Models;
using ASM_APP_DEV.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASM_APP_DEV.Controllers
{
    public class OrdersController : Controller
    {
		private ApplicationDbContext context;
        private readonly UserManager<User> userManager;


        public OrdersController(ApplicationDbContext context,  UserManager<User> userManager)
		{
            this.userManager = userManager;

            this.context = context;
		}
		public async Task<IActionResult> IndexAsync()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var oderInDb = context.Orders.Where(o => o.UserId == currentUser.Id ).ToList();
            return View(oderInDb);

        }
       

		

  
    }
}
