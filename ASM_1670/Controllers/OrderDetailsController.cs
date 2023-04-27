using ASM_1670.Data;
using ASM_1670.Enums;
using ASM_1670.Models;
using ASM_1670.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASM_1670.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ApplicationDbContext context;
        private readonly UserManager<User> userManager;

        public OrderDetailsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            var viewModelCart = new ViewModelCart();
            var currentUser = await userManager.GetUserAsync(User);
            viewModelCart.Address = currentUser.Address;
            viewModelCart.FullName = currentUser.FullName;
            viewModelCart.Phone = currentUser.PhoneNumber;
            

        }
        [HttpGet]


    }
}