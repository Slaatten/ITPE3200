var builder = WebApplication.CreateBuilder(args);
// Lager en "builder" som setter opp appen (konfigurasjon, logging, services osv.)

builder.Services.AddControllersWithViews();
// Registrerer støtte for MVC (Controllers + Views) i applikasjonen

var app = builder.Build();
// Bygger selve applikasjonen basert på konfigurasjonen

if (app.Environment.IsDevelopment())
// Sjekker om vi kjører i "development" (utviklingsmiljø)
{
    app.UseDeveloperExceptionPage();
    // Viser detaljerte feilmeldinger i nettleseren (nyttig under utvikling)
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();
// Setter opp standard routing: /{controller=Home}/{action=Index}/{id?}
// Betyr f.eks. at "/Item/Table" kjører Table()-metoden i ItemController

app.Run();
// Starter webserveren og kjører appen
