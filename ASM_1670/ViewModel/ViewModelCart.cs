using ASM_1670.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASM_1670.ViewModel
{
    public class ViewModelCart
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Order Order { get; set; }
        [BindProperty]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
