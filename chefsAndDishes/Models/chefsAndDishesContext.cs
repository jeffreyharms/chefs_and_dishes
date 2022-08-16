#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace chefsAndDishes.Models;

public class chefsAndDishesContext : DbContext
{
    public chefsAndDishesContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> chefs { get; set; }
    public DbSet<Dish> dishes { get; set; }
}