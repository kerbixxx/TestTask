using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
