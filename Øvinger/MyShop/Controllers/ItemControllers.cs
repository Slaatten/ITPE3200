using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // <-- for async EF-metoder
using MyShop.Models;
using MyShop.ViewModels;

namespace MyShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemDbContext _itemDbContext;

        public ItemController(ItemDbContext itemDbContext)
        {
            _itemDbContext = itemDbContext;
        }

        // GET: /Item/Table
        public async Task<IActionResult> Table()
        {
            List<Item> items = await _itemDbContext.Items.ToListAsync();
            var itemsViewModel = new ItemsViewModel(items, "Table");
            return View(itemsViewModel);
        }

        // GET: /Item/Grid
        public async Task<IActionResult> Grid()
        {
            List<Item> items = await _itemDbContext.Items.ToListAsync();
            var itemsViewModel = new ItemsViewModel(items, "Grid");
            return View(itemsViewModel);
        }

        // GET: /Item/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _itemDbContext.Items
                .FirstOrDefaultAsync(i => i.ItemId == id);

            if (item == null) return NotFound();
            return View(item);
        }

        // GET: /Item/Create  (ikke async – ingen DB-kall)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Item/Create
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemDbContext.Items.Add(item);
                await _itemDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Table));
            }
            return View(item);
        }

        // GET: /Item/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var item = await _itemDbContext.Items.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /Item/Update
        [HttpPost]
        public async Task<IActionResult> Update(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemDbContext.Items.Update(item);
                await _itemDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Table));
            }
            return View(item);
        }

        // GET: /Item/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemDbContext.Items.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /Item/DeleteConfirmed/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _itemDbContext.Items.FindAsync(id);
            if (item == null) return NotFound();

            _itemDbContext.Items.Remove(item);
            await _itemDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }

        // Demo-data – ikke DB, kan stå som før
        public List<Item> GetItems()
        {
            var items = new List<Item>();

            var item1 = new Item
            {
                ItemId = 1,
                Name = "Pizza",
                Price = 150,
                Description = "Delicious Italian dish with a thin crust topped with tomato sauce, cheese, and various toppings.",
                ImageUrl = "/images/pizza.jpg"
            };

            var item2 = new Item
            {
                ItemId = 2,
                Name = "Fried Chicken Leg",
                Price = 90,
                Description = "Crispy fried chicken leg with seasoning and spices.",
                ImageUrl = "/images/fishandchips.jpg"
            };

            var item3 = new Item
            {
                ItemId = 3,
                Name = "Tacos",
                Price = 120,
                Description = "Mexican style tacos with beef, lettuce, and salsa.",
                ImageUrl = "/images/tacos.jpg"
            };

            items.AddRange(new[] { item1, item2, item3 });
            return items;
        }
    }
}
