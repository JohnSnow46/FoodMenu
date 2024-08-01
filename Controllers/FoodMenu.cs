using Microsoft.AspNetCore.Mvc;
using FoodMenu.Models;
using FoodMenu.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodMenu.Controllers
{
    public class FoodMenu : Controller
    {
        private readonly Context _context;

        public FoodMenu(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var foods = from d in _context.Foods
                       select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(d => d.Name.Contains(searchString));
                return View(await foods.ToListAsync());
            }

            return View(await foods.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var Food = await _context.Foods
                .Include(fi => fi.FoodMenuIngridients)
                .ThenInclude(i => i.Ingridient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(Food == null)
            {
                return NotFound();
            }

            return View(Food);
        }
        //TODO
        //populate data, add icon to searchbar, make it nicer
    }
}
