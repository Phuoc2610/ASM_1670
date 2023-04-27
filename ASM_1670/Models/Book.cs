using System.Collections.Generic;
using System;

namespace ASM_1670.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int IdCategory { get; set; }
        public string NameBook { get; set; }
        public int QuantityBook { get; set; }
        public int PriceBook { get; set; }
        public string InformationBook { get; set; }

        public string Author { get; set; }
        public DateTime CreateAt { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
