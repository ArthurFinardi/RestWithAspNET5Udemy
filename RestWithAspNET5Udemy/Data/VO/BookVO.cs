using RestWithAspNET5Udemy.Hypermedia;
using RestWithAspNET5Udemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public int Id { get; set; } 
        public string Author { get; set; }
        public DateTime Launch_Date { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
