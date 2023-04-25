using ASM_1670.Data;
using ASM_1670.Enums;
using ASM_1670.Models;
using ASM_1670.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ASM_1670.Controllers
{

    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<User> userManager;

        public BooksController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {

                var books = _context.Books.Where(s => s.NameBook.Contains(SearchString));
                return View(await books.ToListAsync());

            }
            else
            {
                var books = _context.Books.ToList();
                return View(books);
            }
           
        }
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var currentUser = await userManager.GetUserAsync(User);

			var categoriesInDb = _context.Categories
				.Where(c => c.CategoryStatus == CategoryStatus.Successful && c.UserId == currentUser.Id).ToList();
			CategoriesBookViewModel categoryBook = new CategoriesBookViewModel();
			categoryBook.Categories = categoriesInDb;
			return View(categoryBook);

		}

		[HttpPost]
		public async Task<IActionResult> Create(Book book)
		{
			var currentUser = await userManager.GetUserAsync(User);

			book.UserId = currentUser.Id;
			_context.Add(book);
			_context.SaveChanges();


			return RedirectToAction("Index");
		}
		//Detail Book Data
		[HttpGet]
		public IActionResult Detail(int id)
		{
			var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

			return View(bookInDb);
		}

	}
}
