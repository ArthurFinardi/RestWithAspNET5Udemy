using RestWithAspNET5Udemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithAspNET5Udemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
