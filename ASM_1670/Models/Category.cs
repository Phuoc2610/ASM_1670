﻿
using ASM_1670.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ASM_1670.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string NameCategory { get; set; }
        public CategoryStatus CategoryStatus { get; set; }

        public List<Book> Books { get; set; }
    }
}
