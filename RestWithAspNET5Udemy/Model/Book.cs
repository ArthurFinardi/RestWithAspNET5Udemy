using RestWithAspNET5Udemy.Model.Base;
using System;

namespace RestWithAspNET5Udemy.Model
{
    public class Book : BaseEntity
    {
        public string Author { get; set; }
        public DateTime Launch_Date { get; set; }
        public decimal Price{ get; set; }
        public string Title { get; set; }

    }
}
