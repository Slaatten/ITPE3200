using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.ViewModels;

namespace MyShop.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Table()
        {
            var items = GetItems();
            var itemsViewModel = new ItemsViewModel(items, "Table");
            return View(itemsViewModel);
        }

        public IActionResult Grid()
        {
            var items = GetItems();                   // Henter data fra egen metode
            var itemsViewModel = new ItemsViewModel(items, "Grid");        // Gir ViewBag beskjed om at dette er tabellvisning
            return View(itemsViewModel);                       // Sender listen til Grid.cshtml
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
                ImageUrl = "pizza.jpg"
            };

            var item2 = new Item
            {
                ItemId = 2,
                Name = "Fried Chicken Leg",
                Price = 90,
                Description = "Crispy fried chicken leg with seasoning and spices.",
                ImageUrl = "fishandchips.jpg"
            };

            var item3 = new Item
            {
                ItemId = 3,
                Name = "Tacos",
                Price = 120,
                Description = "Mexican style tacos with beef, lettuce, and salsa.",
                ImageUrl = "tacos.jpg"
            };

            // Legg til flere varer hvis du vil (4–8) for å fylle ut listen
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            return items;
        }
    }
}
