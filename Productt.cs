using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapProjectUsingADO.net.Models
{
    [Table("Productt")]
    public class Productt
    {
       
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

       

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
