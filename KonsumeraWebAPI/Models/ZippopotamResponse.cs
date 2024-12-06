




using System.Text.Json.Serialization;  // Importerar biblioteket för JSON-serialisering

namespace KonsumeraWebAPI.Models;  // Definierar namnområdet för modellerna




// Klass för svaret från Zippopotam API
public class ZippopotamResponse
{
    // Attributet används för att mappa JSON-nyckeln "post code" till C#-egenskapen PostCode
    [JsonPropertyName("post code")]
    public string PostCode { get; set; }

    // Attributet används för att mappa JSON-nyckeln "places" till C#-egenskapen Places
    [JsonPropertyName("places")]
    public List<Place> Places { get; set; }  // Listan med alla platser för en given postkod
}




// Klass som representerar information om en plats
public class Place
{
    // Attributet används för att mappa JSON-nyckeln "latitude" till C#-egenskapen Latitude
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }

    // Attributet används för att mappa JSON-nyckeln "longitude" till C#-egenskapen Longitude
    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }
}
