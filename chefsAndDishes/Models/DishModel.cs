#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsAndDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "is required")]
    [Range(1, 9999)]
    public int Calories { get; set; }
    [Required(ErrorMessage = "is required")]
    public int Tastiness { get; set; }
    [Required(ErrorMessage = "is required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "is required")]
    public DateTime Created_At { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "is required")]
    public DateTime Updated_At { get; set; } = DateTime.Now;
    [Required]
    public int ChefId { get; set; }
    public Chef? Creator { get; set; }

}