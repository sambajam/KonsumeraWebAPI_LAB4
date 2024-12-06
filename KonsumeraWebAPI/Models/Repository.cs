




using System.Text.Json.Serialization;  // Importerar bibliotek för JSON-serialisering

namespace KonsumeraWebAPI.Models;  // Definierar namnområdet för modellen






// Klass för GitHub-repo
public class Repository
{



    // Attributet används för att mappa JSON-nyckeln "name" till C#-egenskapen Name
    [JsonPropertyName("name")]
    public string Name { get; set; }

    // Attributet används för att mappa JSON-nyckeln "html_url" till C#-egenskapen HtmlUrl
    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; set; }

    // Attributet används för att mappa JSON-nyckeln "description" till C#-egenskapen Description
    [JsonPropertyName("description")]
    public string Description { get; set; }

    // Attributet används för att mappa JSON-nyckeln "homepage" till C#-egenskapen Homepage
    [JsonPropertyName("homepage")]
    public string Homepage { get; set; }

    // Attributet används för att mappa JSON-nyckeln "watchers" till C#-egenskapen Watchers
    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    // Attributet används för att mappa JSON-nyckeln "pushed_at" till C#-egenskapen PushedAt
    [JsonPropertyName("pushed_at")]
    public DateTime PushedAt { get; set; }


}
