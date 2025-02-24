using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapProjectUsingADO.net.Models
{
    [Table("Categoryy")]
    public class Categoryy
    {
       
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }

    }
}
