using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsAndDishes.Controllers;

public class DishController : Controller
{
    private chefsAndDishesContext _context;
    public DishController(chefsAndDishesContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> AllDishes = _context.dishes.ToList();
        ViewBag.AllChefs = _context.chefs.ToList();
        return View("AllDishes", AllDishes);
    }
    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        ViewBag.AllChefs = _context.chefs.ToList();
        return View("NewDish");
    }
    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            return New();
        }
        _context.dishes.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpPost("/dishes/{deletedDishId}")]
    public IActionResult Delete(int deletedDishId)
    {
        Dish? dishToBeDeleted = _context.dishes.FirstOrDefault(dish => dish.DishId == deletedDishId);
    
    if (dishToBeDeleted != null)
    {
        _context.dishes.Remove(dishToBeDeleted);
        _context.SaveChanges();
    }
    return RedirectToAction("All");
    }
}