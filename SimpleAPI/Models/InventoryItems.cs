using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Controller
{
    public class InventoryItems
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}