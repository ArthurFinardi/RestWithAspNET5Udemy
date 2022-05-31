
using RestWithAspNET5Udemy.Hypermedia;
using RestWithAspNET5Udemy.Hypermedia.Abstract;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestWithAspNET5Udemy.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        //[JsonPropertyName("code")]
        public int Id { get; set; }
        //[JsonIgnore]
        public string Address { get; set; }
        //[JsonPropertyName("first-name")]
        public string FirstName { get; set; }
        //[JsonPropertyName("last-name")]
        public string LastName { get; set; }
        //[JsonPropertyName("sex")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
