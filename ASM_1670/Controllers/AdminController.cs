using ASM_1670.Data;
using ASM_1670.Enums;
using ASM_1670.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ASM_1670.Controllers
{

   
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext context;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<User> _userManager;

		public AdminController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
			_userManager = userManager;
			_roleManager = roleManager;
            this.context = context;
        }
        [HttpGet]
		//Get account neu co id thi se tim theo role
        public IActionResult Index(int id) {

			if (id == 1)
			{
				var accountsInDb = _userManager.GetUsersInRoleAsync("user").Result;
				return View( accountsInDb);
			}
			else if(id == 2)
			{
				var accountsInDb = _userManager.GetUsersInRoleAsync("storeOwner").Result;
				return View(accountsInDb);
			}
			else {
				var accounts = context.Users.ToList();
				return View(accounts);
			}
        }
       


    }
}
