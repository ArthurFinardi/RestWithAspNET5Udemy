using RestWithAspNET5Udemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNET5Udemy.Model
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        public string Address { get; set; }
        [Column("First_Name")]
        public string FirstName { get; set; }
        [Column("Last_Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}
