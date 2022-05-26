using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNET5Udemy.Model
{
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }
        public string Address { get; set; }
        [Column("First_Name")]
        public string FirstName { get; set; }
        [Column("Last_Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}
