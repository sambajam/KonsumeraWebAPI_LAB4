




using System.Net.Http;  // Importerar biblioteket för HTTP-förfrågningar
using System.Text.Json;  // Importerar biblioteket för JSON-serialisering
using KonsumeraWebAPI.Models;  // Importerar modeller för datamodeller




namespace KonsumeraWebAPI.Services;  // Definierar namnområdet för tjänster




// Static klass för att hantera API-förfrågningar
public static class ApiService
{
    // Skapar en HttpClient-instans för att göra HTTP-förfrågningar
    private static readonly HttpClient Client = new HttpClient();

    // Metod som hämtar en lista med GitHub-repositories från .NET Foundation
    public static async Task<List<Repository>> GetGitHubRepositories()
    {
        // URL till GitHub API
        string url = "https://api.github.com/orgs/dotnet/repos";

        // Lägger till en användaragent (User-Agent) för att imitera en riktig webbläsare
        Client.DefaultRequestHeaders.UserAgent.ParseAdd("request");

        // Hämtar svaret från API:et som en sträng
        var response = await Client.GetStringAsync(url);

        // Deserialiserar JSON-svaret till en lista av Repository-objekt, returnerar en tom lista om inget svar finns
        return JsonSerializer.Deserialize<List<Repository>>(response) ?? new List<Repository>();
    }

    // Metod som hämtar platsdata för ett givet land, delstat och stad från Zippopotam API
    public static async Task<Location> GetLocationData(string country, string state, string city)
    {
        // Skapar URL för Zippopotam API-begäran
        string url = $"https://api.zippopotam.us/{country}/{state}/{city}";

        try
        {
            // Hämtar svaret från Zippopotam API
            var response = await Client.GetStringAsync(url);

            // Deserialiserar JSON-svaret till ZippopotamResponse-objekt
            var data = JsonSerializer.Deserialize<ZippopotamResponse>(response);

            // Om ingen data hittas eller om listan över platser är tom, kasta ett undantag
            if (data == null || !data.Places.Any())
                throw new Exception("Ingen platsdata hittades.");

            // Hämtar den första platsen från listan
            var firstPlace = data.Places.First();

            // Returnerar ett Location-objekt med postnummer, latitud och longitud
            return new Location
            {
                PostCode = data.PostCode,
                Latitude = firstPlace.Latitude,
                Longitude = firstPlace.Longitude
            };
        }
        catch (Exception ex)
        {
            // Fångar eventuella fel och skriver ut felmeddelandet till konsolen
            Console.WriteLine($"Fel vid hämtning av platsdata: {ex.Message}");

            // Returnerar null om något gick fel
            return null;
        }
    }
}
