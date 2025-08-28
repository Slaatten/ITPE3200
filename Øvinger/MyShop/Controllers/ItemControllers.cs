using System;                                     // Grunnleggende C# funksjoner
using System.Collections.Generic;                // Gir tilgang til List<T> og andre samlingsklasser
using System.Linq;                               // For LINQ-spørringer (ikke brukt her, men ofte nyttig)
using System.Threading.Tasks;                    // For asynkron programmering (ikke brukt her, men standard import)
using Microsoft.AspNetCore.Mvc;                  // Gir tilgang til Controller og IActionResult (MVC-funksjoner)
using MyShop.Models;                             // Importerer Item-klassen vi lagde i Models

namespace MyShop.Controllers                     // Navnerom for controllere i MyShop
{
    public class ItemController : Controller     // En controller-klasse som arver fra Controller
    {
        public IActionResult Table()             // En action-metode som håndterer "/Item/Table"
        {
            var items = new List<Item>();        // Lager en liste for å lagre varer

            // Første vare - laget med "ny instans" og deretter satt verdier
            var item1 = new Item();
            item1.ItemId = 1;
            item1.Name = "Pizza";
            item1.Price = 60;

            // Andre vare - laget direkte med "object initializer" (kortere måte)
            var item2 = new Item
            {
                ItemId = 2,
                Name = "Fried Chicken Leg",
                Price = 15
            };

            // Legger varene inn i listen
            items.Add(item1);
            items.Add(item2);

            // Sender en tekst til ViewBag som kan vises i View (overskrift)
            ViewBag.CurrentViewName = "List of Shop Items";

            // Returnerer viewet, og sender med listen items til Table.cshtml
            return View(items);
        }
    }
}
