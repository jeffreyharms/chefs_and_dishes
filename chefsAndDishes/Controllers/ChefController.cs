using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using chefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsAndDishes.Controllers;

public class ChefController : Controller
{
    private chefsAndDishesContext _context;
    public ChefController(chefsAndDishesContext context)
    {
        _context = context;
    }
    [HttpGet("/chefs/all")]
    public IActionResult All()
    {
        List<Chef> AllChefs = _context.chefs.ToList();
        List<Chef> CreatedDishes = _context.chefs
        .Include(c => c.CreatedDishes)
        .ToList();
        return View("AllChefs", AllChefs);
    }
    [HttpGet("/chefs/new")]
    public IActionResult New()
    {
        return View("NewChef");
    }
    [HttpPost("/chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if (ModelState.IsValid == false)
        {
            return New();
        }
        _context.chefs.Add(newChef);
        _context.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpPost("/chefs/{deletedChefId}")]
    public IActionResult Delete(int deletedChefId)
    {
        Chef? chefToBeDeleted = _context.chefs.FirstOrDefault(chef => chef.ChefId == deletedChefId);
    
    if (chefToBeDeleted != null)
    {
        _context.chefs.Remove(chefToBeDeleted);
        _context.SaveChanges();
    }
    return RedirectToAction("All");
    }
}