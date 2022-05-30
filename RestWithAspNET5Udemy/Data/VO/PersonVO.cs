
using System.Text.Json.Serialization;

namespace RestWithAspNET5Udemy.Data.VO
{
    public class PersonVO 
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
    }
}
