using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNET5Udemy.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
