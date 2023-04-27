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
            if (id != 0)
            {
                var Order = context.Orders.SingleOrDefault(o => o.Id == id && o.UserId == currentUser.Id);

                var orderDetails = context.OrderDetails
                             .Where(t => t.Order.UserId == currentUser.Id && t.Order.Id == id).ToList();
                foreach (var item in orderDetails)
                {
                    item.Book = context.Books.SingleOrDefault(b => b.Id == item.IdBook);
                }
                viewModelCart.OrderDetails = orderDetails;
                viewModelCart.Order = Order;

                return View(viewModelCart);
            }
            else
            {
                var orderDetails = context.OrderDetails.Include(t => t.Order)
                    .Where(t => t.Order.OrderStatus == Enums.OrderStatus.Unconfirmed).ToList();

                var Order = context.Orders.SingleOrDefault(o => o.OrderStatus == OrderStatus.Unconfirmed && o.UserId == currentUser.Id);
                foreach (var item in orderDetails)
                {
                    item.Book = context.Books.SingleOrDefault(b => b.Id == item.IdBook);
                }


                viewModelCart.OrderDetails = orderDetails;
                viewModelCart.Order = Order;
            }
            return View(viewModelCart);

        }
        [HttpGet]

        public IActionResult Delete(int id)
        {
            var OrderDetail = context.OrderDetails.Include(t => t.Order)
                .SingleOrDefault(t => t.Id == id && t.Order.OrderStatus == OrderStatus.Unconfirmed);

            context.Remove(OrderDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 