





using KonsumeraWebAPI.Services;  // Importerar tjänster för att hämta data från API:erna



class Program
{
    // Huvudmetoden 
    static async Task Main(string[] args)
    {
        // Skriver ut ett meddelande om att data hämtas från GitHub
        Console.WriteLine("Hämtar data från GitHub...");

        // Hämtar GitHub-repositories via ApiService-metoden GetGitHubRepositories
        var gitHubData = await ApiService.GetGitHubRepositories();

        // Om det finns några repositories i listan
        if (gitHubData.Any())
        {
            // Skriver ut rubriken för GitHub repositories
            Console.WriteLine("\n== GitHub Repositories ==");

            // Loopa igenom varje repository och skriv ut dess information
            foreach (var repo in gitHubData)
            {
                // Skriv ut namnet på repositoryt
                Console.WriteLine($"Namn: {repo.Name}");

                // Skriv ut beskrivningen, om det inte finns skriv ut "Ingen beskrivning"
                Console.WriteLine($"Beskrivning: {repo.Description ?? "Ingen beskrivning"}");

                // Skriv ut HTML-URL till repositoryt
                Console.WriteLine($"URL: {repo.HtmlUrl}");

                // Skriv ut hemsidan, om det inte finns skriv ut "Ingen hemsida"
                Console.WriteLine($"Hemsida: {repo.Homepage ?? "Ingen hemsida"}");

                // Skriv ut antal watchers
                Console.WriteLine($"Watchers: {repo.Watchers}");

                // Skriv ut när senaste pushen gjordes
                Console.WriteLine($"Senast pushad: {repo.PushedAt}");

                // Skriv ut en avgränsning för att separera repositories
                Console.WriteLine("------------------------------------");
            }
        }
        else
        {
            // Om inga repositories finns, skriv ut ett meddelande
            Console.WriteLine("Inga repo hittades.");
        }

        // Skriver ut ett meddelande om att platsdata hämtas för Montvale, New Jersey
        Console.WriteLine("\nHämtar postnummer för Montvale, New Jersey...");

        // Hämtar platsdata från Zippopotam API via ApiService-metoden GetLocationData
        var locationData = await ApiService.GetLocationData("US", "NJ", "Montvale");

        // Om platsdata finns
        if (locationData != null)
        {
            // Skriv ut rubriken för platsdata
            Console.WriteLine("\n=== Platsdata ===");

            // Skriv ut postnumret
            Console.WriteLine($"Postnummer: {locationData.PostCode}");

            // Skriv ut latituden
            Console.WriteLine($"Latitud: {locationData.Latitude}");

            // Skriv ut longituden
            Console.WriteLine($"Longitud: {locationData.Longitude}");
        }
        else
        {
            // Om platsdata inte kunde hämtas, skriv ut ett meddelande
            Console.WriteLine("Platsdata kunde inte hämtas.");
        }
    }
}
