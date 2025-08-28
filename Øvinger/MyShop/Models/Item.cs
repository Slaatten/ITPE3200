using System;                         // Importerer System-navnerommet (grunnleggende C# funksjoner)

namespace MyShop.Models               // Definerer et navnerom kalt MyShop.Models
{                                     // (brukes for å organisere klasser i prosjektet)

    public class Item                  // Lager en offentlig klasse som heter Item
    {
        public int ItemId { get; set; }            // Unik ID for varen (heltall)
        public string Name { get; set; } = string.Empty;   // Navn på varen (kan ikke være null, starter som tom streng)
        public decimal Price { get; set; }         // Pris på varen (decimal = brukes for penger)
        public string? Description { get; set; }   // Beskrivelse av varen (valgfri, kan være null)
        public string? ImageUrl { get; set; }      // Lenke til bilde (valgfri, kan være null)
    }
}
