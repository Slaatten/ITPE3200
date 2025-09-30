using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Table()
        {
            List<Item> items = _itemDbContext.Items.ToList();
            var itemsViewModel = new ItemsViewModel(items, "Table");
            return View(itemsViewModel);
        }

        public IActionResult Grid()
        {
            List<Item> items = _itemDbContext.Items.ToList();
            var itemsViewModel = new ItemsViewModel(items, "Grid");        // Gir ViewBag beskjed om at dette er tabellvisning
            return View(itemsViewModel);                       // Sender listen til Grid.cshtml
        }

        public IActionResult Details(int id)
        {
            List<Item> items = _itemDbContext.Items.ToList();
            var item = items.FirstOrDefault(i => i.ItemId == id);
            if (item == null)
                return NotFound();
            return View(item);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemDbContext.Items.Add(item);
                _itemDbContext.SaveChanges();
                return RedirectToAction(nameof(Table));
            }
            return View(item);
        }
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

            // Legg til flere varer hvis du vil (4–8) for å fylle ut listen
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            return items;
        }
    }
}
