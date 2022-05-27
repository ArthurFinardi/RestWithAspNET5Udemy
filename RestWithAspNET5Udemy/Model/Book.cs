﻿using System;

namespace RestWithAspNET5Udemy.Model
{
    public class Book
    {
        public int Id { get; set; } 
        public string Author { get; set; }
        public DateTime Launch_Date { get; set; }
        public decimal Price{ get; set; }
        public string Title { get; set; }

    }
}